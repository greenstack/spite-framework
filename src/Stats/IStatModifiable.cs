/**
 * This interface is here because either Teammates or Stats can have modifiers
 * attached to them. The class that implements the stat modifiers can use this
 * appropriately.
 */

namespace Spite.Stats
{
	/// <summary>
	/// Represents an item that can receive stat modifiers.
	/// </summary>
	public interface IStatModifiable
	{
		/// <summary>
		/// Adds the modifier to this object.
		/// </summary>
		/// <param name="modifier">The modifier to attach to the object.</param>
		void AddModifier(IStatModifier modifier);

		/// <summary>
		/// Removes 
		/// </summary>
		/// <param name="modifier">The modifier to check for.</param>
		void RemoveStatModifier(IStatModifier modifier);

		/// <summary>
		/// Checks if this entity has a modifier attached to it.
		/// </summary>
		/// <param name="modifier">The modifier to check for.</param>
		/// <returns>True if this entity has the given modifier.</returns>
		bool HasModifier(IStatModifier modifier);
	}
}
