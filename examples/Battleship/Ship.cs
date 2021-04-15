using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spite;

namespace Battleship
{
    public class Ship : ITeammate
    {
        private struct Segment
        {
            public bool IsHit;
        }

        readonly Segment[] Segments;

        public readonly string Name;

        public Ship(string name, int segmentCount)
        {
            // TODO(greenstack): Handle orientations? Or should that be in the team?
            Name = name;
            Segments = new Segment[segmentCount];
        }

        public ITeam Team { get; internal set; }

        public TeammateStatus Status => Segments.Any(s => !s.IsHit) ? TeammateStatus.Active : TeammateStatus.Defeated;
    }
}
