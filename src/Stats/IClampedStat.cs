namespace Spite.Stats
{
	interface IClampedStat<T>
	{
		T CurrentValue { get; }

		T MinValue { get; }

		T MaxValue { get; }
	}
}
