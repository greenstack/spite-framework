using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEngine;
#endif

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
	[Serializable]
	public class ModifiableIntStat : IModifiableIntStat
	{
		List<IIntStatModifier> modifiers = new List<IIntStatModifier>();

#if UNITY_EDITOR
		[SerializeField]
		private int baseValue;

		/// <summary>
		/// The stat's base value.
		/// </summary>
		public int BaseValue { get => baseValue; set => baseValue = value; }

		[SerializeField]
		private int currentValue;

		/// <inheritdoc/>
		public int CurrentValue { get => currentValue; set => currentValue = value; }
#else
		/// <summary>
		/// The stat's base value.
		/// </summary>
		public int BaseValue { get; set; }

		/// <inheritdoc/>
		public int CurrentValue { get; private set; }
#endif

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
		public void ReceiveModifier(IIntStatModifier statMod)
		{
			modifiers.Add(statMod ?? throw new ArgumentNullException(nameof(statMod)));

			// TODO: Set the stat's current value
			CurrentValue = statMod.ModifyStat(CurrentValue);
		}

		/// <inheritdoc/>
		public void RemoveModifier(IIntStatModifier statMod)
		{
			modifiers.Remove(statMod ?? throw new ArgumentNullException(nameof(statMod)));
			// TODO: Recalculate the stat's current value.
			CurrentValue = statMod.UnmodifyStat(CurrentValue);
		}
	}
}
