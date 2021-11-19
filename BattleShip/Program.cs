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

      Board Pacific = new(new BoardSize { x = 10, y = 10 });

      Subject Game = new Subject();//hoort een vloot bij  
      Subject Battle = new Subject(Pacific);

      Observer Player = new Observer(Game, "Willelm", Contestant.Human);
      Observer Opponent = new Observer(Game, "Ibmmetje");

      Game.ShowPlayers();
      Game.NotifyPlayers();      
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
