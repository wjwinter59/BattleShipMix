using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class BattleShip
	{
		List<Location> locations;
		int length = 0;
		string name = "Boem"; //what's in a name
		bool sunk = false;
		Location minLoc;
		Location maxLoc;
		BoardSize boardSize;
		public string Name { get => name; }
		public int Length { get => length; }
		public bool Sunk { get => sunk; }
		//Oplossen met iterator
		public List<Location> Locations
		{
			get => locations;
			//set => location = value; 
		}
		public void AddLocation(Location spot)
		{
			if ((spot > minLoc) && (spot < maxLoc))
				locations.Add(spot);
		}
		public BattleShip(string name, int length) {
			this.name = name;
			this.length = length;
			this.sunk = false;
		}
		public BattleShip(BoardSize boardSize,  string name, int length)
		{
			this.name = name;
			this.length = length;
			this.sunk = false;
			this.boardSize=boardSize;
			this.minLoc = new Location() { X = -1, Y = -1 };
			this.maxLoc = new Location() { X = boardSize.X, Y = boardSize.Y };
			locations = new List<Location>(); // List of locations when placed on the grid. 
		}
		public void Show()
		{
			Console.WriteLine($"Name: {Name}");
			Console.Write($"Locations : ");
			foreach (var location in Locations)
				Console.Write($"x: {location.X} y: {location.Y} ");
		}
	}
}
