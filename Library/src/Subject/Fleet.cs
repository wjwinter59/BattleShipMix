using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Fleet
	{
		string name = "Default ships";
		//		static BoardSize arena = new BoardSize(6, 7);
		//Board ocean;
		List<BattleShip> battleShips = new List<BattleShip>();
		List<Location> boardSituation; // Useful for displaying the situation, nee hoor moet hier weg
		List<BattleShip> EnglishFleet = new List<BattleShip>{
				new BattleShip("Carrier", 5),
				new BattleShip("Battleship", 4),
				new BattleShip("Destroyer", 3),
				new BattleShip("Submarine", 3),
				new BattleShip("Patrolboat", 2)
		};

		#region GetSet ers
		//public BoardSize Arena { get { return arena; } }
		public List<BattleShip> BattleShips { get => battleShips; set => battleShips = value; }
		public List<Location> BoardSituation { get => boardSituation; }
		public string Name { get => name; set => name = value; }
		#endregion
		#region Constructors
		public Fleet()
		{
			this.battleShips = EnglishFleet;
			//Test cases !Fill in some parts
			battleShips[3].Locations.Add(new Location(0, 2, ShipPart.Stearn));
			battleShips[3].Locations.Add(new Location(0, 3, ShipPart.Midship));
			battleShips[3].Locations.Add(new Location(0, 4, ShipPart.Midship));
			battleShips[3].Locations.Add(new Location(0, 5, ShipPart.Bow));
			battleShips[1].Locations.Add(new Location(0, 1, ShipPart.Bow));
			battleShips[1].Locations.Add(new Location(1, 1, ShipPart.Midship));
			battleShips[1].Locations.Add(new Location(2, 1, ShipPart.Bow));
		}
		public Fleet(Board ocean, List<BattleShip> BattleShips)
		{
			//this.ocean = ocean;
			this.battleShips = BattleShips;
		}
		public Fleet(BoardSize arena)
		{
			//boardSituation = new List<Location>();
			battleShips = new List<BattleShip>();

			//ocean = arena;
			this.name = "English ships";
			battleShips = EnglishFleet;

			//Test cases !Fill in some parts
			battleShips[3].Locations.Add(new Location(0, 2, ShipPart.Stearn));
			battleShips[3].Locations.Add(new Location(0, 3, ShipPart.Midship));
			battleShips[3].Locations.Add(new Location(0, 4, ShipPart.Bow));
			battleShips[1].Locations.Add(new Location(0, 1, ShipPart.Bow));
			battleShips[1].Locations.Add(new Location(1, 1, ShipPart.Midship));
			battleShips[1].Locations.Add(new Location(2, 1, ShipPart.Bow));
			string jsonBattlaships = JsonSerializer.Serialize(battleShips);

		}
		public Fleet(string name, List<BattleShip> battleShips)
		{
			this.name = name;
			this.battleShips = battleShips;
		}
		#endregion
		/// <summary>
		/// Build list of locations that are part of all Battleships, in order to process them in a uniform way
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		public List<Location> SetSail(BoardSize arena, List<BattleShip> armada)
		{
			Buffer shipsBuffers = new Buffer(arena, armada);
			boardSituation = shipsBuffers.BoardSituation;
			return boardSituation;
		}
		/// <summary>
		/// Create a complete list of locations that contain ship parts 
		///		and a buffer around them.
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		List<Location> FindOccupied(List<BattleShip> fleet)
		{
			List<Location> locationList = new();
			foreach (var ship in fleet)
				locationList.AddRange(ship.Locations);

			locationList.AddRange(Buffer(locationList));
			//dbgShow(locationList);
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
		public void dbgShow()
		{
			dbgShow(BattleShips);
		}
		public void dbgShow(List<BattleShip> fleet)
		{
			foreach (BattleShip ship in fleet)
			{
				Console.WriteLine($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
				dbgShow(ship.Locations);
			}
		}
		void dbgShow(List<Location> locations)
		{
			foreach (var loc in locations)
				Console.WriteLine($"{loc.X}, {loc.Y}, {loc.ShipPart}");
			Console.WriteLine();
		}
	}
}
