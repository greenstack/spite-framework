namespace Spite
{
	/// <summary>
	/// Represents an entity that can be tapped.
	/// </summary>
	public interface ITappableTeammate : ITeammate
	{
		/// <summary>
		/// Is this teammate tapped?
		/// </summary>
		bool IsTapped { get; }

		/// <summary>
		/// Taps this teammate, preventing the unit from acting.
		/// </summary>
		void Tap();

		/// <summary>
		/// Untaps this teammate, allowing it to act again.
		/// </summary>
		void Untap();
	}
}
