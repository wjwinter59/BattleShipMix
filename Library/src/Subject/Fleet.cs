using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Fleet
	{
		string name = "Default ships";
		List<BattleShip> battleShips;
		public List<BattleShip> BattleShips { get => battleShips; set => battleShips = value; }
		List<BattleShip> dummy = new List<BattleShip>{
																new BattleShip("Carrier", 5),
																new BattleShip("Battleship", 4),
																new BattleShip("Destroyer", 3),
																new BattleShip("Submarine", 3),
																new BattleShip("Patrolboat", 2)
												};
		public Fleet()
		{
		battleShips = new List<BattleShip>();
		
			battleShips = dummy;
						//Test gevalletje !
			battleShips[3].Locations.Add(new Location(2, 2, ShipPart.Stearn));
			battleShips[3].Locations.Add(new Location(3, 2, ShipPart.Midship));
			battleShips[3].Locations.Add(new Location(4, 2, ShipPart.Bow));
		
		}
		public Fleet(string name, List<BattleShip> battleShips)
		{
			this.name = name;
			this.battleShips = battleShips;
		}
		public void Show()
		{
			BattleShip vessel;
			foreach (var ship in battleShips)
			{
				Console.Write($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
				vessel = ship;
				foreach (var part in vessel.Locations)
					Console.Write($": {part.X},{part.Y}");
				Console.WriteLine("");
			}
		}
		public Boolean SetSail(List<BattleShip> fleet)
		{
			List<Location> los;   // List Occupied places
			List<Location> las; // List available spaces
			foreach (var ship in fleet)
			{
				los = FindOccupied(fleet);
				Show(los);
				las = GetEmptySpots(los, ship);
			}
			return true;
		}
		/// <summary>
		/// Build list of locations retrieved from  all Battleships
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		List<Location> FindOccupied(List<BattleShip> fleet)
		{
			List<Location> tmpList = new();
			foreach (var ship in fleet)
				tmpList.AddRange(ship.Locations);
			// Create buffer around locations and return 
			tmpList.AddRange(Buffer(tmpList));
			return tmpList;
		}
		/// <summary>
		/// create bufferlocations around locations that are occupied by shipparts.
		/// Game rule states that ships are not allowed to touch each other.
		/// This wil 
		/// </summary>
		/// <param name="location"></param>
		List<Location> Buffer(List<Location> locations)
		{
			List<Location> tmpBuffer = new();
			foreach (var loc in locations)
			{
				tmpBuffer.AddRange(SetBuffer(locations, loc));
			}
			locations.AddRange(tmpBuffer);
			return locations;
		}
		/// <summary>
		/// Create a buffer of 'bufValue' around a ships location, appart from alreaday occupied locations
		/// </summary>
		/// <param name="part"></param>
		/// <param name="bufValue"></param>
		/// <returns></returns>
		List<Location> SetBuffer(List<Location> locations, Location loc)
		{
			List<Location> tmpBuffer = new();

			if (GetLocation(locations, loc.X - 1, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X - 1, loc.Y - 1, ShipPart.Overboard));
			if (GetLocation(locations, loc.X + 0, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X + 0, loc.Y - 1, ShipPart.Overboard));
			if (GetLocation(locations, loc.X + 1, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X + 1, loc.Y - 1, ShipPart.Overboard));

			if (GetLocation(locations, loc.X - 1, loc.Y) == null)
				tmpBuffer.Add(new Location(loc.X - 1, loc.Y, ShipPart.Overboard));
			if (GetLocation(locations, loc.X + 1, loc.Y) == null)
				tmpBuffer.Add(new Location(loc.X + 1, loc.Y, ShipPart.Overboard));

			if (GetLocation(locations, loc.X - 1, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X - 1, loc.Y - 1, ShipPart.Overboard));
			if (GetLocation(locations, loc.X + 0, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X + 0, loc.Y - 1, ShipPart.Overboard));
			if (GetLocation(locations, loc.X + 1, loc.Y - 1) == null)
				tmpBuffer.Add(new Location(loc.X + 1, loc.Y - 1, ShipPart.Overboard));

			return tmpBuffer;
		}
		Location GetLocation(List<Location> locations, Location location)
		{
			var response = locations.Find(loc => (loc.X == location.X) & (loc.Y == location.Y));
			return response;
		}
		Location GetLocation(List<Location> locations, int x, int y)
		{
			return locations.Find(loc => (loc.X == x) & (loc.Y == y));
		}
		/// <summary>
		/// Create a list of apaces that wil fit the current schip.
		/// </summary>
		/// <param name="locations"></param>
		/// <returns></returns>
		List<Location> GetEmptySpots(List<Location> locations, BattleShip ship)
		{
			List<Location> tmpEmpty = new();
			// locations.Sort();
			return tmpEmpty;
		}
		void Show(List<Location> locations)
		{
			foreach (var loc in locations)
			{
			if (loc != null)
				Console.Write($"{loc.X}, {loc.Y}, {loc.Part}");
			}
			Console.WriteLine();
		}
	}
}
