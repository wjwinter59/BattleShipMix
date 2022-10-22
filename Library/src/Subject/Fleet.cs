using System;
using System.Collections.Generic;
using System.Linq;

using Library.src.Harbour;

namespace Library.src.Subject
{
  public class Fleet
  {
    string name = "Default ships";
    List<BattleShip> battleShips;
    List<Location> boardSituation; // Useful for displaying the situation
    public List<BattleShip> BattleShips { get => battleShips; set => battleShips = value; }
    public List<Location> BoardSituation { get => boardSituation; }
    public string Name { get => name; set => name = value; }

    List<BattleShip> dummy = new List<BattleShip>{
				new BattleShip("Carrier", 5),
				new BattleShip("Battleship", 4),
				new BattleShip("Destroyer", 3),
				new BattleShip("Submarine", 3),
				new BattleShip("Patrolboat", 2)
                                                };
    public Fleet()
    {
      boardSituation = new List<Location>();
      battleShips = new List<BattleShip>();

      battleShips = dummy;
      //Test gevalletje !
      battleShips[3].Locations.Add(new Location(3, 3, BoardPart.Stearn));
      battleShips[3].Locations.Add(new Location(4, 3, BoardPart.Midship));
      battleShips[3].Locations.Add(new Location(5, 3, BoardPart.Bow));

      battleShips[0].Locations.Add(new Location(0, 0, BoardPart.Bow));
    }
    public Fleet(string name, List<BattleShip> battleShips)
    {
      this.name = name;
      this.battleShips = battleShips;
    }
    /// <summary>
    /// Build list of locations that are part of all Battleships, in order to process them in a uniform way
    /// </summary>
    /// <param name="fleet"></param>
    /// <returns></returns>
    public Boolean SetSail(List<BattleShip> fleet)
    {
      List<Location> shipLocations = new();   // List Occupied places
      List<Location> availableSpaces; // List available spaces
      foreach (var ship in fleet)
      {
        shipLocations = FindOccupied(fleet);                    // should become an object of somesort
        availableSpaces = GetEmptySpots(shipLocations, ship);   // should become an object 
      }
      boardSituation = shipLocations.OrderBy(o => o.X).ThenBy(o => o.Y).ToList();
      return true;
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
      return tmpEmpty;
    }
    /// <summary>
    ///     Some show methods for debugging purposus
    /// </summary>
    /// <param name="fleet"></param>
    public void dbgShow(List<BattleShip> fleet)
    {
      foreach (BattleShip ship in fleet)
      {
        Console.Write($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
        foreach (var part in ship.Locations)
          Console.Write($"Locations : {part.X},{part.Y},{part.Part}");
        Console.WriteLine("");
      }
    }
    void dbgShow(List<Location> locations)
    {
      foreach (var loc in locations)
        Console.WriteLine($"{loc.X}, {loc.Y}, {loc.Part}");
      Console.WriteLine();
    }
  }
}
