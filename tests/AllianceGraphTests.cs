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
            MockTeam teamA = new();
            MockTeam teamB = new();
            AllianceGraph graph = new();
            graph.AddRelation(teamA, teamB, AllianceGraph.Relationship.Allied);
            // Make sure that only teamA and teamB have the correct relationships
            Assert.AreEqual(AllianceGraph.Relationship.Allied, graph.GetRelationship(teamA, teamB));
            Assert.AreEqual(AllianceGraph.Relationship.Unknown, graph.GetRelationship(teamB, teamA));

            // Make sure that we can't add a relationship between teams that already exists
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamA, teamB, AllianceGraph.Relationship.Neutral));
            // Make sure that trying to change a nonexistent relationship doesn't work
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => graph.ChangeRelationship(teamB, teamA, AllianceGraph.Relationship.Allied));

            // Make sure that changing the relationship propagates correctly
            graph.ChangeRelationship(teamA, teamB, AllianceGraph.Relationship.Neutral);
            Assert.AreEqual(AllianceGraph.Relationship.Neutral, graph.GetRelationship(teamA, teamB));
        }

        [Test]
        public void TestAddBidirectionalRelation()
        {
            MockTeam teamA = new();
            MockTeam teamB = new();
            AllianceGraph graph = new();
            graph.AddBidirectionalRelation(teamA, teamB, AllianceGraph.Relationship.Allied);

            // Let's make sure that the relationship goes both ways
            Assert.AreEqual(AllianceGraph.Relationship.Allied, graph.GetRelationship(teamA, teamB));
            Assert.AreEqual(AllianceGraph.Relationship.Allied, graph.GetRelationship(teamB, teamA));

            // Make sure we can't add the relationships
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamA, teamB, AllianceGraph.Relationship.Allied));
            Assert.Throws<InvalidOperationException>(() => graph.AddRelation(teamB, teamA, AllianceGraph.Relationship.Allied));
        }
    }
}
