namespace Spite.Stats
{
    /// <summary>
    /// Represents a stat with a minimum value.
    /// </summary>
    /// <typeparam name="T">The type that this stat wraps.</typeparam>
    public interface IMinableStat<T> : IStat<T>
    {
		/// <summary>
		/// The maximum value for this stat.
		/// </summary>
		T MinValue { get; }
    }
}