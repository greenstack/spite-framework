using System.Linq;
using System.Collections.Generic;
using System;

namespace Spite
{
    /// <summary>
    /// Manages a group of teams in a battle.
    /// </summary>
    public class Arena : IArena
    {
        /// <summary>
        /// All the teams that are fighting in this arena.
        /// </summary>
        readonly internal ITeam[] teams;

        /// <inheritdoc/>
        public IList<ITeam> Teams => teams;

        /// <summary>
        /// Gets the turn manager.
        /// </summary>
        public ITurnManager TurnManager { get; }

        /// <summary>
        /// The number of teams managed by this arena.
        /// </summary>
        public int TeamCount => teams.Length;

        /// <summary>
        /// The name of this arena.
        /// </summary>
        public string ArenaName { get; }

        /// <summary>
        /// Creates an arena with the specified number of teams fighting in it.
        /// </summary>
        /// <param name="numberOfTeams">The number of teams fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        public Arena(uint numberOfTeams, ITurnManager turnManager)
        {
            teams = new ITeam[numberOfTeams];
            TurnManager = turnManager;
        }

        /// <summary>
        /// Creates a named arena with the specified number of teams fighting in it.
        /// </summary>
        /// <param name="name">The name of the arena.</param>
        /// <param name="numberOfTeams">The number of teams fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        public Arena(string name, uint numberOfTeams, ITurnManager turnManager)
        {
            ArenaName = name;
            teams = new ITeam[numberOfTeams];
            TurnManager = turnManager;
        }

        /// <summary>
        /// Gets the team with the given index.
        /// </summary>
        /// <param name="index">The index of the team.</param>
        /// <returns>The team at the specified index</returns>
        public ITeam GetTeam(uint index)
        {
            return teams[index];
        }

        /// <summary>
        /// Gets the teams opposing the given team, all cast to the specific type.
        /// </summary>
        /// <typeparam name="T">The specific type of team.</typeparam>
        /// <param name="opposing">The team to find opponents for.</param>
        /// <returns>All teams opposing the provided team.</returns>
        public IEnumerable<T> GetTeamsOpposing<T>(T opposing) where T : ITeam
        {
            return from side in Teams
                   where side.Equals(opposing)
                   select (T)side;
        }

        public void UpdateTeamStandings()
        {
            foreach (var team in teams)
            {
                team.DetermineStanding(this);
            }
        }

        public IEnumerable<ITeam> GetTeamsOpposing(ITeam team)
        {
            return GetTeamsOpposing<ITeam>(team);
        }

        /// <inheritdoc/>
        public bool ReceiveAndExecuteCommand<TContext>(ICommand<TContext> command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            bool success = TurnManager.CanBeExecuted(command) && command.Execute();
            if (command.ShouldUpdateTeamStandings)
            {
                UpdateTeamStandings();
            }
            return success;
        }

        public void StartBattle()
        {
            TurnManager.Start();
            OnBattleBegin?.Invoke(this);
        }

        /// <summary>
        /// Represents a method that is called when an Arena begins battle.
        /// </summary>
        /// <param name="arena">The arena starting the battle.</param>
        public delegate void BeginBattle(Arena arena);
        /// <summary>
        /// An event that fires when a battle begins.
        /// </summary>
        public event BeginBattle OnBattleBegin;
    }
}
