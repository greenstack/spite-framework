namespace Spite
{
	/// <summary>
	/// Enumerates the status of a team mate.
	/// </summary>
	public enum TeammateStatus {
		/// <summary>
		/// The teammate has been defeated in battle.
		/// </summary>
		Defeated,
		/// <summary>
		/// The teammate is not an active participant in the battle.
		/// </summary>
		Inactive,
		/// <summary>
		/// The teammate is an active participant in battle.
		/// </summary>
		Active,
	}
}