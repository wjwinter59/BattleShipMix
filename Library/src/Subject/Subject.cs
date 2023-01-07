using System;
using System.Collections.Generic;
using Library.src.Harbour;
using Library.src.Observer;

namespace Library.src.Subject
{
	public class Subject : ISubject
	{
		#region Private spul getters and contruct
		List<IObserver> players = new List<IObserver>();
		private Board defaultBoard;
		private Fleet defaultFleet;

		public Board DefaultBoard { get => defaultBoard; }
		public Fleet DefaultFleet { get => defaultFleet; }

		public Subject()
		{
			defaultBoard = new Board(6, 7); // overrule default 10x10 size
			defaultFleet = new Fleet();
		}
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
			observer.MyFleet = DefaultFleet; // Get default fleet from subject
			observer.MyBoard = DefaultBoard; // Default from subject.
			observer.MyBoard.ShipLocations = DefaultFleet.GetShipLocations();
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
				putfleetOnBoard(player.MyBoard, player.MyFleet); //Put the fleet on the board
				return true; //Checken op lost ??
			}
			return false; // EOG
		}
		#endregion
		// First attempt
		public void putfleetOnBoard(Board board, Fleet fleet) //List<BattleShip> ships
		{
			Buffer shipsBuffers = new Buffer(fleet.BattleShips);
			board.ShipLocations = shipsBuffers.Locations;
			//return boardSituation;
		}
		public void ShowPlayers()
		{
			Console.WriteLine($"Subject players info :");
			foreach (var player in players)
			{
				Console.WriteLine($"<------------------ Info ------------------>:");
				Console.WriteLine($"Board  defaults :{DefaultBoard.Name}");
				Console.WriteLine($"\tExtent  :{this.DefaultBoard.BoardExtent}");
				Console.WriteLine($"\tFleet   :{this.DefaultFleet.Name}");

				Console.WriteLine($"Player name :{player.Name}");
				Console.WriteLine($"\tType  player :{player.PlayerType}");
				Console.WriteLine($"\tBoard Extent :{player.MyBoard.BoardExtent}");
				Console.WriteLine($"\tFleet name   :{player.MyFleet.Name}");
				Console.WriteLine($"\t\tFleet Extent :{player.MyFleet.FleetExtent}");
				Console.WriteLine($"\t\tFleet Ships  :{player.MyFleet.BattleShips.Count}");

				Console.WriteLine($"dbgShow Fleet :");
				player.MyFleet.dbgShow();
			}
		}
	}
}
