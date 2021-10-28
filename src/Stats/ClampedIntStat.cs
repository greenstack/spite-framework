using System;

namespace Spite.Stats
{
	/// <summary>
	/// A stat whose values are constrained to a certain value.
	/// 
	/// Can be useful for things like hit points or some other expendable resource.
	/// </summary>
	public class ClampedIntStat
	{
		private int currentValue;
		/// <summary>
		/// The current value of the stat.
		/// </summary>
		public int CurrentValue
		{
			get => currentValue;
			private set
			{
#if NET5_0_OR_GREATER
				currentValue = Math.Clamp(value, MinValue, MaxValue);
#else
				currentValue = Math.Max(MinValue, Math.Min(value, MaxValue));
#endif
			}
		}

		/// <summary>
		/// The stat's minimum possible value.
		/// </summary>
		public int MinValue { get; private set; }

		/// <summary>
		/// The stat's maximum possible value.
		/// </summary>
		public int MaxValue { get; private set; }

		/// <summary>
		/// Creates a basic clamped int stat.
		/// </summary>
		/// <param name="startingValue">The value to initialize the stat to. Will be clamped to minValue or maxValue.</param>
		/// <param name="minValue">The minimum possible value.</param>
		/// <param name="maxValue">The maximum possible value.</param>
		public ClampedIntStat(int startingValue, int minValue, int maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			CurrentValue = startingValue;
		}

		/// <summary>
		/// Decreases the current value by the given amount.
		/// 
		/// If amount is negative, it is as if IncreaseValue were called.
		/// </summary>
		/// <param name="amount">The amount to decrease the value by.</param>
		public virtual void ReduceValue(int amount)
		{
			CurrentValue -= amount;
		}

		/// <summary>
		/// Increases the current value by the given amount.
		/// 
		/// If amount is negative, it is as if DecreaseValue were called.
		/// </summary>
		/// <param name="amount">The amount to increase the value by.</param>
		public virtual void IncreaseValue(int amount)
		{
			CurrentValue += amount;
		}
	}
}