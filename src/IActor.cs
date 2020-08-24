namespace Spite
{
    /// <summary>
    /// Represents an actor that can act on the battle in some way.
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// This actor's name.
        /// </summary>
        string Name { get; }
    }

    public interface IActor<TTeam> : IActor where TTeam: ITeam
    {
        /// <summary>
        /// The team this Actor covers.
        /// </summary>
        TTeam Team { get; }
    }
}
