using System;
using Library;
using Library.src;

namespace BattleFleetHarbor
{
  class Program
  {
    static void DoNewGame()
    {
      //Subject moet een 1 addplayer method hebben t.b.v. computer of human
      //Observer player1 = new Observer("Willelm", Board);
      //ObserverComputer computer = new ObserverComputer("Delletje", Board);      
      Board board = new(new BoardSize { x = 10, y = 10 });
      Subject Game = new Subject();//hoort een vloot bij 
      Observer Player = new Observer(Game, "Willelm");
      Observer Computer = new Observer(Game, "Ibmmetje");

      //Game.RegisterPlayer(Player);
      //Game.RegisterPlayer(new ObserverComputer(Game, "Delletje"));
      Game.ShowPlayers();
      Game.NotifyPlayers();      
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
