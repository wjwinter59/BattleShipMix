using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using Library.src;
using Library.src.Harbour;
using Library.src.Observer;

namespace Library.src.Subject
{/// <summary>
 /// Is copy of Board, trying to creaate two inplemantations, by abstract and interface
 /// </summary>
	public class Subject : ISubject
	{
		List<IObserver> players = new List<IObserver>();
		private Board board;
		private Fleet fleet;
		public Subject() {
			board = new Board();
		}
		public Subject(Board board)
		{
			this.board = board;
		}
		public Subject(Board board, Fleet fleet)
		{
			this.board = board;
			this.fleet = fleet;
		}

		public void RegisterPlayer(IObserver observer, string name)
		{
			//Console.WriteLine($"Adding {observer.GetType().Name} name : {name}");
			observer.Name = name;
			observer.BattleGround = new Board ();
			players.Add(observer);
		}

		public void RegisterPlayer(IObserver observer)
		{
			//Console.WriteLine($"Adding default {observer.GetType().Name} name : {observer.Name}");
			players.Add(observer);
		}
		public bool NotifyPlayers()
		{
			Console.WriteLine($"Notifiing players");
			foreach (var player in players)
			{
				Console.WriteLine($"Notifying : {player.Name} to play it's move");
				if (player.Update(player.Name))
					return true; //Checken op lost ??
			}
			return false;
		}
		public void ShowPlayers()
		{
			Console.WriteLine($"Player list :");
			foreach (var player in players)
			{
				Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
				ShowFleet(player.BattleGround.NavalFleet);
			}
		}
		public void ShowFleet(Fleet navalShips){
			foreach (var ship in navalShips.BattleShips){
				Console.WriteLine($"\t :{ship.Name}, Length  {ship.Length} Sunk ? {ship.Sunk}");
			}
		}
	}
}
