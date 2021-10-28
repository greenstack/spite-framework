using System;

namespace Spite.Stats
{
	/// <summary>
	/// 
	/// </summary>
	public class ClampedFloatStat
	{
		private float currentValue;
		/// <summary>
		/// The current value of the stat.
		/// </summary>
		public float CurrentValue
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
		public float MinValue { get; private set; }

		/// <summary>
		/// The stat's maximum possible value.
		/// </summary>
		public float MaxValue { get; private set; }

		/// <summary>
		/// Creates a basic clamped float stat.
		/// </summary>
		/// <param name="startingValue">The value to initialize the stat to. Will be clamped to minValue or maxValue.</param>
		/// <param name="minValue">The minimum possible value.</param>
		/// <param name="maxValue">The maximum possible value.</param>
		public ClampedFloatStat(float startingValue, float minValue, float maxValue)
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
		public virtual void ReduceValue (float amount)
		{
			CurrentValue -= amount;
		}

		/// <summary>
		/// Increases the current value by the given amount.
		/// 
		/// If amount is negative, it is as if DecreaseValue were called.
		/// </summary>
		/// <param name="amount">The amount to increase the value by.</param>
		public virtual void IncreaseValue(float amount)
		{
			CurrentValue += amount;
		}
	}
}
