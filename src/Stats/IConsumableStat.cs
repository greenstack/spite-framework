namespace Spite.Stats
{
	/// <summary>
	/// Provides an interface for stats that are consumed.
	/// </summary>
	/// <typeparam name="T">The underlying numeric type for the stat.</typeparam>
	public interface IConsumableStat<T> : IMaxableStat<T>, IMinableStat<T> where T :
		System.IComparable<T>,
		System.IEquatable<T>
	{
		/// <summary>
		/// Removes the specified amount from the stat's current value.
		/// </summary>
		/// <param name="amount">The amount of the stat to drain.</param>
		void Add(T amount);

		/// <summary>
		/// Adds the specified amount to the stat's value.
		/// </summary>
		/// <param name="amount">The amount of the stat to replenish.</param>
		void Remove(T amount);
	}
}
