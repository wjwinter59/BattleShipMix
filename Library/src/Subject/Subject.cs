using System;
using System.Collections.Generic;
using Library.src.Harbour;
using Library.src.Observer;

namespace Library.src.Subject
{
	public class Subject : ISubject
	{
		#region Private spul
		List<IObserver> players = new List<IObserver>();
		private Board board;
		private Fleet fleet;

		public Subject()
		{
			board = new Board(6, 7); // overrule default 10x10 size
			fleet = new Fleet();
		}
		public BoardSize BattleSize { get { return board.Size; } }
		#endregion

		#region Methods spul
		public void RegisterPlayer(IObserver observer)
		{
			RegisterPlayer(observer, "Default Player");
		}
		/// <summary>
		/// Equip the player with all sorts of usable items
		/// </summary>
		/// <param name="observer"></param>
		/// <param name="name"></param>
		public void RegisterPlayer(IObserver observer, string name)
		{
			//putfleetOnBoard(board.Size, fleet.BattleShips); //Put the fleet on the board
			observer.Name = name;
			observer.MyBoard = board;
			observer.MyFleet = fleet;
			observer.MyBoard.FleetLocations = GetShipLocations(fleet);
			players.Add(observer);
		}
		/// <summary>
		/// Nog helemaal uitwerken 
		/// </summary>
		/// <returns></returns>
		public bool Notify()
		{
			foreach (var player in players)
			{
				Console.WriteLine($"Notifying PLayer : {player.Name} ");
				// Do som player stuf
				putfleetOnBoard(board, fleet); //Put the fleet on the board
				return true; //Checken op lost ??
			}
			return false; // EOG
		}
		#endregion
		List<Location> GetShipLocations(Fleet fleet)
		{
			List<Location> tmpLocations = new List<Location>();
			foreach (var ship in fleet.BattleShips)
				tmpLocations.AddRange(ship.Locations);
			return tmpLocations;
		}
		// First attempt
		public void putfleetOnBoard(Board board, Fleet fleet) //List<BattleShip> ships
		{
			Buffer shipsBuffers = new Buffer(board.Size, fleet.BattleShips);
			board.FleetLocations = shipsBuffers.BoardSituation;
			//return boardSituation;
		}
		public void Show()
		{
			Console.WriteLine($"Default board  : {board.Size}");
			Console.WriteLine($"Ships in fleet : {fleet.BattleShips.Count}");
		}
		public void ShowPlayers()
		{
			Console.WriteLine($"Player list :");
			foreach (var player in players)
			{
				Console.WriteLine($"\t Player :{player.Name}, is a {player.PlayerType} ");
				Console.WriteLine($"Players fleet : {player.MyFleet.Name} with player.MyFleet.Arena of room");
				player.MyFleet.dbgShow();
			}
		}
	}
}
