using System;
using System.Collections.Generic;
using Library;
using Library.src;
using Library.src.Harbor;

namespace BattleFleetHarbor
{
  class Program
  {
    static void DoNewGame()
    {
      //Subject moet een 1 addplayer method hebben t.b.v. computer of human

      Board Pacific = new(new BoardSize { x = 10, y = 10 });
      Fleet Vloot = new("Middeleeuwen", new List<BattleShip> {
                          new BattleShip("Drager", 6),
                          new BattleShip("Vechtboot", 9),
                          new BattleShip("Kapotmaker", 3),
                          new BattleShip("Duikboat", 3),
                          new BattleShip("Vluchtboat", 4)
                        }
                        );

      Subject Battle = new Subject(Pacific);
      //Mogwlijke vormen van players
      Observer Player1 = new Observer(Battle, "Ibmmetje");
      Observer Opponent1 = new Observer(Battle);
      Observer Player2 = new Observer(Battle);
      Observer Opponent2 = new Observer(Battle, Vloot, "Willelm", Contestant.Human);

      //Player2.ChangeFleet(      );
      Battle.ShowPlayers();
      Battle.NotifyPlayers();
    }
    static void Main(string[] args)
    {
      DoNewGame();
    }
  }
}
