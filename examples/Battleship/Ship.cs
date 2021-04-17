using System.Linq;
using Spite;

namespace Battleship
{
    struct Segment
    {
        public bool IsHit;
        readonly Ship owner;

        public Segment(Ship owner)
        {
            this.owner = owner;
            IsHit = false;
        }
    }

    public class Ship : ITeammate
    {
        internal readonly Segment[] Segments;

        public readonly string Name;

        public Ship(string name, int segmentCount)
        {
            // TODO(greenstack): Handle orientations? Or should that be in the team?
            Name = name;
            Segments = new Segment[segmentCount];
            for (int i = 0; i < segmentCount; ++i)
			{
                Segments[i] = new Segment(this);
			}
        }

        public ITeam Team { get; internal set; }

        public TeammateStatus Status => Segments.Any(s => !s.IsHit) ? TeammateStatus.Active : TeammateStatus.Defeated;
    }
}
