namespace Spite.Interaction
{
	/// <summary>
	/// Taps all units on the tappable team.
	/// </summary>
	public class TapAllTeammatesCommand : CommandBase
	{
		/// <summary>
		/// Adapts a team to the ICommandExecutor interface.
		/// </summary>
		private class TapAllExecutor : ICommandExecutor
		{
			public ITeam ResponsibleTeam { get; }

			public TapAllExecutor(ITeamOfTappables executor)
			{
				ResponsibleTeam = executor;
			}
		}

		/// <summary>
		/// Creates a command that will tap all units on the team. For use with DTTMs.
		/// </summary>
		/// <param name="teamToTap">The team that will have each unit tapped.</param>
		public TapAllTeammatesCommand(ITeamOfTappables teamToTap) : base(
			new TapAllTeammatesAction(teamToTap),
			teamToTap as ICommandExecutor ?? new TapAllExecutor(teamToTap))
		{
		}
	}
}
