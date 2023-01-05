using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Xml;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class BattleShip
	{
		List<Location> locations;
		Extent extent;
		string name = "Boem"; //what's in a name
		int length = 0;
		bool sunk = false;
		Location minLoc;
		Location maxLoc;
		#region
		public string Name { get => name; }
		public int Length { get => length; }
		public bool Sunk { get => sunk; }
		public List<Location> Locations
		{
			get => locations;
			//set => location = value; 
		}
		#endregion
		public BattleShip(string name, int length)
		{
			this.name = name;
			this.length = length;
			this.sunk = false;
			locations = new List<Location>(); // List of locations when placed on the grid. 
			extent = new(locations);
		}

		public void AddLocation(Location spot)
		{
			if ((spot > minLoc) && (spot < maxLoc)) // Uitwerken op extents vergelijking ?
				extent.AddExtent(spot);
		}
		public void Show()
		{
			Console.Write("Extent ship :");
			extent.Show();
			Console.WriteLine($"Name: {Name}");
			Console.Write($"Locations : ");
			foreach (var location in Locations)
				Console.Write($"x: {location.X} y: {location.Y} ");
		}
	}
}
