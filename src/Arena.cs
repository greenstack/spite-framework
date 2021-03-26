using System.Linq;
using System.Collections.Generic;
using System;
using Spite.Turns;

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

        public AllianceGraph AllianceGraph { get; internal set; }

        /// <summary>
        /// Creates an arena with the specified number of teams fighting in it.
        /// </summary>
        /// <param name="numberOfTeams">The number of teams fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        /// <exception cref="ArgumentNullException">Thrown when turnManager is null.</param>
        public Arena(uint numberOfTeams, ITurnManager turnManager)
        {
            if (turnManager == null) {
                throw new ArgumentNullException(nameof(turnManager));
            }
            teams = new ITeam[numberOfTeams];
            TurnManager = turnManager;
        }

        /// <summary>
        /// Creates a named arena with the specified number of teams fighting in it.
        /// </summary>
        /// <param name="name">The name of the arena.</param>
        /// <param name="numberOfTeams">The number of teams fighting in the arena.</param>
        /// <param name="turnManager">The object that manages the turns in this arena.</param>
        public Arena(string name, uint numberOfTeams, ITurnManager turnManager) :
            this(numberOfTeams, turnManager)
        {
            ArenaName = name;
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
        /// Gets the teams that receive the specified relationship from the given team.
        /// </summary>
        /// <param name="from">The team from which the relationship originates.</param>
        /// <param name="relationship">The relationship the team creates.</param>
        /// <returns>All the teams with the specified relationship.</returns>
        public IList<ITeam> GetTeamsWithRelationship(ITeam from, TeamRelationship relationship) {
            return AllianceGraph.GetTeamsWithRelationship(from, relationship);
        }

        /// <summary>
        /// Gets the teams that the given team has the specified relationship towards.
        /// </summary>
        /// <param name="from">The team that has the relationship.</param>
        /// <param name="relationship">The relationship that the team has for the others.</param>
        /// <typeparam name="T">The type of team to get.</typeparam>
        /// <returns>An enumerable with the teams that the given team has the relationship with.</returns>
        public IList<T> GetTeamsWithRelationship<T>(T from, TeamRelationship relationship) where T : ITeam
        {
            return GetTeamsWithRelationship(from, relationship).Cast<T>().ToList();
        }

        /// <summary>
        /// Causes each team to update its standing.
        /// </summary>
        public void UpdateTeamStandings()
        {
            foreach (var team in teams)
            {
                team.DetermineStanding(this);
            }
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

        /// <summary>
        /// Starts the battle.
        /// </summary>
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
