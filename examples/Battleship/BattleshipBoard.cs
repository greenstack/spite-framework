using System;
using System.Text;

namespace Battleship
{
	class BattleshipBoard
	{
		public const int BOARD_SIZE = 10;
		readonly Segment[,] board = new Segment[BOARD_SIZE, BOARD_SIZE];
		readonly BattleshipTeam team;

		public BattleshipBoard(BattleshipTeam team)
		{
			Random r = new Random(0);
			this.team = team;
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
			for (int i = 0; i < BOARD_SIZE; ++i)
				for (int j = 0; j < BOARD_SIZE; ++j)
					if (board[i, j] == null) board[i, j] = new Segment(null);
		}

		public static bool IsOnBoard(int x, int y)
		{
			return (0 <= x && x < BOARD_SIZE)
				&& (0 <= y && y < BOARD_SIZE);
		}

		public string ToString(BattleshipTeam viewpoint)
		{
			StringBuilder sb = new StringBuilder();
			for (int y = 0; y < BOARD_SIZE; ++y)
			{
				for (int x = 0; x < BOARD_SIZE; ++x)
				{
					// TODO: figure out difference between hits, misses, etc.
					Segment s = board[x, y];

					if (s.Owner == null)
					{
						if (!s.IsHit)
						{
							sb.Append('w');
						}
						else
						{
							sb.Append('X');
						}
					}
					else
					{
						if (s.IsHit)
						{
							sb.Append('O');
						}
						else if (team == viewpoint)
						{
							sb.Append('v');
						}
						else
						{
							sb.Append('w');
						}
					}
				}
				sb.Append('\n');
			}
			return sb.ToString();
		}
		
		public bool IsLocationHit(int x, int y)
		{
			if (!IsOnBoard(x, y))
				throw new ArgumentOutOfRangeException($"x ({x}) or y ({y}) is out of range (min 0, max {BOARD_SIZE})");

			return board[x, y].IsHit;
		}
		
		public Ship Attack(int x, int y)
		{
			if (!IsOnBoard(x, y))
				throw new ArgumentOutOfRangeException($"x ({x}) or y ({y}) is out of range (min 0, max {BOARD_SIZE})");

			if (board[x, y].IsHit == true)
			{
				throw new InvalidOperationException($"Cannot hit a place that has already been attacked ({x}, {y})");
			}
			else
			{
				board[x, y].IsHit = true;
			}

			return board[x, y].Owner;
		}
	}

}
