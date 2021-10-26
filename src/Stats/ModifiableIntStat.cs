namespace Spite.Stats
{
	/// <summary>
	/// A stat whose values can be modified.
	/// </summary>
	public class ModifiableIntStat : IModifiableStat
	{
		/// <inheritdoc/>
		public void ReceiveModifier(IStatModifier statMod)
		{
			throw new System.NotImplementedException();
		}
	}
}
