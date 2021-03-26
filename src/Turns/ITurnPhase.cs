namespace Spite.Turns
{
    /// <summary>
    /// Represents a phase in a turn. These should be managed by the turn
    /// manager, and act as the manager's state.
    /// </summary>
    public interface ITurnPhase
    {
        /// <summary>
        /// Changes the phase. Should invoke the <see cref="OnPhaseChanged"/> event.
        /// </summary>
        /// <param name="manager">The turn manager this phase belongs to.</param>
        void ChangePhase(ITurnManager manager);

        /// <summary>
        /// Triggered when a phase changes.
        /// </summary>
        event ChangePhase OnPhaseChanged;
    }

    /// <summary>
    /// A delegate to be called when a turn's phase changes.
    /// </summary>
    /// <param name="fromPhase">The phase being transitioned from.</param>
    /// <param name="toPhase">The phase being transitioned to.</param>
    /// <param name="turnManager">The turn manager.</param>
    public delegate void ChangePhase(ITurnPhase fromPhase, ITurnPhase toPhase, ITurnManager turnManager);
}
