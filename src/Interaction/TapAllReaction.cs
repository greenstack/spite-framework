namespace Spite.Interaction
{
	/// <summary>
	/// The reaction for a commmand that tapped all units.
	/// </summary>
	public class TapAllReaction : IReaction
	{
		/// <inheritdoc/>
		public ISpiteAction FollowUpAction => null;

		/// <inheritdoc/>
		public bool ActionSuccessful => true;

		/// <inheritdoc/>
		public object GetReactionData()
		{
			return this;
		}

		/// <inheritdoc/>
		public TReactionData GetReactionData<TReactionData>()
		{
			return default;
		}
	}
}
