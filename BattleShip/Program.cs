using System;

using Library.src.Subject;
using Library.src.Observer;
using Library.src.Harbour;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace BattleShipGame
{
	class Program
	{
		static void DoOldGame()
		{
			Subject Battle = new Subject();

			Observer Player1 = new Observer(Battle, "René", Contestant.Human);
			Observer Player2 = new Observer(Battle, "IbmMetje");
			Player2.MyFleet = new("Middeleeuwen",
					new List<BattleShip> {
						new BattleShip(Battle.BattleSize, "Drager", 6),
						new BattleShip(Battle.BattleSize, "Vechter", 7),
						new BattleShip(Battle.BattleSize, "Kapotmaker", 3),
						new BattleShip(Battle.BattleSize, "Duiker", 6),
						new BattleShip(Battle.BattleSize, "Vlot", 1)
				}
			);

			Observer Player3 = new Observer(Battle, "Willelm", Contestant.Human);

			Battle.ShowPlayers();
			Battle.Notify();
		}
		static void NewGame()
		{
			Subject Game = new Subject();
			Game.Show();
			Observer Player = new Observer(Game, "Willem");
			Observer Player2 = new Observer(Game, "IbmMetje");
			//Use another fleet
			Player2.MyFleet = new("Middeleeuwen",
					new List<BattleShip> {
						new BattleShip(Game.BattleSize, "Drager", 6),
						new BattleShip(Game.BattleSize, "Vechter", 7),
						new BattleShip(Game.BattleSize, "Kapotmaker", 3),
						new BattleShip(Game.BattleSize, "Duiker", 6),
						new BattleShip(Game.BattleSize, "Vlot", 1)
					}
				);
			Game.ShowPlayers();
		}
		static void Main(string[] args)
		{
			// Create a UTF-8/16 encoding.
			//DoOldGame();
			NewGame();

		}
	}
}
