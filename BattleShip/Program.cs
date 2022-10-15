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
      // Subject moet een 1 addplayer method hebben t.b.v. computer of human
      Board Pacific = new(new BoardSize { x = 10, y = 10 });
      Fleet Armada = new("Middeleeuwen", 
        new List<BattleShip> {
          new BattleShip("Drager", 6),
          new BattleShip("Vechter", 7),
          new BattleShip("Kapotmaker", 3),
          new BattleShip("Duiker", 6),
          new BattleShip("Vlot", 1)
        }
      );
      Subject Battle = new Subject(Pacific);

			Armada.Show();

      // Mogwlijke vormen van players
      Observer Player1 = new Observer(Battle, "IbmMetje");
      Observer Player2 = new Observer(Battle, "Rene", Contestant.Human);
      Observer Player3 = new Observer(Battle, Armada, "Willelm", Contestant.Human);

      Battle.ShowPlayers();
      Battle.NotifyPlayers();
    }
    static void Main(string[] args)
    {
      DoNewGame();
			// ShipSymbols ss = new();
      Console.WriteLine($"{ShipSymbol.SD} {ShipSymbol.SD.GetType()}");

		}
	}
}
