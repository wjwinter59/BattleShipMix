using System;
using System.Collections.Generic;
using Library.src;

/// <summary>
/// Cells hold the status of the gridcells by enum
/// </summary>
namespace Library
{
  /// <summary>
  /// initilaize the grid to Kind.Water sized by x,y parameeres
  /// </summary>

  public class Grid
  {
    Kind[,] cells;
    BoardSize gridSize;
    public Kind[,] Cells { get => cells; }
    public Grid(BoardSize gridSize)
    {
      this.gridSize = gridSize;
      InitGrid(gridSize, Kind.Water);
    }
    public Grid(int xSize, int ySize)
    {
      gridSize.x = xSize;
      gridSize.y = ySize;
      InitGrid(gridSize, Kind.Water);
    }
    void InitGrid(BoardSize grid, Kind what)
    {
      cells = new Kind[grid.x, grid.y];

      for (int i = 0; i < grid.x; i++)
      {
        for (int j = 0; j < grid.y; j++)
        {
          cells[i, j] = what;
        }
      }
    }
    /// <summary>
    /// Holds a list of coordinates that will hold a ship one ship is randomply chosen from the list
    /// if the list is empty than there is no room for the ship of size 'length' on the grid
    /// the length property will provide a number from witch the ship wil start randomly
    /// </summary>
    public void FindPlacesOnTheGrid(BattleShip Ship)
    { // hash table van maken ?
      List<tempPosition> possibillitys = new List<tempPosition>();
      FindY(possibillitys, Ship);
      FindX(possibillitys, Ship);
      if (possibillitys.Count > 0)
        PlaceBattleShip(possibillitys, Ship);
      ShowCells();
    }
    /// <summary>
    /// A space in the list of spaces has room ('spaceLemgth') for a ship of 'Length' size 
    /// horizontal or vertical (!horizontal)
    /// </summary>
    /// <param name="spaces"></param>
    /// <param name="ship"></param>
    /// <returns></returns>
    bool PlaceBattleShip(List<tempPosition> spaces, BattleShip ship)
    {
      Random random = new Random();
      int startPosition = 0, randomSpace = 0;
      Console.WriteLine($"Ship : {ship.Name} \t length {ship.Length} \t Spaces : {spaces.Count}");
      foreach (var space in spaces)
      {
        Console.WriteLine($"Found spaces : {space.x},{space.y} length {space.spaceLength} \t Ship len {ship.Length}");
      }

      if (spaces.Count == 0) return false;

      randomSpace = spaces.Count > 0 ? random.Next(spaces.Count) : 0;
      startPosition = random.Next(spaces[randomSpace].spaceLength);
      Console.ResetColor();

      for (int i = 0; i < ship.Length; i++)
      {
        if (spaces[randomSpace].horizontal)
        {
          //Console.ForegroundColor = (Console.ForegroundColor == ConsoleColor.Green) ? ConsoleColor.Blue : ConsoleColor.Green;
          Console.ForegroundColor = ConsoleColor.Green;
          cells[spaces[randomSpace].x + startPosition + i, spaces[randomSpace].y] = Kind.Ship;
        }
        else
        {
          //Console.ForegroundColor = (Console.ForegroundColor == ConsoleColor.Blue) ? ConsoleColor.Green : ConsoleColor.Blue;
          Console.ForegroundColor = ConsoleColor.Blue;
          cells[spaces[randomSpace].x, spaces[randomSpace].y + startPosition + i] = Kind.Ship;
        }
      }
      //Console.ForegroundColor = ConsoleColor.Black;
      return true;
    }
    public void ShowCells()
    {
      char cellType;
      for (int i = 0; i < gridSize.x; i++)
      {
        for (int j = 0; j < gridSize.y; j++)
        {
          cellType = (cells[i, j] == Kind.Water) ? ShipPart.SW : ShipPart.SM;
          Console.Write($"{cellType}");
        }
        Console.WriteLine("/n");
      }
    }
    void FindX(List<tempPosition> possibillitys, BattleShip Ship)
    {
      int j, s = 0;
      // -------------------- xxxxxxx ---------------------------
      for (int i = 0; i < gridSize.x; i++) //Loop alle x posities bijlangs
      {
        j = 0;
        s = 0; //start potetial space for ship
        while (j < gridSize.y - Ship.Length) //niet verder dan er ruimte is voor ship
        {
          if ((cells[i, j++] != Kind.Water) | (j == gridSize.y - Ship.Length))
          {
            Console.Write($"Geen Water of eol: {cells[i, j]},");
            if (j + Ship.Length <= gridSize.y) // is er ruimte
              possibillitys.Add(new tempPosition() { x = i, y = s, spaceLength = j - s, horizontal = false });
            s = ++j;//skip 'non water'
          }
        }
      }
    }
    void FindY(List<tempPosition> possibillitys, BattleShip Ship)
    {
      int j, s = 0;
      // -------------------- YYYYYYY ---------------------------
      for (int i = 0; i < gridSize.y; i++) //Loop alle y posities bijlangs
      {
        j = 0;
        s = 0; //start potetial space for ship
        while (j < gridSize.x - Ship.Length) //niet verder dan er ruimte is voor ship
        {
          if ((cells[j++, i] != Kind.Water) | (j == gridSize.x - Ship.Length))
          {
            Console.Write($"Geen Water of eol: {cells[i, j]},");
            if (j + Ship.Length <= gridSize.x) // is er ruimte
              possibillitys.Add(new tempPosition() { x = s, y = i, spaceLength = j - s, horizontal = true });
            s = ++j;//skip 'non water'
          }
        }
      }
    }
  }
}
