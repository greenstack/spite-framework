namespace Spite.Events
{
    /// <summary>
    /// Contains information about the state change of the entity's tapped state.
    /// </summary>
    public class EntityTapStateChangeEventArgs : System.EventArgs
    {
        /// <summary>
        /// If the entity became tapped during this event.
        /// </summary>
        public bool BecameTapped { get; }

        /// <summary>
        /// Creates a default EntityTapStateChangeEventArgs object.
        /// </summary>
        /// <param name="becameTapped">If the entity</param>
        public EntityTapStateChangeEventArgs(bool becameTapped)
        {
            BecameTapped = becameTapped;
        }
    }
}
