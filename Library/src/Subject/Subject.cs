﻿using System;
using System.Collections.Generic;
using Library.src.Observer;

namespace Library.src.Subject
{/// <summary>
 /// Is copy of Board, trying to creaate two inplemantations, by abstract and interface
 /// </summary>
	public class Subject : ISubject
	{
		List<IObserver> players=new List<IObserver>();
		private Board board;
		public Subject()
		{
			board = new Board();
		}
		public Subject(Board board)
		{
			this.board = board;
		}
		public void RegisterPlayer(IObserver observer, string name)
		{
			observer.Name = name;
			observer.PrivateBoard = new Board();
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
		public bool NotifyPlayers()
		{
			Console.WriteLine($"Notifying players");
			foreach (var player in players)
			{
				Console.WriteLine($"Notifying PLayer : {player.Name} ");
				if (player.Update(player.Name))
					return true; //Checken op lost ??
			}
			return false; // EOG
		}
		public void ShowPlayers()
		{
			Console.WriteLine($"Player list :");
			foreach (var player in players)
			{
				Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
			}
		}
		public void ShowBoard(){
			Console.WriteLine($"Player boards :");
			foreach (var player in players)
			{
				Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
				//player.PrivateBoard.dbgShow();
			}

		}
	}
}
