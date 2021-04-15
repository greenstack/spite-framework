using System.Collections.Generic;
using Spite.Turns;

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

        /// <summary>
        /// Retrieves the teams receiving the relationship the sending team has with them.
        /// </summary>
        /// <param name="sending">The team sending the relationship.</param>
        /// <param name="relationship">The relationship sent from the sender</param>
        /// <returns>A list of teams that the sending team has the relationship with.</returns>
        IList<ITeam> GetTeamsWithRelationship(ITeam sending, TeamRelationship relationship);

        /// <summary>
        /// Starts the battle.
        /// </summary>
        [System.Obsolete("I believe that ReceiveAndExecuteCommand should be able to accomplish the same thing.")]
        void StartBattle();

        /// <summary>
        /// Updates all teams' standings.
        /// </summary>
        void UpdateTeamStandings();
        
        /// <summary>
        /// Accepts the command and tries to execute it.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        /// <returns>The list of reactions that occurred.</returns>
        Interaction.IReaction[] ReceiveAndExecuteCommand(Interaction.CommandBase command);
    }
}
