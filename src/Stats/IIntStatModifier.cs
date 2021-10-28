namespace Spite.Stats
{
	/// <summary>
	/// Provides a simple interface for modifying modifiable stats.
	/// </summary>
	public interface IIntStatModifier
	{
		/// <summary>
		/// Modifies the stat.
		/// </summary>
		/// <param name="currentValue">The stat's current value.</param>
		/// <returns>The stat's modified value.</returns>
		int ModifyStat(int currentValue);

		/// <summary>
		/// Removes the modification from the stat.
		/// </summary>
		/// <param name="currentValue">The stat's current value.</param>
		/// <returns>The stat's modified value.</returns>
		int UnmodifyStat(int currentValue);
	}
}
