﻿using System;
using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Provides methods useful for building and populating an arena.
    /// </summary>
    public class ArenaBuilder
    {
        private uint teamCount = 0;

        private string arenaName;

        private int teamsAdded = 0;

        private ITurnManager turnManager = null;

        private List<ITeam> teams = new List<ITeam>();

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
        public ArenaBuilder SetTeamCount(uint teamCount)
        {
            this.teamCount = teamCount;
            return this;
        }

        /// <summary>
        /// Sets the arena's name.
        /// </summary>
        /// <param name="name">Sets the name of this arena.</param>
        /// <returns>this</returns>
        public ArenaBuilder SetArenaName(string name)
        {
            arenaName = name;
            return this;
        }

        /// <summary>
        /// Sets the turn manager that this arena will use.
        /// </summary>
        /// <param name="manager">The scheme for determining the granularity and order of turns.</param>
        /// <returns>The ArenaBuilder for chaining.</returns>
        public ArenaBuilder SetTurnManager(ITurnManager manager)
        {
            turnManager = manager;
            return this;
        }

        /// <summary>
        /// Adds a team to this arena.
        /// </summary>
        /// <param name="team">The team to add to the arena.</param>
        /// <returns>The team to add to the arena.</returns>
        public ArenaBuilder AddTeam(ITeam team)
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
                new Arena(arenaName, teamCount, turnManager);

            for (int i = 0; i < teamsAdded; ++i)
            {
                arena.teams[i] = teams[i];
            }

            return arena;
        }
    }
}
