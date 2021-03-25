using System;
using System.Collections.Generic;
using System.Linq;

namespace Spite
{
	/// <summary>
	/// Contains information regarding the relationships between teams.
	/// </summary>
	public class AllianceGraph : IRelationshipTracker
	{
		private Dictionary<(ITeam, ITeam), TeamRelationship> graph = new Dictionary<(ITeam, ITeam), TeamRelationship>();

        #region Relationship adding/changing
        /// <summary>
        /// Adds a relationship directed from the "from" team to the "to" team. This relationship is unidirectional.
		/// To add a bidirectional relationship, use <see cref="AddBidirectionalRelation(ITeam, ITeam, Relationship)"/>.
        /// </summary>
        /// <param name="from">The team this relationship originates from.</param>
        /// <param name="to">The team this relationship is directed to.</param>
        /// <param name="relationship">The relationship the first team has with the other.</param>
        /// <exception cref="InvalidOperationException">Thrown if a relationship between "from" and "to" is already defined.</exception>
        public void AddRelation(ITeam from, ITeam to, TeamRelationship relationship)
		{
			var key = (from, to);
			if (!graph.ContainsKey(key))
			{
				graph.Add(key, relationship);
			}
			else
			{
				throw new InvalidOperationException($"The relationship between {from} and {to} is already defined. Use {nameof(ChangeRelationship)} to change the relationship.");
			}
		}

		/// <summary>
		/// Adds a relationship for both teams.
		/// </summary>
		/// <param name="a">One of the teams.</param>
		/// <param name="b">The other team.</param>
		/// <param name="relationship">The relationship the teams have.</param>
		/// <exception cref="InvalidOperationException">Thrown if a relationship between a and b or b and a has already been defined.</exception>
		public void AddBidirectionalRelation(ITeam a, ITeam b, TeamRelationship relationship)
		{
			if (graph.ContainsKey((a, b)))
			{
				throw new InvalidOperationException($"A relationship between {a} and {b} has already been defined.");
			}
			else if (graph.ContainsKey((b, a))) {
				throw new InvalidOperationException($"A relationship between {b} and {a} already exists.");
			}
			AddRelation(a, b, relationship);
			AddRelation(b, a, relationship);
		}

		/// <summary>
		/// Changes the relationship between two teams.
		/// </summary>
		/// <param name="a">The team sending the relationship.</param>
		/// <param name="b">The receiving team.</param>
		/// <param name="relationship">The new relationship.</param>
		/// <exception cref="KeyNotFoundException">Thrown if a relationship between a and b isn't found.</exception>
		public void ChangeRelationship(ITeam a, ITeam b, TeamRelationship relationship)
		{
			var key = (a, b);
			if (!graph.ContainsKey(key))
            {
				// TODO: Create a custom exception for this case?
				throw new KeyNotFoundException($"Could not find a relationship between {a} and {b}");
            }

			graph[key] = relationship;
		}

		/// <summary>
		/// Changes the relationship of two teams.
		/// </summary>
		/// <param name="a">The sending team.</param>
		/// <param name="b">The receiving team.</param>
		/// <param name="relationship">The new relationship.</param>
		/// <param name="old">The old relationship.</param>
		/// <exception cref="KeyNotFoundException">Thrown if the relationship between a and b isn't found.</exception>
		public void ChangeRelationship(ITeam a, ITeam b, TeamRelationship relationship, out TeamRelationship old)
		{
			var key = (a, b);
			if (!graph.ContainsKey(key)) throw new KeyNotFoundException($"Could not find relationship between {a} and {b}");
			old = graph[key];
			graph[key] = relationship;
		}
        #endregion Relationship adding/changing

        #region Relationship queries
		/// <summary>
		/// Gets the one opposing team to the given team. It may be a good idea to cache the result.
		/// </summary>
		/// <param name="team">The team to get the opponent for.</param>
		/// <returns>The team opposing the given team.</returns>
		public ITeam GetOpposingTeam(ITeam team)
        {
			var opposingTeams = GetTeamsWithRelationship(team, TeamRelationship.Opposing);
			// The idea is that we get THE opposing team.
			if (opposingTeams.Count != 1)
            {
				throw new InvalidOperationException($"Team {team} has {(opposingTeams.Count == 0 ? "no" : "multiple")} opposing teams.");
            }
			return opposingTeams[0];
        }

        /// <summary>
        /// Gets the relationship between two teams.
        /// </summary>
        /// <param name="from">The team to get the relationship for.</param>
        /// <param name="to">The team to check.</param>
        /// <returns>The relationship between the teams. If the relationship doesn't exist, returns <see cref="Relationship.Unknown"/>.</returns>
        public TeamRelationship GetRelationship(ITeam from, ITeam to)
		{
			var key = (from, to);
			return graph.ContainsKey(key) ? graph[key] : TeamRelationship.Unknown;
		}

		/// <summary>
		/// Gets all the team relationships for the specified team.
		/// </summary>
		/// <param name="team">The team to get the relationships for.</param>
		/// <returns>A list of each team and the relationship they have with the input team.</returns>
		public Dictionary<ITeam, TeamRelationship> GetRelationships(ITeam team) {
			var relations = from r in graph
				where r.Key.Item1 == team
				select r;
			Dictionary<ITeam, TeamRelationship> relationships = new Dictionary<ITeam, TeamRelationship>(relations.Count());
			foreach (var relationship in relations)
			{
				relationships.Add(relationship.Key.Item2, relationship.Value);
			}
			return relationships;
		}

		/// <summary>
		/// For the given team, gets a list of the other teams with the specified relationship.
		/// </summary>
		/// <param name="team">The team to get.</param>
		/// <param name="relationship">The relationship to query for.</param>
		/// <returns>The teams with the given relationship to the specified team.</returns>
		public IList<ITeam> GetTeamsWithRelationship(ITeam team, TeamRelationship relationship)
		{
			var relations = from r in graph
				where r.Key.Item1 == team &&
				r.Value == relationship
				select r;
			List<ITeam> teamsWithRelationship = new List<ITeam>(relations.Count());
			foreach (var result in relations)
			{
				teamsWithRelationship.Add(result.Key.Item2);
			}
			return teamsWithRelationship;
		}
        #endregion Relationship queries
    }
}
