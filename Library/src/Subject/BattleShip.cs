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
		List<Location> locations; //
		Extent shipExtent;
		string name = "Boem"; //what's in a name
		int length = 0;
		bool sunk = false;
		public Extent ShipExtent { get => shipExtent; }
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
			locations = new List<Location>(); // List of locations where to place the ship on the grid. 
			shipExtent = new(locations);
		} 
		public void AddLocation(Location spot)
		{
			//if ((spot > minLoc) && (spot < maxLoc))
			{
				locations.Add(spot);
				if (locations.Count == 1)
					shipExtent.InitExtent(spot);
				else
					shipExtent.AddExtent(spot);
			} // Uitwerken op extents vergelijking ?
		}
	}
}
