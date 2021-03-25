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
        /// The graph that defines the relationships between the teams in this arena.
        /// </summary>
        AllianceGraph AllianceGraph { get; }

        /// <summary>
        /// All the teams that are fighting in this arena.
        /// </summary>
        IList<ITeam> Teams { get; }

        IList<ITeam> GetTeamsWithRelationship(ITeam from, TeamRelationship relationship);

        /// <summary>
        /// Starts the battle.
        /// </summary>
        void StartBattle();

        /// <summary>
        /// Updates all teams' standings.
        /// </summary>
        void UpdateTeamStandings();

        /// <summary>
        /// Receives the command for execution.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        /// <returns>True if the command is successful when executed. See <see cref="ICommand.Execute"/>.</returns>
        bool ReceiveAndExecuteCommand<TContext>(ICommand<TContext> command);
    }
}
