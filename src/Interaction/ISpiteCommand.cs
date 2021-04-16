using System;
using System.Collections.Generic;
using System.Text;

namespace Spite.Interaction
{
	/// <summary>
	/// Provides an interface for Spite commands.
	/// </summary>
	public interface ISpiteCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <returns>The reaction data.</returns>
		IReaction Execute();

		/// <summary>
		/// Executes the command and casts the result to the expected reaction type.
		/// </summary>
		/// <typeparam name="TReactionType">The expected type of reaction data.</typeparam>
		/// <returns>The reaction data.</returns>
		TReactionType Execute<TReactionType>()
			where TReactionType : IReaction;

		/// <summary>
		/// Checks if the command is valid.
		/// </summary>
		/// <returns>True if the command and the action are valid.</returns>
		bool IsValid();

		/// <summary>
		/// Retrieves this command as a team executed command.
		/// </summary>
		/// <returns>This command as a team executed command, or null if it isn't one.</returns>
		ITeamExecutedCommand AsTeamExecutedCommand();

		/// <summary>
		/// Retrieves this command as a teammate executed command.
		/// </summary>
		/// <returns>This command as a teammate executed command, or null if it isn't one.</returns>
		ITeammateExecutedCommand AsTeammateExecutedCommand();
	}
}
