using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Board
	{
		BoardSize size;
		List<Location> fleetLocations; // hold positions of all the ships in the fleet
		public BoardSize Size { get { return size; } set { size = value; } }
		public List<Location> FleetLocations { get { return fleetLocations; } set { fleetLocations = value; } }
		public Board(int x, int y)
		{
			size = new BoardSize(x, y);
		}
	}
}
