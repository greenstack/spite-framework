namespace Spite.Stats
{
	/// <summary>
	/// Provides an interface for objects that can modify stats.
	/// </summary>
	public interface IStatModifier {
		/// <summary>
		/// The weight of this stat modifier.
		/// </summary>
		int Weight { get; }
	}
}
