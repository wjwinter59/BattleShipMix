using System;
using System.Collections.Generic;
using System.Text.Json;

using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Fleet
	{
		string name = "Default ships";

		List<BattleShip> battleShips = new List<BattleShip>();
		List<Location> shipLocations; // Useful for calculations, the extent of the fleet for exmpl
		List<Location> bufferLocations;
		private Extent extentFleet;

		List<BattleShip> EnglishFleet = new List<BattleShip>{
				new BattleShip("Carrier", 5),
				new BattleShip("Battleship", 4),
				new BattleShip("Destroyer", 3),
				new BattleShip("Submarine", 3),
				new BattleShip("Patrolboat", 2)
		};
		#region GetSet ers
		public List<BattleShip> BattleShips { get => battleShips; set => battleShips = value; }
		public List<Location> ShipLocations { get => shipLocations; }
		public string Name { get => name; set => name = value; }
		public Extent ExtentFleet { get => extentFleet; set => extentFleet = value; }
		#endregion
		#region Constructors
		public Fleet()
		{
			this.battleShips = EnglishFleet;
			//Test cases !Fill in some parts
			battleShips[3].AddLocation(new Location(0, 2, ShipPart.Stearn));
			battleShips[3].AddLocation(new Location(0, 3, ShipPart.Midship));
			battleShips[3].AddLocation(new Location(0, 4, ShipPart.Midship));
			battleShips[3].AddLocation(new Location(0, 5, ShipPart.Bow));
			battleShips[1].AddLocation(new Location(0, 1, ShipPart.Bow));
			battleShips[1].AddLocation(new Location(1, 1, ShipPart.Midship));
			battleShips[1].AddLocation(new Location(2, 1, ShipPart.Bow));
			//shipLocations = GetShipLocations(battleShips);
			extentFleet = new(GetShipLocations(battleShips));
		}
		public Fleet(Fleet fleet)
		{
			// Test case
			if (fleet.Name == "")
				this.name = "English ships";
			if (fleet.battleShips.Count == 0)
				battleShips = EnglishFleet;
			else
				battleShips = fleet.battleShips;

			battleShips[1].Locations.Add(new Location(0, 1, ShipPart.Bow));
			battleShips[1].Locations.Add(new Location(1, 1, ShipPart.Midship));
			battleShips[1].Locations.Add(new Location(2, 1, ShipPart.Bow));
			battleShips[3].Locations.Add(new Location(0, 2, ShipPart.Stearn));
			battleShips[3].Locations.Add(new Location(0, 3, ShipPart.Midship));
			battleShips[3].Locations.Add(new Location(0, 4, ShipPart.Bow));

			string jsonBattlaships = JsonSerializer.Serialize(battleShips); // Test thingy
			shipLocations = GetShipLocations(battleShips);
			extentFleet = new(shipLocations);
		}
		public Fleet(string name, List<BattleShip> battleShips)
		{
			this.name = name;
			shipLocations = GetShipLocations(battleShips);
			extentFleet = new(shipLocations);
		}
		#endregion
		/// <summary>
		/// Build list of locations that are part of all Battleships, 
		/// in order to process them in a uniform way
		/// 
		public List<Location> GetShipLocations(List<BattleShip> battleShips)
		{
			List<Location> locationList = new();
			foreach (var ship in battleShips)
				locationList.AddRange(ship.Locations);
			return locationList;
		}
		/// create buffers arround the schips to build a list of occupied locations (boardSituation)
		/// This can be used to pllace the ships in the constructor of a new observer.
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		public List<Location> BufferShips(List<BattleShip> fleet)
		{
			Buffer Buffers = new Buffer(fleet);
			bufferLocations = Buffers.Locations;
			return bufferLocations;
		}
		/// <summary>
		/// Create a complete list of locations that contain ship parts 
		///		and a buffer around them.
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		List<Location> FindOccupied(Fleet fleet)
		{
			// Hier stond het genereren van een lijst shiplocations
			// is nu : GetShipLocations()
			List<Location> locationList = new List<Location>();
			locationList.AddRange(Buffer(GetShipLocations(fleet.BattleShips)));
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
		List<Location> SetBuffer(List<Location> locations, List<Location> buffer, Location loc)
		{
			/// Gevonden kocaties waar een 'Overboard' wordt geplaatst kan niet direct in de bron worden opgenomen
			/// deze is in gebruik door het FindOccupied method. deze wordt dan invalid.
			/// 
			Location searchLoc = new Location();
			LocationList<Location> list = new LocationList<Location>();
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					searchLoc.X = loc.X + i;
					searchLoc.Y = loc.Y + j;
					searchLoc.BufferPart = BufferPart.Buffer; // vul alvast in als locatie straks wordt toegevoegd
					if (EmptyLocation(locations, buffer, searchLoc))
					{
						buffer.Add(new Location(searchLoc));
						list.Add(new Location(searchLoc));
					}
				}
			}
			return buffer;
		}
		Boolean EmptyLocation(List<Location> shipLocations, List<Location> buffer, Location location)
		{
			if ((shipLocations.Find(loc => (loc.X == location.X) & (loc.Y == location.Y)) == null) &
								 (buffer.Find(loc => (loc.X == location.X) & (loc.Y == location.Y)) == null))
				return true;
			return false;
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
		public void Show()
		{
			dbgShow(BattleShips);
		}
		public void dbgShow(List<BattleShip> fleet)
		{
			Console.WriteLine($"fleet name   : {Name}, Number of ships : {fleet.Count}");
			Console.WriteLine($"\tships count: {fleet.Count}");
			Console.WriteLine($"\t     Etent : {extentFleet}");
			foreach (BattleShip ship in fleet)
				ship.Show();
		}
	}
}
