using System;
using System.Collections.Generic;
using Library.src.Subject;
using Library.src.Observer;
using Library.src.Harbour;

namespace BattleShipGame
{
  class Program
  {
    static void DoNewGame()
    {
      //Subject moet een 1 addplayer method hebben t.b.v. computer of human

      Board Pacific = new(new BoardSize { x = 10, y = 10 });
      Fleet Vloot = new("Middeleeuwen", new List<BattleShip> {
                          new BattleShip("Drager", 6),
                          new BattleShip("Vechter", 7),
                          new BattleShip("Kapotmaker", 3),
                          new BattleShip("Duiker", 6),
                          new BattleShip("Zoeker", 6)
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
