namespace Spite.Stats
{
	/// <summary>
	/// Represents a stat.
	/// </summary>
	public interface IStat {
		/// <summary>
		/// Gets the current value of the stat.
		/// </summary>
		/// <returns>The current value of the stat.</returns>
		object GetCurrentValue();
	}

	public interface IStat<TNumberType> : IStat
	{
		/// <summary>
		/// The current value of the stat.
		/// </summary>
		TNumberType CurrentValue { get; }

		/// <summary>
		/// The base value of the stat.
		/// </summary>
		TNumberType BaseValue { get; }
	}
}
