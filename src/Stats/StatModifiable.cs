using System.Collections.Generic;

namespace Spite.Stats
{
  /// <summary>
  /// A basic class that can handle stat modifications out of the box.
  /// </summary>
  public class StatModifiable : IStatModifiable
  {

		private List<IStatModifier> statModifiers = new List<IStatModifier>();

		/// <inheritdoc/>
    public void AddModifier(IStatModifier modifier)
    {
      statModifiers.Add(modifier);
    }

		/// <inheritdoc/>
    public bool HasModifier(IStatModifier modifier)
    {
      return statModifiers.Contains(modifier);
    }

		/// <inheritdoc/>
    public void RemoveStatModifier(IStatModifier modifier)
    {
      statModifiers.Remove(modifier);
    }
  }
}
