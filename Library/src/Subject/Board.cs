using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Board
	{
		BoardSize battleArea;  // 
		Fleet navalFleet;

		public BoardSize BattleArea { get { return battleArea; } }
		public Fleet NavalFleet { get { return navalFleet; } set { navalFleet = value; } }
		public Board()
		{
			battleArea = new BoardSize { x = 10, y = 10 };
			navalFleet = new Fleet();
			navalFleet.SetSail(navalFleet.BattleShips);
		}
	}
}
