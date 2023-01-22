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
		Extent extentShip;
		string name = "Boem"; //what's in a name
		int length = 0;
		bool sunk = false;
		#region Get Setters
		public Extent ExtentShip { get => GetExtent(locations); }
		public string Name { get => name; }
		public int Length { get => length; }
		public bool Sunk { get => sunk; }
		public Boolean Vertical { get { return (locations.Count > 1) ? (locations[0].X == locations[1].X) : false; } }
		public Boolean Horizontal { get { return (locations.Count > 1) ? (locations[0].Y == locations[1].Y) : false; } }
		public List<Location> Locations { get => locations; }//set => location = value; 
		#endregion
		#region Constructor(s)
		public BattleShip(string name, int length)
		{
			this.name = name;
			this.length = length;
			this.sunk = false;
			locations = new List<Location>(); // List of locations where to place the ship on the grid. 
			extentShip = new(locations);
		}
		#endregion
		public void AddLocation(Location spot)
		{
			locations.Add(spot);
		}
		/// <summary>
		/// return the location of the ship
		/// </summary>
		/// <param name="locations"></param>
		/// <returns></returns>
		Extent GetExtent(List<Location> locations)
		{
			if (locations.Count > 0)
			{
				extentShip.InitExtent(locations[0]);
				foreach (var spot in locations) // Location goes 
					extentShip.AddExtent(spot);
				return extentShip;
			}
			return new Extent() { MinX = 0, MaxX = 0, MinY = 0, MaxY = 0 };
		}
		public void Show()
		{
			if (Locations.Count != 0) {
				Console.WriteLine($"Ship :{Name}");
				Console.WriteLine($"\tExtent ship:{ExtentShip}");
				Console.WriteLine($"\tlength ship:{Length}\t");
				foreach (var loc in Locations)
					Console.WriteLine($"\tShip locations : {loc.X}, {loc.Y}, {loc.ShipPart} toString {loc.ToString()}");
			}
		}
	}
}
