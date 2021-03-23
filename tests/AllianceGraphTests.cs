using NUnit.Framework;

namespace Spite.UnitTests
{
    public class AllianceGraphTests
    {

        [Test]
        public void TestUnidirectionalRelationships()
        {
            MockTeam teamA = new MockTeam();
            MockTeam teamB = new MockTeam();
            AllianceGraph graph = new AllianceGraph();
            graph.AddRelation(teamA, teamB, AllianceGraph.Relationship.Allied);
            // Make sure that only teamA and teamB have the correct relationships
            Assert.AreEqual(AllianceGraph.Relationship.Allied, graph.GetRelationship(teamA, teamB));
            Assert.AreEqual(AllianceGraph.Relationship.Unknown, graph.GetRelationship(teamB, teamA));

            // Make sure that we can't add a relationship between teams that already exists
            Assert.Throws<System.ArgumentException>(() => graph.AddRelation(teamA, teamB, AllianceGraph.Relationship.Neutral));
            // Make sure that trying to change a nonexistent relationship doesn't work
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => graph.ChangeRelationship(teamB, teamA, AllianceGraph.Relationship.Allied));

            // Make sure that changing the relationship propagates correctly
            graph.ChangeRelationship(teamA, teamB, AllianceGraph.Relationship.Neutral);
            Assert.AreEqual(AllianceGraph.Relationship.Neutral, graph.GetRelationship(teamA, teamB));
        }
    }
}