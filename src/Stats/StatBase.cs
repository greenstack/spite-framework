using System;

namespace Spite.Stats
{
	/// <summary>
	/// Provides the basic and common methods for all stats.
	/// </summary>
	/// <typeparam name="T">The type held by this stat.</typeparam>
  public abstract class StatBase<T> : IStat<T> where T : IComparable<T>, IEquatable<T>
  {

		/// <inheritdoc/>
    public virtual T CurrentValue { get; protected set; }
		/// <inheritdoc/>
    public virtual T BaseValue { get; }

		public StatBase(T baseValue) :
			this(baseValue, baseValue)
		{ }

		public StatBase(T baseValue, T currentValue) 
		{
			BaseValue = baseValue;
			CurrentValue = currentValue;
		}

		/// <inheritdoc/>
    public object GetCurrentValue() => CurrentValue;
  }
}