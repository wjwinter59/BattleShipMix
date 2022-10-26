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
		private Board privateBoard;
		private Fleet privateFleet;
		public string Name { get { return name; } set { name = value; } }
		public Fleet PrivateFleet { get { return privateFleet; } set { privateFleet = value; } }
		public Board PrivateBoard { get { return privateBoard; } set { privateBoard = value; } }
		public Contestant PlayerType { get { return playerType; } set { playerType = value; } }

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
			this.privateBoard = new Board();
			// privateBoard.dbgShow();
			subject.RegisterPlayer(this);
		}
		// Update is play move ?
		public bool Update(string name)
		{
			Console.WriteLine($"Start player {name}'s Update type player {playerType}");
			return false;
		}
	}
}
