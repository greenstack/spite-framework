namespace Spite
{
	/// <summary>
	/// Enumerates the possible relationships between teams.
	/// </summary>
	public enum TeamRelationship
	{
		/// <summary>
		/// The team is allied with other.
		/// </summary>
		Allied,
		/// <summary>
		/// The team is neutral toward the other.
		/// </summary>
		Neutral,
		/// <summary>
		/// The team opposes the other.
		/// </summary>
		Opposing,
		/// <summary>
		/// The relationship between teams is unknown.
		/// </summary>
		Unknown,
	}
}
