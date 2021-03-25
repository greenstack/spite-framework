using System.Collections.Generic;

namespace Spite
{
	/// <summary>
	/// Provides an interface for objects that track relationships between teams.
	/// </summary>
	public interface IAllianceTracker
	{
		/// <summary>
		/// Adds the relationship directed from one team to the other. This
		/// relationship is unidirectional. To add a bidirectional 
		/// relationship, use <see cref="AddBidirectionalRelation(ITeam, ITeam, Relationship)"/>.
		/// </summary>
		/// <param name="from">The team this relationship is directed from.</param>
		/// <param name="to">The team this relationship is directed to.</param>
		/// <param name="relationship">The relationship the first team has with the other.</param>
		/// <exception cref="InvalidOperationException">Thrown if a relationship between "from" and "to" is already defined.</exception>
		void AddRelation(ITeam from, ITeam to, TeamRelationship relationship);

		/// <summary>
		/// Adds a relationship between both teams.
		/// </summary>
		/// <param name="a">One of the teams.</param>
		/// <param name="b">The other team.</param>
		/// <param name="relationship">The relationship that both of these teams have.</param>
		/// <exception cref="InvalidOperationException">Thrown if a relationship between a and b or b and a has already been defined.</exception>
		void AddBidirectionalRelation(ITeam a, ITeam b, TeamRelationship relationship);

		/// <summary>
		/// Changes the relationship directed from team A to team B.
		/// </summary>
		/// <param name="a">The team with the old relationship.</param>
		/// <param name="b">The team receiving the relationship.</param>
		/// <param name="relationship">The new relationship between teams a and b.</param>
		void ChangeRelationship(ITeam a, ITeam b, TeamRelationship relationship);

		/// <summary>
		/// Changes the relationship directed from team A to team B.
		/// </summary>
		/// <param name="a">The team whose relationship should be changed.</param>
		/// <param name="b">The team directing the relationship.</param>
		/// <param name="relationship">The new relationship.</param>
		/// <param name="oldRelationship">The old relationship between teams a and b.</param>
		void ChangeRelationship(ITeam a, ITeam b, TeamRelationship relationship, out TeamRelationship oldRelationship);

		/// <summary>
		/// Gets a single team opposing the given team.
		/// </summary>
		/// <param name="team">The team to find the opponent of.</param>
		/// <returns>The team that the given team opposes.</returns>
		ITeam GetOpposingTeam(ITeam team);

		/// <summary>
		/// Gets the relationship the from team has with the to team.
		/// </summary>
		/// <param name="from">The team directing the relationship.</param>
		/// <param name="to">The team receiving the relationship.</param>
		/// <returns>The relationship the team has with the other.</returns>
		TeamRelationship GetRelationship(ITeam from, ITeam to);

		/// <summary>
		/// Gets the relationships the team has with other teams (if they've been defined.)
		/// </summary>
		/// <param name="team">The team to get the relationships for.</param>
		/// <returns>A dictionary mapping the team with the relationship.</returns>
		Dictionary<ITeam, TeamRelationship> GetRelationships(ITeam team);

		/// <summary>
		/// Finds the teams that the given team has the given relationship with.
		/// </summary>
		/// <param name="team">The team to search for.</param>
		/// <param name="relationship">The relationship to search for.</param>
		/// <returns>The teams that the given team has the relationship with.</returns>
		IList<ITeam> GetTeamsWithRelationship(ITeam team, TeamRelationship relationship);
	}
}
