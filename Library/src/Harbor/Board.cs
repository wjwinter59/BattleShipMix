using System;
using System.Collections.Generic;
using Library.src;
using Library.src.Harbor;

namespace Library
{
  public abstract class Board
  {
    BoardSize ocean;
    Fleet armada;
    Grid battleArea;
    public Board(BoardSize ocean)
    {
      this.ocean = ocean;
      battleArea = new Grid(ocean.x, ocean.y);
    }
    /// <summary>
    /// FindPlacesOnTheGrid becomes place fleet on the grid
    /// </summary>
    /// <param name="armada"></param>
    public void AddFleet(Fleet armada) {
      battleArea.PutFleetOnTheGrid(armada);
    }
    /// <summary>
    /// Add a 'named' fleet by using a list of ships.
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
  }
}
