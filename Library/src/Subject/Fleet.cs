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
		/// <summary>
		/// Build list of locations retrieved from  all Battleships locations
		/// in order to process them all in once
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		public Boolean SetSail(List<BattleShip> fleet)
		{
			List<Location> shipLocations;   // List Occupied places
			List<Location> availableSpaces; // List available spaces
			foreach (var ship in fleet)
			{
				shipLocations = FindOccupied(fleet);
				Show(shipLocations);
				availableSpaces = GetEmptySpots(shipLocations, ship);
			}
			return true;
		}
		List<Location> FindOccupied(List<BattleShip> fleet)
		{
			List<Location> locationList = new();
			List<Location> bufferList = new();
			foreach (var ship in fleet)
				locationList.AddRange(ship.Locations);
			// Create buffer around locationList and return 
			bufferList = Buffer(locationList);
			locationList.AddRange(bufferList);
			return locationList;
		}
		
		/// <summary>
		/// create bufferlocations around locations that are occupied by shipparts.
		/// Game rule states that ships are not allowed to touch each other.
		/// This wil 
		/// </summary>
		/// <param name="location"></param>
		List<Location> Buffer(List<Location> locations)
		{
			List<Location> newBuffer = new();
			foreach (var loc in locations)
				SetBuffer(locations, newBuffer, loc);
			Show(newBuffer);
			return newBuffer;
		}
		/// <summary>
		/// Create a buffer of 'bufValue' around a ships location, appart from alreaday occupied locations
		/// 
		/// Dit moet anders kunnen :)
		/// </summary>
		/// <param name="part"></param>
		/// <param name="bufValue"></param>
		/// <returns></returns>
		List<Location> SetBuffer(List<Location> locations, List<Location> buffer,  Location loc)
		{
			//List<Location> tmpBuffer = new();
			/// Gevonden kocaties waar een 'Overboard' wordt geplaatst kan niet direct in de bron worden opgenomen
			/// deze is in gebruik door het FindOccupied method. 
			/// deze wordt dan invalid.
			if ((GetLocation(locations, loc.X - 1, loc.Y - 1) == null) & (GetLocation(buffer, loc.X - 1, loc.Y - 1) == null))
				buffer.Add(new Location(loc.X - 1, loc.Y - 1, ShipPart.Overboard));
			if ((GetLocation(locations, loc.X + 0, loc.Y - 1) == null) & (GetLocation(buffer, loc.X + 0, loc.Y - 1) == null))
				buffer.Add(new Location(loc.X + 0, loc.Y - 1, ShipPart.Overboard));
			if ((GetLocation(locations, loc.X + 1, loc.Y - 1) == null) & (GetLocation(buffer, loc.X + 1, loc.Y - 1) == null))
				buffer.Add(new Location(loc.X + 1, loc.Y - 1, ShipPart.Overboard));

			if ((GetLocation(locations, loc.X - 1, loc.Y) == null) & 
					(GetLocation(buffer, loc.X - 1, loc.Y) == null))
				buffer.Add(new Location(loc.X - 1, loc.Y, ShipPart.Overboard));
			if ((GetLocation(locations, loc.X + 1, loc.Y) == null) & 
					(GetLocation(buffer, loc.X + 1, loc.Y) == null))
				buffer.Add(new Location(loc.X + 1, loc.Y, ShipPart.Overboard));

			if ((GetLocation(locations, loc.X - 1, loc.Y + 1) == null) & (GetLocation(buffer, loc.X - 1, loc.Y + 1) == null))
				buffer.Add(new Location(loc.X - 1, loc.Y + 1, ShipPart.Overboard));
			if ((GetLocation(locations, loc.X + 0, loc.Y + 1) == null) & (GetLocation(buffer, loc.X + 0, loc.Y + 1) == null))
				buffer.Add(new Location(loc.X + 0, loc.Y + 1, ShipPart.Overboard));
			if ((GetLocation(locations, loc.X + 1, loc.Y + 1) == null) & (GetLocation(buffer, loc.X + 1, loc.Y + 1) == null))
				buffer.Add(new Location(loc.X + 1, loc.Y + 1, ShipPart.Overboard));

			return buffer;
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
			//locations.Sort();
			return tmpEmpty;
		}
		public void Show(List<BattleShip> fleet)
		{
			foreach (BattleShip ship in fleet)
			{
				Console.Write($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
				foreach (var part in ship.Locations)
					Console.Write($"Locations : {part.X},{part.Y},{part.Part}");
				Console.WriteLine("");
			}
		}

		void Show(List<Location> locations)
		{
			foreach (var loc in locations)
					Console.WriteLine($"{loc.X}, {loc.Y}, {loc.Part}");
			Console.WriteLine();
		}
	}
}
