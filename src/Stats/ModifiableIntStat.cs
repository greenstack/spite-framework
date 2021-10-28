using System.Collections.Generic;

namespace Spite.Stats
{
	/// <summary>
	/// A stat whose values can be modified.
	/// 
	/// Stat values are determined in the order that modifiers are added, so
	/// it's probably not a good idea to mix additive and multiplicative
	/// modifiers! If you really want to mix and match, you may want to
	/// implement your own modifiable int stat.
	/// </summary>
	public class ModifiableIntStat : IModifiableIntStat
	{
		List<IIntStatModifier> modifiers = new List<IIntStatModifier>();

		/// <summary>
		/// The stat's base value.
		/// </summary>
		public int BaseValue { get; set; }

		/// <inheritdoc/>
		public int CurrentValue { get; private set; }

		/// <summary>
		/// Constructs a modifiable int stat instance.
		/// </summary>
		/// <param name="baseValue">The main value that the stat centers around.</param>
		/// <param name="initialModifiers">A list of modifiers to apply immediately. If null, does nothing.</param>
		public ModifiableIntStat(int baseValue, List<IIntStatModifier> initialModifiers = null)
		{
			BaseValue = baseValue;
			CurrentValue = baseValue;
			if (initialModifiers != null)
			{
				foreach (var statMod in initialModifiers)
				{
					ReceiveModifier(statMod);
				}
			}
		}

		/// <inheritdoc/>
		public virtual void ReceiveModifier(IIntStatModifier statMod)
		{
			modifiers.Add(statMod);

			// TODO: Set the stat's current value
			CurrentValue = statMod.ModifyStat(CurrentValue);
		}

		/// <inheritdoc/>
		public virtual void RemoveModifier(IIntStatModifier statMod)
		{
			modifiers.Remove(statMod);
			// TODO: Recalculate the stat's current value.
			CurrentValue = statMod.UnmodifyStat(CurrentValue);
		}
	}
}
