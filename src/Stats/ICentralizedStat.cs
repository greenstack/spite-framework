namespace Spite.Stats
{
	/// <summary>
	/// Represents a stat that's centered around a single value.
	/// </summary>
	/// <typeparam name="T">The type being contained by the stat.</typeparam>	
	public interface ICentralizedStat<T> : IStat<T> where T :
		System.IComparable<T>,
		System.IEquatable<T>
	{
		/// <summary>
		/// The center value of the stat.
		/// </summary>
		T CenterValue { get; }
	}
}