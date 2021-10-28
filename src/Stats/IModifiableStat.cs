namespace Spite.Stats
{
	/// <summary>
	/// Provides a basic interface for stats that can be modified.
	/// </summary>
	public interface IModifiableIntStat
	{
		/// <summary>
		/// Gets the current value of the stat.
		/// </summary>
		int CurrentValue { get; }

		/// <summary>
		/// Applies a stat modifier to this stat.
		/// </summary>
		/// <param name="statMod">The modifier to apply.</param>
		void ReceiveModifier(IIntStatModifier statMod);

		/// <summary>
		/// Removes a stat modifier from this stat.
		/// </summary>
		/// <param name="statMod">The stat modifier to remove.</param>
		void RemoveModifier(IIntStatModifier statMod);
	}
}
