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
      Game game = new(new BoardSize{x=10, y=10});
      game.ShowFleet();
      //game.AddFleet();
      //game.AddPlayer(new Player("Willelm"));
      //game.ShowFleet();
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
