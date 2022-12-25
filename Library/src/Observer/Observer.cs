using System;
using System.Collections.Generic;

using Library.src.Harbour;
using Library.src.Subject;

namespace Library.src.Observer
{
	public class Observer : IObserver
	{
		string name;
		Contestant playerType;
		private Board myBoard;
		private Fleet myFleet;

		#region Get- Setters
		public string Name { get { return name; } set { name = value; } }
		public Fleet MyFleet { get { return myFleet; } set { myFleet = value; } }
		public Board MyBoard { get { return myBoard; } set { myBoard = value; } }
		public Contestant PlayerType { get { return playerType; } set { playerType = value; } }
		#endregion
		public Observer(ISubject subject, string name)
		{
			SetupObserver(subject, name, Contestant.Computer);
		}
		public Observer(ISubject subject, string name, Contestant playerType)
		{
			SetupObserver(subject, name, playerType);
		}
		void SetupObserver(ISubject subject, string name, Contestant playerType)
		{
			this.name = name;
			this.playerType = playerType;
			this.myBoard = new Board();
			subject.RegisterPlayer(this);
		}
		public bool Update(string name)
		{
			Console.WriteLine($"{playerType} : Player's {name} move  :");
			// Play a move
			return false;
		}
	}
}
