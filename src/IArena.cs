﻿using Spite.Actions;
using System.Collections.Generic;

namespace Spite
{
    /// <summary>
    /// Provides a non-generic interface. This typically shouldn't be used.
    /// </summary>
    public interface IArena
    {
        /// <summary>
        /// The number of teams managed by this arena.
        /// </summary>
        int TeamCount { get; }

        /// <summary>
        /// The name of this arena.
        /// </summary>
        string ArenaName { get; }

        /// <summary>
        /// This Arena's TurnManager.
        /// </summary>
        ITurnManager TurnManager { get; }

        /// <summary>
        /// All the teams that are fighting in this arena.
        /// </summary>
        IList<ITeam> Teams { get; }

        /// <summary>
        /// Finds the teams opposing the given team.
        /// </summary>
        /// <param name="team">The team to find opponents for.</param>
        /// <returns>A list of teams exluding opposing and that aren't allied with T.</returns>
        IEnumerable<ITeam> GetTeamsOpposing(ITeam team);

        /// <summary>
        /// Finds the teams opposing the given team, all cast to T.
        /// </summary>
        /// <typeparam name="T">The type of team to cast the result to.</typeparam>
        /// <param name="team">The team to find opponents for.</param>
        /// <returns>The teams opposing the provided team, cast to T.</returns>
        IEnumerable<T> GetTeamsOpposing<T>(T team) where T : ITeam;

        /// <summary>
        /// Updates all teams' standings.
        /// </summary>
        void UpdateTeamStandings();

        /// <summary>
        /// Receives an action that should apply in some part of the Arena.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        /// <param name="updateStandings">If the standings should be updated.</param>
        void ReceiveAction(IAction action, bool updateStandings);
    }
}
