namespace Spite
{
    /// <summary>
    /// Represents an actor that can act on the battle in some way.
    /// </summary>
    [System.Obsolete("Use Teammates instead.")]
    public interface IActor
    {
        /// <summary>
        /// This actor's name.
        /// </summary>
        string Name { get; }
    }

    [System.Obsolete("Use Teammates instead.")]
    public interface IActor<TTeam> : IActor where TTeam: ITeam
    {
        /// <summary>
        /// The team this Actor covers.
        /// </summary>
        TTeam Team { get; }
    }
}
