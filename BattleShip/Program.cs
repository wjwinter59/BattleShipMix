using System;
using Library;
using Library.src;

namespace BattleFleetHarbor
{
  class Program
  {
    static void DoNewGame()
    {      
      Board board = new(new BoardSize { x = 10, y = 10 });
      //Game game = new(new BoardSize{x=10, y=10});
      //game.ShowFleet();
      //game.AddFleet();
      //game.AddPlayer(new Human("Willelm"));
      //game.AddPlayer(new Computer("Ordinateur"));
      //game.ShowFleet();
      //game.ShowPlayers();
      // interface approach()
      Subject Game = new Subject();//hoort een vloot bij 

      //Subject moet een 1 addplayer method hebben t.b.v. computer of human
      //Observer player1 = new Observer("Willelm", Board);
      //ObserverComputer computer = new ObserverComputer("Delletje", Board);
      Game.RegiserBoard();
      Game.RegisterPlayer(new Observer("Willelm", Game));
      Game.RegisterPlayer(new ObserverComputer("Delletje", Game));
      Game.NotifyPlayers();
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
