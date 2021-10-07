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
  /// initilaize the grid to Kind.Water sized by x,y parameeres
  /// </summary>
  public abstract class Board
  {
    BoardSize ocean;
    List<BattleShip> armada2 = new List<BattleShip>();
    Fleet armada;
    Grid battleArea;
    public Board(BoardSize ocean)
    {
      this.ocean = ocean;
      battleArea = new Grid(ocean.x, ocean.y);
      //armada = new Fleet("Flottieltje", armada);
    }
    /// <summary>
    /// FindPlacesOnTheGrid becomes place fleet on the grid
    /// </summary>
    /// <param name="armada"></param>
    public void AddFleet(Fleet armada) {
      battleArea.PutFleetOnTheGrid(armada);
    }
    /// <summary>
    /// Add a fleet by using a list of ships.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ships"></param>
    public void AddFleet(string name, List<BattleShip> ships){
      armada = new Fleet(name, ships);
      battleArea.PutFleetOnTheGrid(armada);
    }
    public void ShowFleet (){
      armada.Show();
    }
    /*
        public void AddShip(BattleShip ship)
        {
          armada.Add(ship);
          battleArea.FindPlacesOnTheGrid(ship);
        }
    */
  }
}
