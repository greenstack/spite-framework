namespace Spite
{
    /// <summary>
    /// Represents an entity that the SpiteFramework can interact with.
    /// </summary>
    public interface ITeammate
    {
        /// <summary>
        /// The team this entity belongs to.
        /// </summary>
        ITeam Team { get; }

        /// <summary>
        /// The current status of the teammate.
        /// </summary>
        /// <value></value>
        TeammateStatus Status { get; }
    }    
}
