using System;
using System.Collections.Generic;
using System.Linq;
using Spite.Turns;

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
        /// <returns>The Arena Builder for chaining.</returns>
        public ArenaBuilder<T> SetTurnScheme(TurnSchemeType turnScheme)
		{
            switch (turnScheme)
			{
                case TurnSchemeType.DiscreteTeam:
                    SetUpDiscreteTeamTurnManager();
                    break;
                case TurnSchemeType.DiscretePlayer:
                    throw new InvalidOperationException($"Use {nameof(ArenaBuilder<T>.UseDiscretePlayerTurnScheme)} instead");
                default:
                    throw new NotImplementedException($"The default turn manager for scheme {turnScheme} has not yet been implemented");
			}
            return this;
		}

        /// <summary>
        /// Tells the arena to use a discrete player turn scheme.
        /// </summary>
        /// <typeparam name="U">The type of the team being used.</typeparam>
        /// <returns></returns>
        public ArenaBuilder<T> UseDiscretePlayerTurnScheme<U>() where U : T, Interaction.ICommandExecutor
        {
            SetUpDiscretePlayerTurnManager<U>();
            return this;
        }

        private void SetUpDiscreteTeamTurnManager()
		{
            if (!typeof(ITeamOfTappables).IsAssignableFrom(typeof(T))) {
                throw new InvalidOperationException($"Cannot use discrete team turn scheme - {typeof(T)} does not contain ITappableTeammates");
			}

            var correctedType = teams.Cast<ITeamOfTappables>();

            turnManager = new DiscreteTeamTurnManager(correctedType.ToList());
		}

        private void SetUpDiscretePlayerTurnManager<U>() where U : T, Interaction.ICommandExecutor
        {
            if (!typeof(Interaction.ICommandExecutor).IsAssignableFrom(typeof(T))) {
                throw new InvalidOperationException($"Cannot use discrete player team turn scheme - {typeof(T)} does not implement {typeof(Interaction.ICommandExecutor)}");
            }

            var players = teams.Cast<Interaction.ICommandExecutor>();

            turnManager = new DiscretePlayerTurnManager<U>(players.ToList());
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
                throw new InvalidOperationException("A turn manager has not been set.");
            }
            int totalTeams = teamCount > 0 ? teamCount : teamsAdded;
            var arena = arenaName == null ?
                new Arena(totalTeams, turnManager) :
                new Arena(arenaName, totalTeams, turnManager)
                {
                    AllianceGraph = allianceGraph,
                };
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
