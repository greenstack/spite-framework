namespace Spite
{
	/// <summary>
	/// A team comprised of tappable units.
	/// </summary>
	public interface ITeamOfTappables : ITeam
	{
		/// <summary>
		/// The number of tapped units on the team.
		/// </summary>
		int TappedUnitCount { get; }

		/// <summary>
		/// Taps all units on this team.
		/// </summary>
		void TapAll();

		/// <summary>
		/// Untaps all units on this team.
		/// </summary>
		void UntapAll();
	}

	/// <summary>
	/// A team of teammates that can be tapped.
	/// </summary>
	/// <typeparam name="T">The type of teammate to contain.</typeparam>
	public interface ITeamOfTappables<T> : ITeam<T>, ITeamOfTappables
		where T : ITappableTeammate
	{ 
	}

	/// <summary>
	/// A generic team of entities that can be tapped.
	/// </summary>
	public interface ITappableTeammateTeam : ITeamOfTappables<ITappableTeammate>
	{
	}
}
