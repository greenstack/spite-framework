namespace Spite.Stats
{
	/// <summary>
	/// Represents a stat that hovers around a specific value.
	/// 
	/// Use this if the stat itself contains the modifiers and not the unit.
	/// </summary>
	/// <typeparam name="T">The numeric type used for the stat.</typeparam>
	interface IModifiableStat<T> : IStat<T> where T :
		System.IComparable<T>,
		System.IEquatable<T>
	{
		/// <summary>
		/// Registers the stat modifier directly to the stat.
		/// </summary>
		/// <param name="modifier">The modifier to add to the stat.</param>
		void AddModifier(IStatModifier modifier);

		/// <summary>
		/// Checks if the stat is being affected by the given modifier.
		/// </summary>
		/// <param name="modifier">The modifier to check for.</param>
		/// <returns>True if the modifier is currently affecting this stat.</returns>
		bool HasModifier(IStatModifier modifier);

		/// <summary>
		/// Removes the modifier from the stat.
		/// </summary>
		/// <param name="modifier">The modifier to remove.</param>
		void RemoveModifier(IStatModifier modifier);
	}
}
