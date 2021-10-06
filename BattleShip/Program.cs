using System;
using Library;
using Library.src;

namespace BattleFleetHarbor
{
  class Program
  {
    static void DoNewGame()
    {      
      //Board game = new(xSize, ySize);
      Board game = new(new BoardSize{x=10, y=10});
      game.AddShip(new BattleShip("Carrier", 5));
      game.AddShip(new BattleShip("Battleship", 4));
      game.AddShip(new BattleShip("Destroyer", 3));
      game.AddShip(new BattleShip("Submarine", 3));
      game.AddShip(new BattleShip("Patrolboat", 2));
      game.ShowFleet();
    }
    static void Main(string[] args)
    {
      Example DoExample = new();
      DoExample.DoExample();
      DoNewGame();
    }
  }
}
