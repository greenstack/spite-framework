using System;

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

	/// <summary>
	/// Provides a generic interface for stats.
	/// </summary>
	/// <typeparam name="TNumberType">The type of stat.</typeparam>
	public interface IStat<TNumberType> where TNumberType :
		IComparable<TNumberType>,
		IEquatable<TNumberType>
	{
		/// <summary>
		/// The current value of the stat.
		/// </summary>
		TNumberType CurrentValue { get; }
	}
}
