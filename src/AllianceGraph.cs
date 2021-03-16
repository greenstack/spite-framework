using System.Collections.Generic;
using System.Linq;

namespace Spite
{
	/// <summary>
	/// Contains information regarding the relationships between teams.
	/// </summary>
	public class AllianceGraph
	{
		/// <summary>
		/// Enumerates the possible relationships between teams.
		/// </summary>
		public enum Relationship
		{
			/// <summary>
			/// The team is allied with other.
			/// </summary>
			Allied,
			/// <summary>
			/// The team is neutral toward the other.
			/// </summary>
			Neutral,
			/// <summary>
			/// The team opposes the other.
			/// </summary>
			Opposing,
			/// <summary>
			/// The relationship between teams is unknown.
			/// </summary>
			Unknown,
		}

		private Dictionary<(ITeam, ITeam), Relationship> graph = new Dictionary<(ITeam, ITeam), Relationship>();

		public void AddRelation(ITeam from, ITeam to, Relationship relationship)
		{
			var key = (from, to);
			if (!graph.ContainsKey(key))
			{
				graph.Add(key, relationship);
			}
			else
			{
				throw new System.ArgumentException($"The relationship between {from} and {to} is already defined. Use {nameof(ChangeRelationship)} to change the relationship.");
			}
		}

		public void AddBidirectionalRelation(ITeam a, ITeam b, Relationship relationship)
		{
			AddRelation(a, b, relationship);
			AddRelation(b, a, relationship);
		}

		/// <summary>
		/// Changes the relationship between two teams.
		/// </summary>
		/// <param name="a">The team sending the relationship.</param>
		/// <param name="b">The receiving team.</param>
		/// <param name="relationship">The new relationship.</param>
		public void ChangeRelationship(ITeam a, ITeam b, Relationship relationship)
		{
			graph[(a, b)] = relationship;
		}

		/// <summary>
		/// Changes the relationship of two teams.
		/// </summary>
		/// <param name="a">The sending team.</param>
		/// <param name="b">The receiving team.</param>
		/// <param name="relationship">The new relationship.</param>
		/// <param name="old">The old relationship.</param>
		public void ChangeRelationship(ITeam a, ITeam b, Relationship relationship, out Relationship old)
		{
			var key = (a, b);
			old = graph[key];
			graph[key] = relationship;
		}

		/// <summary>
		/// Gets the relationship between two teams.
		/// </summary>
		/// <param name="from">The team to get the relationship for.</param>
		/// <param name="to">The team to check.</param>
		/// <returns></returns>
		public Relationship GetRelationship(ITeam from, ITeam to)
		{
			var key = (from, to);
			return graph.ContainsKey(key) ? graph[key] : Relationship.Unknown;
		}

		/// <summary>
		/// Gets all the team relationships for the specified team.
		/// </summary>
		/// <param name="team">The team to get the relationships for.</param>
		/// <returns>A list of each team and the relationship they have with the input team.</returns>
		public Dictionary<ITeam, Relationship> GetRelationships(ITeam team) {
			var relations = from r in graph
				where r.Key.Item1 == team
				select r;
			Dictionary<ITeam, Relationship> relationships = new Dictionary<ITeam, Relationship>(relations.Count());
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
		public List<ITeam> GetTeamsWithRelationship(ITeam team, Relationship relationship)
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
	}
}
