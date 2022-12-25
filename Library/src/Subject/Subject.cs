using System;
using System.Collections.Generic;
using Library.src.Harbour;
using Library.src.Observer;

namespace Library.src.Subject
{/// <summary>
 /// Is copy of Board, trying to creaate two inplemantations, by abstract and interface
 /// </summary>
	public class Subject : ISubject
	{
		#region Private spul
		List<IObserver> players = new List<IObserver>();
		private Board board;
		public Subject()
		{
			board = new Board();
		}
		public BoardSize BattleSize { get {return board.BattleArea; } }
		#endregion
		#region Methods spul
		public void RegisterPlayer(IObserver observer, string name)
		{
			observer.Name = name;
			players.Add(observer);
		}
		public void RegisterPlayer(IObserver observer)
		{
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
				if (player.Update(player.Name))
					return true; //Checken op lost ??
			}
			return false; // EOG
		}
		#endregion
		public void ShowPlayers()
		{
			Console.WriteLine($"Player list :");
			foreach (var player in players)
			{
				Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
				// player.MyBoard.dbgShow(player.MyBoard);
			}
		}
	}
}
