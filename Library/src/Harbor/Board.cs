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
    public Grid BattleArea { get => battleArea; }

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
    public bool PlayMove(Grid battleField, Contestant playerType)
    {
      if (playerType == Contestant.Computer)
      {
        Console.WriteLine($"Playing {playerType}'s move");
        return battleField.PlayComputer(battleField);
      }
      else
        Console.WriteLine($"Scipping  {playerType}'s move");

      return false;
    }
    /// <summary>
    /// FindPlacesOnTheGrid becomes place fleet on the grid
    /// </summary>
    /// <param name="armada"></param>
    public void RegisterFleet(Fleet armada)
    {
      battleArea.PutFleetOnTheGrid(armada);
    }
  }
}
