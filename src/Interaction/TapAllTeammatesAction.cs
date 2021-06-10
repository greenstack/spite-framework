﻿namespace Spite.Interaction
{
	/// <summary>
	/// An action that taps all teammates.
	/// </summary>
	public class TapAllTeammatesAction : ISpiteAction
	{
		/// <inheritdoc/>
		public ITeammate User => null;

		readonly ITappableTeammateTeam teamToTap;

		/// <summary>
		/// Constructs a basic TapAllTeammatesAction.
		/// </summary>
		/// <param name="teamToTap">The team to tap.</param>
		public TapAllTeammatesAction(ITappableTeammateTeam teamToTap)
		{
			this.teamToTap = teamToTap;
		}

		/// <summary>
		/// Checks if this command is valid.
		/// </summary>
		/// <returns>True in all scenarios.</returns>
		public bool IsValid()
		{
			return true;
		}

		/// <summary>
		/// Taps all units on the team and returns a reaction.
		/// </summary>
		/// <returns>A <see cref="TapAllReaction"/>.</returns>
		public IReaction UseAndGetReaction()
		{
			foreach (var teammate in teamToTap.Members)
			{
				teammate.Tap();
			}

			return new TapAllReaction();
		}
	}
}
