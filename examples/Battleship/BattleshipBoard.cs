using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
	class BattleshipBoard
	{
		const int BOARD_SIZE = 10;
		readonly Segment[,] board = new Segment[BOARD_SIZE, BOARD_SIZE];

		public BattleshipBoard(BattleshipTeam team)
		{
			Random r = new Random(0);

			// TODO: Randomize placement of ships and their rotation
			foreach (var ship in team.Members)
			{
				// 0: Horizontal
				// 1: Vertical
				int orientation = r.Next() % 2;
				int rootX, rootY;
				(int, int) offset;
				if (orientation == 0)
				{
					rootX = r.Next(10 - ship.Segments.Length);
					rootY = r.Next(10);
					offset = (1, 0);
				}
				else if (orientation == 1)
				{
					rootX = r.Next(10);
					rootY = r.Next(10 - ship.Segments.Length);
					offset = (0, 1);
				}
				else
				{
					throw new Exception("Oops");
				}

				foreach (Segment s in ship.Segments)
				{
					board[rootX, rootY] = s;
					rootX += offset.Item1;
					rootY += offset.Item2;
				}
			}
		}

		public static bool IsOnBoard(int x, int y)
		{
			return (0 <= x && x < BOARD_SIZE)
				&& (0 <= y && y < BOARD_SIZE);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < BOARD_SIZE; ++i)
			{
				for (int j = 0; j < BOARD_SIZE; ++j)
				{
					// TODO: figure out difference between hits, misses, etc.
					Segment s = board[i, j];
					if (s == null)
					{
						sb.Append('w');
					}
					else if (s.IsHit)
					{
						sb.Append('O');
					}
					else
					{
						sb.Append('X');
					}
				}
			}
			return sb.ToString();
		}
		public void Attack(int x, int y)
		{
			if (!IsOnBoard(x, y))
				throw new ArgumentOutOfRangeException($"x ({x}) or y ({y}) is out of range (min 0, max {BOARD_SIZE})");

			
		}
	}

}
