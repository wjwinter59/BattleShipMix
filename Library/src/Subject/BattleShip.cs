using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.src.Subject
{
	public class BattleShip
	{
		List<Location> locations;
		int length = 0;
		string name = "Boem"; //what's in a name
		bool sunk = false;
		public string Name { get => name; }
		public int Length { get => length; }
		public bool Sunk { get => sunk; }
		//Oplossen met iterator
		public List<Location> Locations
		{
			get => locations;
			//set => location = value; 
		}
		public BattleShip(string name, int length)
		{
			this.name = name;
			this.length = length;
			this.sunk = false;
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
