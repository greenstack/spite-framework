using Spite;
using System.Collections.Generic;
using Spite.Interaction;

namespace Battleship
{
    /// <summary>
    /// A team that participates in a friendly game of battleship.
    /// </summary>
    public abstract class BattleshipTeam : ITeam<Ship>
    {
        public TeamStanding CurrentStanding { get; private set; }

        private List<Ship> ships;
        public ICollection<Ship> Members => ships;

        internal BattleshipBoard Board { get; private set; }

        public int ManagedEntityCount => Members.Count;

        public BattleshipTeam Opponent { get; internal set; }

        public void AddEntity(Ship entity)
        {
            entity.Team = this;
            Members.Add(entity);
        }

        public void PrepareBoard()
		{
            Board = new BattleshipBoard(this);
		}

        /// <summary>
        /// Gets this player's command. I don't like this, but this might be
        /// fine for now. Maybe teams have an ISpitePlayer reference, and
        /// ISpitePlayer can be notified of its turn? But why not make the team
        /// an ISpitePlayer?
        /// </summary>
        /// <returns>The command that wants to be executed.</returns>
        public abstract CommandBase GetCommand();

        public TeamStanding DetermineStanding(IArena context)
        {
            // Why can't current standing do this?
            // TODO(greenstack): This is dirty and I dislike it.
            foreach (var ship in Members)
            {
                if (ship.Status == TeammateStatus.Active)
                {
                    CurrentStanding = TeamStanding.Competing;
                    return CurrentStanding;
                }
            }
            var opponents = context.GetTeamsWithRelationship(this, TeamRelationship.Opposing);
            // This is, in particular, what I dislike. Maybe teams should
            // only _care_ about their own status, and the end of battle
            // phase should handle this? I'm not 100% sure. But part of the
            // reason I dislike this is that it relies on defeated teams being
            // updated first. Sure, I could loop over the enemy teams units as
            // well... but that opens another can of worms.
            foreach (var opponent in opponents)
            {
                if (opponent.CurrentStanding == TeamStanding.Defeated)
                {
                    CurrentStanding = TeamStanding.Victorious;
                    return CurrentStanding;
                }
            }
            return TeamStanding.Defeated;
        }

        public void ForceStanding(TeamStanding standing)
        {
            // This is needed, but how widely? Or should I make this
            // a forfeit method?
            CurrentStanding = standing;
        }

        // The parent method should probably be obsolete. I don't need this. This is more
        // for the team builder, and the team builder should be done with this anyways, I
        // think
        public void InitializeEntityCount(uint entityCount)
        {
            if (ships == null)
            {
                ships = new List<Ship>((int)entityCount);
            }
        }
    }
}