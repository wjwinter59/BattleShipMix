using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Board
	{
		String name=new String("Battleship game");
		Extent boardExtent;
		/// <summary>
		/// Geen idee waarom dit hier zou moeten worden geregistreerd.
		/// </summary>
		List<Location> shipLocations; // hold positions of all the ships in the fleet 
		public String Name { get =>name; }
		public Extent BoardExtent { get { return boardExtent; } set { boardExtent = value; } }
		public List<Location> ShipLocations { get { return shipLocations; } set { shipLocations = value; } }
		public Board(int x, int y)
		{
			boardExtent = new Extent() { MinX = 0, MaxX = x, MinY = 0, MaxY = y };
		}
	}
}
