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
