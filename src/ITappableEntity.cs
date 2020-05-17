using Spite.Events;
using System;

namespace Spite
{
    /// <summary>
    /// Used to make an object tappable or untappable.
    /// </summary>
    public interface ITappable
    {
        /// <summary>
        /// Whether or not this object is tapped.
        /// </summary>
        bool IsTapped { get; set; }

        /// <summary>
        /// An event that is fired when Tap and Untap are called successfully.
        /// </summary>
        TapStateChange OnTapOrUntap { get; set; }
    }

    /// <summary>
    /// Provides various methods to objects that implement ITappable.
    /// </summary>
    public static class ITappableMethodProvider
    {
        /// <summary>
        /// Taps the tappable object.
        /// </summary>
        /// <param name="tappable">The tappable being tapped.</param>
        /// <returns>True of the tappable is tapped.</returns>
        public static bool Tap(this ITappable tappable)
        {
            if (tappable == null)
            {
                throw new ArgumentNullException(nameof(tappable));
            }
            if (tappable.IsTapped) return false;

            tappable.IsTapped = true;
            tappable.OnTapOrUntap.Raise(tappable, new EntityTapStateChangeEventArgs(true));
            return true;
        }

        /// <summary>
        /// Untaps the tappable.
        /// </summary>
        /// <param name="tappable">The tappable being untapped.</param>
        /// <returns>True if the tappable is untapped. Otherwise, false.</returns>
        public static bool Untap(this ITappable tappable)
        {
            if (tappable == null)
            {
                throw new ArgumentNullException(nameof(tappable));
            }
            if (!tappable.IsTapped) return false;

            tappable.IsTapped = false;
            tappable.OnTapOrUntap.Raise(tappable, new EntityTapStateChangeEventArgs(false));
            return true;
        }

        private static void Raise(this TapStateChange handler, ITappable sender, EntityTapStateChangeEventArgs args)
        {
            handler?.Invoke(sender, args);
        }
    }

    /// <summary>
    /// A delegate to call when an entity is tapped or untapped.
    /// </summary>
    /// <param name="sender">The entity whose state was changed.</param>
    /// <param name="args">Contextual information about the state change.</param>
    public delegate void TapStateChange(ITappable sender, EntityTapStateChangeEventArgs args);
}
