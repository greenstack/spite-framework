namespace Spite.Stats
{
	/// <summary>
	/// Represents a stat with a maximum value.
	/// </summary>
	/// <typeparam name="T">The type that this stat wraps.</typeparam>
	public interface IMaxableStat<T> : IStat<T> where T :
		System.IComparable<T>,
		System.IEquatable<T>
	{
		/// <summary>
		/// The maximum value for this stat.
		/// </summary>
		T MaxValue { get; }
    }
}
