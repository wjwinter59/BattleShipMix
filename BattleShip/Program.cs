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
      //game.ShowFleet();
      //game.AddFleet();
      game.AddPlayer(new Human("Willelm"));
      game.AddPlayer(new Computer("Ordinateur"));
      //game.ShowFleet();
      game.ShowPlayers();
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
