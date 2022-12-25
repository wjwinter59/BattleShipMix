using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public enum BoardPart { Stearn, Midship, Bow, Buffer, Gone, Water, Nothing };

	public class Board
	{
		BoardSize battleArea; // size of the playing field
		Fleet navalFleet;
		List<Location> boardSituation;
		public BoardSize BattleArea { get { return battleArea; } }
		public Fleet NavalFleet { get { return navalFleet; } set { navalFleet = value; } }
		public Board()
		{
			battleArea = new BoardSize(6, 7);
			navalFleet = new Fleet(battleArea);
			boardSituation = navalFleet.SetSail(battleArea,  navalFleet.BattleShips);
			dbgShow(boardSituation);
		}
		public void dbgShow(List<Location> board) // Werkt wel
		{
			Location location;
			Console.WriteLine($"Fleet : \"{navalFleet.Name}\" Board situations");
			try
			{
				for (int j = 0; j < battleArea.Y; j++)
				{
					for (int i = 0; i < battleArea.X; i++)
					{
						location = board.Find(loc => (loc.X == i) & (loc.Y == j));
						if (location != null)
							//Console.Write($"{location.X},{location.Y}\t");
							Console.Write($"{location.Part}\t");
						else
							Console.Write($"?\t");
					}
					Console.WriteLine();
				}
			}
			catch
			{
				Console.Write($"Shit\t");
			}
		}
	}
}
