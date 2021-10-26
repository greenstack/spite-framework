namespace Spite.Stats
{
	/// <summary>
	/// Provides a basic interface for stats that can be modified.
	/// </summary>
	public interface IModifiableStat
	{
		/// <summary>
		/// Applies a stat modifier to this stat.
		/// </summary>
		/// <param name="statMod">The modifier to apply.</param>
		void ReceiveModifier(IStatModifier statMod);
	}
}