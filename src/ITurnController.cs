using System;

namespace Spite
{
    /// <summary>
    /// Provides an interface for objects that control turns.
    /// </summary>
    public interface ITurnController : IComparable<ITurnController>
    {
        /// <summary>
        /// The team this controller manages.
        /// </summary>
        ITeam Team { get; }

        /// <summary>
        /// Use this to give the turn to this object.
        /// </summary>
        /// <param name="context">The context of the turn change.</param>
        void ReceiveTurn(TurnChangeContext context);

        /// <summary>
        /// Fired when this object receives the turn.
        /// </summary>
        event ReceiveTurn OnTurnReceived;

        /// <summary>
        /// Use this to pass the turn away from this object.
        /// </summary>
        /// <param name="context">The context of the turn change.</param>
        void PassTurn(TurnChangeContext context);

        /// <summary>
        /// Fired when the turn is passed.
        /// </summary>
        event PassTurn OnTurnPassed;
    }

    /// <summary>
    /// A delegate for events for when a turn is given to the team.
    /// </summary>
    /// <param name="turnRecipient">The object receiving the turn.</param>
    /// <param name="context">The context of the turn change.</param>
    public delegate void ReceiveTurn(ITurnController turnRecipient, TurnChangeContext context);

    /// <summary>
    /// A delegate for events for when a turn is passed from the team.
    /// </summary>
    /// <param name="turnPasser">The object passing the turn.</param>
    /// <param name="context">The context of the turn change.</param>
    public delegate void PassTurn(ITurnController turnPasser, TurnChangeContext context);

    /// <summary>
    /// Provides information about how the turn change is occurring.
    /// </summary>
    public class TurnChangeContext
    {
        /// <summary>
        /// The Arena the team is participating in.
        /// </summary>
        public Arena Arena { get; }

        /// <summary>
        /// The object that is passing the turn.
        /// </summary>
        public ITurnController Previous { get; }

        /// <summary>
        /// Creates a context for the change of turns.
        /// </summary>
        /// <param name="arena">The arena this is taking place in.</param>
        /// <param name="previous">The object passing the turn.</param>
        public TurnChangeContext(Arena arena, ITurnController previous)
        {
            Arena = arena;
            Previous = previous;
        }
    }
}
