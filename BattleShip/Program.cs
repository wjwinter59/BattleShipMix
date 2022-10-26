using System;

using Library.src.Subject;
using Library.src.Observer;
using Library.src.Harbour;
using System.Collections.Generic;

namespace BattleShipGame
{
	class Program
	{
		static void DoNewGame()
		{
			Subject Battle = new Subject();
			Observer Player1 = new Observer(Battle, "Rene", Contestant.Human);
			Observer Player2 = new Observer(Battle, "IbmMetje");

			Player2.PrivateFleet = new("Middeleeuwen",
				new List<BattleShip> {
					new BattleShip("Drager", 6),
					new BattleShip("Vechter", 7),
					new BattleShip("Kapotmaker", 3),
					new BattleShip("Duiker", 6),
					new BattleShip("Vlot", 1)
			});

			Observer Player3 = new Observer(Battle, "Willelm", Contestant.Human);

			Battle.ShowPlayers();
			Battle.NotifyPlayers();
		}
		static void Main(string[] args)
		{
			// Create a UTF-8/16 encoding.
			DoNewGame();
		}
	}
}
