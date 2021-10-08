using System;
using System.Collections.Generic;
using Library.src;
using Library.src.Harbor;

/// <summary>
/// Cells hold the status of the gridcells by enum
/// </summary>
namespace Library
{
  /// <summary>
  /// initilaize the grid to BoardPiece.Water sized by x,y parameeres
  /// </summary>

  public class Grid
  {
    BoardPiece [,] cells;
    BoardSize gridSize;
    public BoardPiece[,] Cells { get => cells; }
    public Grid(BoardSize gridSize)
    {
      this.gridSize = gridSize;
      InitGrid(gridSize, BoardPiece.Water);
    }
    public Grid(int xSize, int ySize)
    {
      gridSize.x = xSize;
      gridSize.y = ySize;
      InitGrid(gridSize, BoardPiece.Water);
    }
    void InitGrid(BoardSize grid, BoardPiece what)
    {
      cells = new BoardPiece[grid.x, grid.y];

      for (int i = 0; i < grid.x; i++)
      {
        for (int j = 0; j < grid.y; j++)
        {
          cells[i, j] = what;
        }
      }
    }
    /// <summary>
    /// New method for adding a Fleet to the board
    /// </summary>
    /// <param name="armada"></param>
    public void PutFleetOnTheGrid(Fleet armada){
      foreach(var ship in armada.BattleShips)
        PutShipOnTheGrid(ship);
    }
    /// <summary>
    /// Holds a list of coordinates that will hold a ship, one ship is randomply chosen from the list
    /// if the list is empty than there is no room for the ship of size 'length' on the grid
    /// the length property will provide a number from witch the ship wil start randomly
    /// </summary>
    public void PutShipOnTheGrid(BattleShip ship)
    { // hash table van maken ?
      List<tempPosition> possibillitys = new List<tempPosition>();
      FindY(possibillitys, ship);
      Console.WriteLine($"Ship : {ship.Name} \t length {ship.Length} \t Spaces : {possibillitys.Count}");
      FindX(possibillitys, ship);
      Console.WriteLine($"Ship : {ship.Name} \t length {ship.Length} \t Spaces : {possibillitys.Count}");
      if (possibillitys.Count > 0)
        PlaceBattleShip(possibillitys, ship);
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
      Random random = new ();
      int startPosition = 0, randomSpace = 0;
      if (spaces.Count == 0) return false;

      randomSpace = spaces.Count > 0 ? random.Next(spaces.Count) : 0;
      startPosition = random.Next(spaces[randomSpace].spaceLength);
      Console.ResetColor();

      for (int i = 0; i < ship.Length; i++)
      {
        if (spaces[randomSpace].horizontal)
        {
          cells[spaces[randomSpace].x + startPosition + i, spaces[randomSpace].y] = BoardPiece.Ship;
          ship.Location.Add((new Location() { x = spaces[randomSpace].x + startPosition + i, y = spaces[randomSpace].y }));
        }
        else
        {
          cells[spaces[randomSpace].x, spaces[randomSpace].y + startPosition + i] = BoardPiece.Ship;
          ship.Location.Add(new Location(){x=spaces[randomSpace].x, y=spaces[randomSpace].y + startPosition + i });
        }
      }
      return true;
    }
    /// <summary>
    /// Just show on the console app the contens of the cells on the Grid
    /// </summary>
    public void ShowCells()
    {
      char cellType;
      for (int i = 0; i < gridSize.x; i++)
      {
        for (int j = 0; j < gridSize.y; j++)
        {
          cellType = (cells[i, j] == BoardPiece.Water) ? ShipPart.SW : ShipPart.SM;
          Console.Write($"{cellType}");
        }
        Console.WriteLine("/n");
      }
    }
    /// <summary>
    /// FindPlaces is the new yet to program method to replace FindX and FindY
    /// return true if there is at least one space to place a ship
    /// </summary>
    /// <param name="possibillitys"></param>
    /// <param name="Ship"></param>
    bool FindPlaces(List<tempPosition> possibillitys, BattleShip Ship)
    {
      return true;
    }
    void FindX(List<tempPosition> possibillitys, BattleShip Ship)
    {
      int j, s = 0;
      // -------------------- xxxxxxx ---------------------------
      for (int i = 0; i < gridSize.x; i++) //Loop alle x posities bijlangs
      {
        j = 0;
        s = 0; //start potetial space for ship in y richting
        while (j < gridSize.y - Ship.Length) //niet verder dan er ruimte is voor ship
        {
          if ((cells[i, j++] != BoardPiece.Water) | (j == gridSize.y - Ship.Length))
          {
            //Console.Write($"Geen Water of eol: {cells[i, j]},");
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
          if ((cells[j++, i] != BoardPiece.Water) | (j == gridSize.x - Ship.Length))
          {
            //Console.Write($"Geen Water of eol: {cells[i, j]},");
            if (j + Ship.Length <= gridSize.x) // is er ruimte
              possibillitys.Add(new tempPosition() { x = s, y = i, spaceLength = j - s, horizontal = true });
            s = ++j;//skip 'non water'
          }
        }
      }
    }
  }
}
