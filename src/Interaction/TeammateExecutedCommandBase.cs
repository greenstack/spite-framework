using System;
using System.Collections.Generic;
using System.Text;

namespace Spite.Interaction
{
	/// <summary>
	/// Represents a basic command that is executed by a teammate.
	/// </summary>
	public abstract class TeammateExecutedCommandBase : CommandBase, ITeammateExecutedCommand
	{
		/// <inheritdoc/>
		public ITeammate Executor { get; }
		
		/// <summary>
		/// Constructs a basic command executed by a teammate.
		/// </summary>
		/// <param name="user">The user executing the command.</param>
		/// <param name="action">The action that occurs as a result of the action.</param>
		public TeammateExecutedCommandBase(ITeammate user, ISpiteAction action) : base(action)
		{
			Executor = user;
		}
	}
}
