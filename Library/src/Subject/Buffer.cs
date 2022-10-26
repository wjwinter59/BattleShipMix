using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Buffer
	{
		List<Location> boardSituation = new List<Location>();
		List<Space> spaceLocations = new List<Space>();

		public List<Location> BoardSituation { get { return boardSituation; } }
		public Buffer(List<BattleShip> battleShips)
		{
			List<Location> shipLocations = new List<Location>();
			List<Location> bufferLocations = new List<Location>();
			List<Location> tmpList = new();
			// Collect all locations from the ships
			foreach (var ship in battleShips)   // Each Ship !!
				shipLocations.AddRange(ship.Locations);

			// Create buffers locations and Add the ships locations
			bufferLocations = GetBuffer(shipLocations);
			bufferLocations.AddRange(shipLocations);

			// Orderen zodat ..... (waarom ook weer) ?			
			boardSituation = bufferLocations.OrderBy(o => o.X).ThenBy(o => o.Y).ToList();
			// Go find spaces to fit one ship 
			// Place one ship and start over (at a hihger level)
			// to be implemented....
			spaceLocations = FindEmptySpots(boardSituation, 5);
		}
		/// <summary>
		/// Get bufferlocations around locations that are occupied by shipparts.
		/// Game rule states that ships are not allowed to touch each other.
		/// </summary>
		/// <param name="location"></param>
		List<Location> GetBuffer(List<Location> locations)
		{
			List<Location> newBuffer = new();
			foreach (var loc in locations)
				SetBuffer(locations, newBuffer, loc);
			return newBuffer;
		}
		/// <summary>
		/// Create a list of 'buffer'parts around a ships location, appart from alreaday occupied locations
		/// </summary>
		/// <param name="part"></param>
		/// <param name="bufValue"></param>
		/// <returns></returns>
		List<Location> SetBuffer(List<Location> locations, List<Location> buffer, Location loc)
		{
			/// Gevonden kocaties waar een 'buffer' wordt geplaatst kan niet direct in de bron worden opgenomen
			/// deze is in gebruik door het FindOccupied method. deze wordt dan invalid.
			/// 
			Location searchLoc = new Location();
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					searchLoc.X = loc.X + i;
					searchLoc.Y = loc.Y + j;
					searchLoc.Part = BoardPart.Buffer; // vul alvast in als locatie straks wordt toegevoegd
					if (EmptyLocation(locations, buffer, searchLoc))
						buffer.Add(new Location(searchLoc));
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
		/// <summary>
		/// Create a list of apaces that wil fit the current schip.
		/// </summary>
		/// <param name="locations"></param>
		/// <returns></returns>
		List<Space> FindEmptySpots(List<Location> location, int length)
		{
			List<Space> spots = new List<Space>();

			// for (int i = 0; i < location..; i++)	
			List<Location> occupied = new List<Location>();
			//Space tmpEmpty = new();
			return spots;
		}
	}
}
