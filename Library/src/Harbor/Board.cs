using System;
using System.Collections.Generic;
using Library.src;
using Library.src.Harbor;

namespace Library
{
  public class Board
  {
    BoardSize sea; //sea als in de vazameling van oceanen
    Grid battleArea;

    public BoardSize Sea { get { return sea; } }

    public Board(BoardSize ocean)
    {
      this.sea = ocean;
      battleArea = new Grid(ocean.x, ocean.y);
    }
    public Board()
    {
      this.sea = new BoardSize { x = 10, y = 10 };
      battleArea = new Grid(sea.x, sea.y);
    }
    /// <summary>
    /// FindPlacesOnTheGrid becomes place fleet on the grid
    /// </summary>
    /// <param name="armada"></param>
    public void AddFleet(Fleet armada)
    {
      battleArea.PutFleetOnTheGrid(armada);
    }
    /// <summary>
    /// Add a 'named' fleet by using a list of ships.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ships"></param>
    
    /*
    public void AddFleet(string name, List<BattleShip> ships)
    {
      armada = new Fleet(name, ships);
      battleArea.PutFleetOnTheGrid(armada);
    }
    */
  }
}
