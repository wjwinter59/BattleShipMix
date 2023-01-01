using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public enum BufferPart { Buffer, Water, Nothing };

	public class Buffer
	{
		List<Location> boardSituation = new List<Location>();
		List<Location> spaceLocations = new List<Location>();
		BoardSize ocean;
		FreeSpace roomLocation = new FreeSpace();
		#region Get Set
		public List<Location> BoardSituation { get { return boardSituation; } }
		#endregion
		#region Buffering
		public Buffer(BoardSize ocean, List<BattleShip> battleShips)
		{
			List<Location> shipLocations = new List<Location>();
			List<Location> bufferLocations = new List<Location>();
			this.ocean = ocean;
			// Collect all locations from the ships
			foreach (var ship in battleShips)   // Each Ship !!
				shipLocations.AddRange(ship.Locations);

			// Create buffers locations and Add the ships locations
			bufferLocations = GetBuffer(shipLocations);
			bufferLocations.AddRange(shipLocations);
			boardSituation = bufferLocations;
			roomLocation = FindEmptySpace(bufferLocations);
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
		List<Location> SetBuffer(List<Location> shipLocations, List<Location> buffer, Location loc)
		{
			/// Gevonden kocaties waar een 'buffer' wordt geplaatst kan niet direct in de bron worden opgenomen
			/// deze is in gebruik door het FindOccupied method. deze wordt dan invalid.
			/// 
			Location searchLoc = new Location();
			// LocationList<Location> buffer2 = new LocationList<Location>();
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					searchLoc.X = loc.X + i;
					searchLoc.Y = loc.Y + j;
					searchLoc.BufferPart = BufferPart.Buffer; // vul alvast in als locatie straks wordt toegevoegd
					if (EmptyLocation(shipLocations, buffer, searchLoc))
					{
						buffer.Add(new Location(searchLoc));
						// buffer2.Add(new Location(searchLoc));
					}
				}
			}
			return buffer;
		}
		#endregion
		/// <summary>
		/// Determine bases on ship and buffer locations if a location is free
		/// </summary>
		/// <param name="shipLocations"></param>
		/// <param name="buffer"></param>
		/// <param name="location"></param>
		/// <returns></returns>
		Boolean EmptyLocation(List<Location> shipLocations, List<Location> buffer, Location location)
		{
			return (Empty(shipLocations, location) & (Empty(buffer, location)));
		}
		/// <summary>
		/// return wether a location in a list of locations is free or not
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="location"></param>
		/// <returns></returns>
		Boolean Empty(List<Location> buffer, Location location)
		{
			return (buffer.Find(loc => (loc.X == location.X) & (loc.Y == location.Y)) == null);
		}
		#region Find free space
		/// <summary>
		/// Create a list of paces that wil fit the current schip.
		/// Occupied is a sorted list of locations x,y] 
		/// </summary>
		/// <param name="occupied"></param>
		/// <returns></returns>
		FreeSpace FindEmptySpace(List<Location> occupied)
		{
			List<Location> buzzy = occupied.OrderBy(o => o.Y).ThenBy(o => o.X).ToList();
			FreeSpace spots = new FreeSpace();
			Location curr = new Location();
			Location LocMin = new Location() { X = -1, Y = -1 };
			Location LocMax = new Location() { X = ocean.X, Y = ocean.Y };
			//Make curr equal to the first entry in the list
			if (buzzy.Count > 0)
				curr = buzzy[0];
			else
				return spots; // Empty list no need to proceed.

			Location len = new Location();
			foreach (Location next in buzzy)
			{
				len = next - curr;
				if (curr > LocMin & curr < LocMax)
				{
				 //if (next > LocMin & next < LocMax) // zoek next locatie
					Console.WriteLine($"Current :{curr.X},{curr.Y}\t Next :{next.X},{next.Y}\t Length :{len.X},{len.Y}");
				}
				curr = next;
			}
			return spots;
		}
		#endregion
	}
}
