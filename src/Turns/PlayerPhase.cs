using Spite.Interaction;
using System;

namespace Spite.Turns
{
	/// <summary>
	/// Represents a phase in which a single player can act.
	/// 
	/// This is essentially a player's turn, but only if a player can execute the
	/// same kind of command each turn.
	/// </summary>
	/// <typeparam name="TPlayer">The type that represents a player.</typeparam>
	public class PlayerPhase<TPlayer> : ITurnPhase
		where TPlayer : ITeam, ICommandExecutor
	{
		/// <summary>
		/// The player that can currently act.
		/// </summary>
		public TPlayer CurrentPlayer { get; }

		/// <summary>
		/// The number of successful commands given to this phase.
		/// </summary>
		internal int commandsGiven = 0;

		/// <summary>
		/// The number of commands that can be given.
		/// </summary>
		public int CommandsAcceptable { get; internal set; }

		/// <summary>
		/// Constructs a basic PlayerPhase object.
		/// </summary>
		/// <param name="player">The player whose turn it is.</param>
		public PlayerPhase(TPlayer player)
		{
			CurrentPlayer = player;
		}

		/// <summary>
		/// Not used - the discrete team turn managers handle this.
		/// </summary>
		/// <returns>Throws.</returns>
		public ITurnPhase GetNextPhase()
		{
			throw new InvalidOperationException();
		}

		/// <summary>
		/// Checks if the given command can be executed during this phase.
		/// </summary>
		/// <param name="command">The command that is run this turn.</param>
		/// <returns>True if the command's executor is the same as the current player.</returns>
		public bool IsCommandExecutableThisPhase(CommandBase command)
		{
			return command.Executor == (ICommandExecutor)CurrentPlayer;
		}

		/// <summary>
		/// Tells us if we should advance our phase or not.
		/// </summary>
		/// <param name="results">The results of the recently taken action.</param>
		/// <returns>True</returns>
		public bool ShouldAdvancePhase(IReaction[] results)
		{
			// One of the ideas is that a player could execute a number of commands,
			// but I'm not entirely sure that's the right course of action.
			// TODO: Look into this
			return true;
		}
	}
}