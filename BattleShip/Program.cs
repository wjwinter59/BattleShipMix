using System;
using System.Collections.Generic;
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

      Subject Battle = new Subject(Pacific);
      //Mogwlijke vormen van players
      Observer Opponent1 = new Observer(Battle);
      Observer Opponent2 = new Observer(Battle, "Ibmmetje");
      Observer Player = new Observer(Battle, "Willelm", Contestant.Human);
      Observer Player2 = new Observer(Battle);
      Player2.ChangeFleet(new List<BattleShip>  {
                          new BattleShip("Drager", 5),
                          new BattleShip("Vechtboot", 4),
                          new BattleShip("Kapotmaker", 3),
                          new BattleShip("Duikboat", 3),
                          new BattleShip("Vluchtboat", 2)
                        }
      );

      Battle.ShowPlayers();
      Battle.NotifyPlayers();
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
