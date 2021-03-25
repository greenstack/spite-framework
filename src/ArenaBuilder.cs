using System;
using System.Collections.Generic;

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
        private uint teamCount = 0;

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
        private AllianceGraph allianceGraph = new AllianceGraph();

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
        public ArenaBuilder<T> SetTeamCount(uint teamCount)
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
        /// Sets the turn manager that this arena will use.
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
            if (teamsAdded >= teamCount)
            {
                throw new InvalidOperationException();
            }
            teams.Add(team);
            ++teamsAdded;
            return this;
        }

        /// <summary>
        /// Adds a bidrectional relationship between two teams. Both teams must have been added already to the builder.
        /// </summary>
        /// <param name="teamA">One of the teams to set the relationship for.</param>
        /// <param name="teamB">The other team to set the relationship for.</param>
        /// <param name="relationship">The relationship the teams have.</param>
        /// <returns>The arena builder for chaining.</returns>
        public ArenaBuilder<T> AddBidirectionalTeamRelationship(T teamA, T teamB, AllianceGraph.Relationship relationship)
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
            var arena = arenaName == null ?
                new Arena(teamCount, turnManager) :
                new Arena(arenaName, teamCount, turnManager)
                {
                    AllianceGraph = allianceGraph,
                };

            for (int i = 0; i < teamsAdded; ++i)
            {
                arena.teams[i] = teams[i];
            }

            return arena;
        }
    }
}
