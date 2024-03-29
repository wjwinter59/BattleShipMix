﻿// https://stackabuse.com/git-merge-branch-into-master/
using System;

using Library.src.Subject;
using Library.src.Observer;
using System.Collections.Generic;

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
					new BattleShip( "Drager", 6),
					new BattleShip( "Vechter", 7),
					new BattleShip( "Kapotmaker", 3),
					new BattleShip( "Duiker", 6),
					new BattleShip( "Vlot", 1)
				}
			);

			Observer Player3 = new Observer(Battle, "Willelm", Contestant.Human);

			Battle.Show();
			Battle.Notify();
		}
		static void NewGame()
		{
			Subject Game = new Subject();
			//			Game.Show();
			Observer Player = new Observer(Game, "Willem");
			Observer Player2 = new Observer(Game, "IbmMetje");
			//Use another fleet
			Player2.MyFleet = new("Middeleeuwen",
					new List<BattleShip> {
						new BattleShip("Drager", 6),
						new BattleShip("Vechter", 7),
						new BattleShip("Kapotmaker", 3),
						new BattleShip("Duiker", 6),
						new BattleShip("Vlot", 1)
					}
				);
			Game.Show();
		}
		static void Main(string[] args)
		{
			NewGame();
		}
	}
}
