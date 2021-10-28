using NUnit.Framework;
using Spite.Stats;

namespace Spite.UnitTests
{
	public class ModifiableIntStatTests
	{
		[Test]
		public void TestConstruction()
		{
			ModifiableIntStat mis = new ModifiableIntStat(0);
			Assert.AreEqual(0, mis.CurrentValue);
			Assert.AreEqual(0, mis.BaseValue);
		}
	}
}