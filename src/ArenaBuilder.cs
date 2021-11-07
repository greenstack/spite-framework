using System;
using System.Collections.Generic;
using System.Linq;
using Spite.Turns;
using Spite.Properties;

namespace Spite
{
    /// <summary>
    /// Provides methods useful for building and populating an arena.
    /// </summary>
    public class ArenaBuilder<T> where T : ITeam
    {
        /// <summary>
        /// The number of teams the arena should support.
        /// </summary>
        private int teamCount = -1;

        /// <summary>
        /// The name of the arena.
        /// </summary>
        private string arenaName;

        /// <summary>
        /// The teams added to the arena.
        /// </summary>
        private int teamsAdded = 0;

        /// <summary>
        /// The manager that will help track the flow of turns in this arena.
        /// </summary>
        private ITurnManager turnManager = null;

        /// <summary>
        /// The teams added in this builder.
        /// </summary>
        private readonly List<T> teams = new List<T>();

        /// <summary>
        /// The alliance graph for the coming arena.
        /// </summary>
        private readonly AllianceGraph allianceGraph = new AllianceGraph();

        /// <summary>
        /// Creates an instance of an Arena Builder.
        /// </summary>
        public ArenaBuilder()
        {
        }

        /// <summary>
        /// Sets the number of teams fighting in the arena.
        /// </summary>
        /// <param name="teamCount">The number of teams that will be fighting in the arena.</param>
        /// <returns>this</returns>
        public ArenaBuilder<T> SetTeamCount(int teamCount)
        {
            this.teamCount = teamCount;
            return this;
        }

        /// <summary>
        /// Sets the arena's name.
        /// </summary>
        /// <param name="name">Sets the name of this arena.</param>
        /// <returns>this</returns>
        public ArenaBuilder<T> SetArenaName(string name)
        {
            arenaName = name;
            return this;
        }

        /// <summary>
        /// Configures the turn scheme to be of the desired type. This sets the turn manager.
        /// </summary>
        /// <param name="turnScheme">The turn scheme to use.</param>
        /// <param name="executeFollowUpsIfActionFailed">Lets reactions from a command execute even if the original resulting action failed.</param>
        /// <returns>The Arena Builder for chaining.</returns>
        public ArenaBuilder<T> SetTurnScheme(TurnSchemeType turnScheme, bool executeFollowUpsIfActionFailed = true)
		{
            switch (turnScheme)
			{
                case TurnSchemeType.DiscreteTeam:
                    SetUpDiscreteTeamTurnManager(executeFollowUpsIfActionFailed);
                    break;
                case TurnSchemeType.DiscretePlayer:
                    SetUpDiscretePlayerTurnManager(executeFollowUpsIfActionFailed);
                    break;
                default:
                    throw new NotImplementedException($"The default turn manager for scheme {turnScheme} has not yet been implemented");
			}
            return this;
		}

        private void SetUpDiscreteTeamTurnManager(bool executeFollowUpsIfActionFailed)
		{
            if (!typeof(ITeamOfTappables).IsAssignableFrom(typeof(T))) {
                throw new InvalidOperationException($"Cannot use discrete team turn scheme - {typeof(T)} does not contain ITappableTeammates");
			}

            var correctedType = teams.Cast<ITeamOfTappables>();

            turnManager = new DiscreteTeamTurnManager(correctedType.ToList(), executeFollowUpsIfActionFailed);
		}

        private void SetUpDiscretePlayerTurnManager(bool executeFollowUpsIfActionFailed)
        {
            if (!typeof(Interaction.ICommandExecutor).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException($"{typeof(T)} can't be used with the Discrete Team turn scheme - it doesn't implement {nameof(Interaction.ICommandExecutor)}");
            }

            turnManager = new DiscretePlayerTurnManager<ITeamExecutor>(teams.Cast<ITeamExecutor>().ToList(), executeFollowUpsIfActionFailed);
        }

        /// <summary>
        /// Sets the turn manager that this arena will use. Cannot be used with SetTurnScheme.
        /// </summary>
        /// <param name="manager">The scheme for determining the granularity and order of turns.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder<T> SetTurnManager(ITurnManager manager)
        {
            turnManager = manager;
            return this;
        }

        /// <summary>
        /// If a turn manager has been set, 
        /// </summary>
        /// <param name="listener">The method to invoke when the phase is changed.</param>
        /// <exception cref="InvalidOperationException">Thrown if no team manager has been set.</exception>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder<T> AddPhaseChangedDelegateToTurnManager(ChangePhase listener)
		{
            if (turnManager == null)
                throw new InvalidOperationException(
#if !(UNITY_EDITOR || UNITY_STANDALONE)
                    Resources.TURN_MANAGER_NOT_SET
#else
                    "A turn manager has not been set"
#endif
                    );
            turnManager.OnPhaseChanged += listener;
            return this;
		}

        /// <summary>
        /// Sets the method for determining if battle is over or not. Should be used if using a
        /// default turn manager.
        /// </summary>
        /// <param name="predicate">The function for determining if the battle is over.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder<T> SetBattleOverCondition(Func<bool> predicate)
		{
            if (turnManager == null)
                throw new InvalidOperationException(
#if !(UNITY_EDITOR || UNITY_STANDALONE)
                    Resources.TURN_MANAGER_NOT_SET
#else
                    "A turn manager has not yet been set."
#endif
                );
            turnManager.IsBattleOver = predicate;
            return this;
		}

        /// <summary>
        /// Adds a team to this arena.
        /// </summary>
        /// <param name="team">The team to add to the arena.</param>
        /// <returns>The arena builder for chaining.</returns>
        public ArenaBuilder<T> AddTeam(T team)
        {
            if (teamCount > 0 && teamsAdded >= teamCount)
            {
                throw new InvalidOperationException($"This arena builder only supports {teamCount} teams");
            }
            teams.Add(team);
            ++teamsAdded;
            return this;
        }

        /// <summary>
        /// Adds a relationship directed from team a to team b.
        /// </summary>
        /// <param name="teamA">The team where the relationship originates from.</param>
        /// <param name="teamB">The team that the relationship is directed to.</param>
        /// <param name="relationship">The relationship this team has.</param>
        /// <returns>The arena buildter to allow for chaining.</returns>
        public ArenaBuilder<T> AddTeamRelationship(T teamA, T teamB, TeamRelationship relationship)
        {
            if (!teams.Contains(teamA)) {
                throw new InvalidOperationException($"{teamA} has not been added to this arena.");
            }
            if (!teams.Contains(teamB)) {
                throw new InvalidOperationException($"{teamB} has not been added to this arena.");
            }
            allianceGraph.AddRelation(teamA, teamB, relationship);
            return this;
        }

        /// <summary>
        /// Adds a bidrectional relationship between two teams. Both teams must have been added already to the builder.
        /// </summary>
        /// <param name="teamA">One of the teams to set the relationship for.</param>
        /// <param name="teamB">The other team to set the relationship for.</param>
        /// <param name="relationship">The relationship the teams have.</param>
        /// <returns>The arena builder for chaining.</returns>
        public ArenaBuilder<T> AddBidirectionalTeamRelationship(T teamA, T teamB, TeamRelationship relationship)
        {
            if (!teams.Contains(teamA)) {
                throw new InvalidOperationException($"{teamA} has not been added to this arena.");
            }
            if (!teams.Contains(teamB)) {
                throw new InvalidOperationException($"{teamB} has not been added to this arena.");
            }
            allianceGraph.AddBidirectionalRelation(teamA, teamB, relationship);
            return this;
        }

        /// <summary>
        /// Finishes building the Arena and creates it.
        /// </summary>
        /// <returns>The built arena.</returns>
        public Arena Finish()
        {
            if (turnManager == null)
            {
                throw new InvalidOperationException(
#if !(UNITY_EDITOR || UNITY_STANDALONE)
                    Resources.TURN_MANAGER_NOT_SET
#else
                    "The turn manager has not been set for this arena"
#endif
                );
            }
            if (turnManager.IsBattleOver == null)
			{
                throw new InvalidOperationException(
#if !(UNITY_EDITOR || UNITY_STANDALONE)
                    Resources.ARENA_BUILDER_NO_BATTLE_END_CONDITION_SET
#else
                    "No battle end condition has been specified for the arena"
#endif
                );
			}

            int totalTeams = teamCount > 0 ? teamCount : teamsAdded;
            var arena = arenaName == null ?
                new Arena(totalTeams, turnManager) :
                new Arena(arenaName, totalTeams, turnManager);

            arena.AllianceGraph = allianceGraph;

            // Since Arena.teams is readonly we have to do it this way.
            // Might want to look into another way
            for (int i = 0; i < teamsAdded; ++i)
            {
                arena.teams[i] = teams[i];
            }

            return arena;
        }
    }
}
