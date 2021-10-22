using NUnit.Framework;
using Spite.Stats;

namespace Spite.UnitTests
{
	public class ClampedIntStatTests
	{
		const int SmallMax = 255;
		const int SmallMin = -255;

		[Test]
		[TestCase(0, int.MinValue, int.MaxValue, 0)]
		[TestCase(0, 0, int.MaxValue, 0)]
		[TestCase(0, int.MinValue, 0, 0)]
		[TestCase(int.MaxValue, 0, 0, 0)]
		[TestCase(int.MinValue, 0, 0, 0)]
		[TestCase(int.MaxValue, SmallMin, SmallMax, SmallMax)]
		[TestCase(int.MinValue, SmallMin, SmallMax, SmallMin)]
		public void TestConstruction(int givenInitialValue, int minValue, int maxValue, int expectedInitialValue)
		{
			ClampedIntStat cis = new ClampedIntStat(givenInitialValue, minValue, maxValue);
			Assert.AreEqual(expectedInitialValue, cis.CurrentValue);
		}

		[Test]
		// Ensure adding nothing still does nothing
		[TestCase(0, int.MinValue, int.MaxValue, 0, 0)]
		// Ensure simple addition within range works
		[TestCase(0, int.MinValue, int.MaxValue, 100, 100)]
		// Enadding a negative value
		[TestCase(0, int.MinValue, int.MaxValue, -100, -100)]
		// Ensure we can still hit the upper limit
		[TestCase(0, SmallMin, SmallMax, SmallMax, SmallMax)]
		// Ensure that adding more than our upper limit yields the upper limit
		[TestCase(0, SmallMin, SmallMax, SmallMax * 2, SmallMax)]
		// Ensure that we can still hit the lower limit
		[TestCase(0, SmallMin, SmallMax, SmallMin, SmallMin)]
		// Ensure that removing more than our lower limit yields the lower limit
		[TestCase(0, SmallMin, SmallMax, SmallMin * 2, SmallMin)]
		public void TestIncreaseValue(int initialValue, int minValue, int maxValue, int increase, int expected)
		{
			ClampedIntStat stat = new ClampedIntStat(initialValue, minValue, maxValue);
			stat.IncreaseValue(increase);
			Assert.AreEqual(expected, stat.CurrentValue);
		}

		[Test]
		[TestCase(0, int.MinValue, int.MaxValue, 0, 0)]
		// Make sure that subtraction is happening
		[TestCase(0, int.MinValue, int.MaxValue, 100, -100)]
		[TestCase(0, int.MinValue, int.MaxValue, -100, 100)]
		// Increase value helps ensure the proper functioning of clamping
		// so we should be good there
		public void TestReduceValue(int initialValue, int minValue, int maxValue, int decrease, int expected)
		{
			ClampedIntStat stat = new ClampedIntStat(initialValue, minValue, maxValue);
			stat.ReduceValue(decrease);
			Assert.AreEqual(expected, stat.CurrentValue);
		}
	}
}
