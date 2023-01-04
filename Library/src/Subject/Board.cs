using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Board
	{
		BoardSize size;
		List<Location> shipLocations; // hold positions of all the ships in the fleet
		public BoardSize Size { get { return size; } set { size = value; } }
		public List<Location> ShipLocations { get { return shipLocations; } set { shipLocations = value; } }
		public Board(Fleet fleet) { 
		}

		public Board(int x, int y)
		{
			size = new BoardSize(x, y);
		}
	}
}
