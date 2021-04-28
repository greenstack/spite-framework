#if !UNITY_EDITOR
using NUnit.Framework;
using System;

namespace Spite.UnitTests
{
    public class AllianceGraphTests
    {
        /// <summary>
        /// Tests adding a single relationship. Also tests the GetRelationship method as a result.
        /// </summary>
        [Test]
        public void TestUnidirectionalRelationships()
        {
            MockTeam teamA = new MockTeam();
            MockTeam teamB = new MockTeam();
            AllianceGraph graph = new AllianceGraph();
            graph.AddRelation(teamA, teamB, TeamRelationship.Allied);
            // Make sure that only teamA and teamB have the correct relationships
            Assert.AreEqual(TeamRelationship.Allied, graph.GetRelationship(teamA, teamB));
            Assert.AreEqual(TeamRelationship.Unknown, graph.GetRelationship(teamB, teamA));

            // Make sure that we can't add a relationship between teams that already exists
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamA, teamB, TeamRelationship.Neutral));
            // Make sure that trying to change a nonexistent relationship doesn't work
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => graph.ChangeRelationship(teamB, teamA, TeamRelationship.Allied));

            // Make sure that changing the relationship propagates correctly
            graph.ChangeRelationship(teamA, teamB, TeamRelationship.Neutral);
            Assert.AreEqual(TeamRelationship.Neutral, graph.GetRelationship(teamA, teamB));
        }

        /// <summary>
        /// Test methods with adding a bidirectional relationship.
        /// </summary>
        [Test]
        public void TestAddBidirectionalRelation()
        {
            MockTeam teamA = new MockTeam();
            MockTeam teamB = new MockTeam();
            AllianceGraph graph = new AllianceGraph();
            graph.AddBidirectionalRelation(teamA, teamB, TeamRelationship.Allied);

            // Let's make sure that the relationship goes both ways
            Assert.AreEqual(TeamRelationship.Allied, graph.GetRelationship(teamA, teamB));
            Assert.AreEqual(TeamRelationship.Allied, graph.GetRelationship(teamB, teamA));

            // Make sure we can't add the relationships
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamA, teamB, TeamRelationship.Allied));
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamB, teamA, TeamRelationship.Allied));
        }

        /// <summary>
        /// Tests the get opposing team method. For now, this suffices for testing GetTeamsWithRelationship.
        /// </summary>
        [Test]
        public void TestGetOpposingTeam()
        {
            MockTeam teamA = new MockTeam();
            MockTeam teamB = new MockTeam();
            AllianceGraph graph = new AllianceGraph();
            graph.AddBidirectionalRelation(teamA, teamB, TeamRelationship.Opposing);
            var opposingTeam = graph.GetOpposingTeam(teamA);
            Assert.AreEqual(teamB, opposingTeam);
            graph.ChangeRelationship(teamA, teamB, TeamRelationship.Neutral);
            Assert.Throws<InvalidOperationException>(()=>graph.GetOpposingTeam(teamA));
            graph.ChangeRelationship(teamA, teamB, TeamRelationship.Opposing);
            graph.AddRelation(teamA, new MockTeam(), TeamRelationship.Opposing);
            Assert.Throws<InvalidOperationException>(() => graph.GetOpposingTeam(teamA));
        }

        /// <summary>
        /// Tests the get relationships method.
        /// </summary>
        [Test]
        public void TestGetRelationships()
        {
            MockTeam teamA = new MockTeam();
            MockTeam teamB = new MockTeam();
            MockTeam teamC = new MockTeam();

            var graph = new AllianceGraph();
            graph.AddRelation(teamA, teamB, TeamRelationship.Allied);
            graph.AddRelation(teamA, teamC, TeamRelationship.Neutral);

            var relationships = graph.GetRelationships(teamA);
            foreach (var relationship in relationships)
            {
                if (relationship.Key == teamB)
                    Assert.AreEqual(TeamRelationship.Allied, relationship.Value);
                if (relationship.Key == teamC)
                    Assert.AreEqual(TeamRelationship.Neutral, relationship.Value);
            }
        }
    }
}
#endif
