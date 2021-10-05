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
  public class Board
  {
    BoardSize ocean ;
    List<BattleShip> fleet = new List<BattleShip>();
    Grid battleArea;
    public Board(BoardSize ocean)
    {
      this.ocean = ocean;
      battleArea = new Grid(ocean.x, ocean.y);
    }
    public void AddShip(BattleShip ship)
    {
      fleet.Add(ship);
      battleArea.FindPlacesOnTheGrid(ship);
    }
    public void ShowFleet()
    {
      foreach (var boat in fleet)
        Console.WriteLine($"Ship : {boat.Name} \t length: {boat.Length}");
    }
    public void ShowBoard()
    {
    }
  }
}
