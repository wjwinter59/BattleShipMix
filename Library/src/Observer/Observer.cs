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
		private Board battleGround;

		private Fleet armada = new("Middeleeuwen",
		new List<BattleShip> {
					new BattleShip("Drager", 6),
					new BattleShip("Vechter", 7),
					new BattleShip("Kapotmaker", 3),
					new BattleShip("Duiker", 6),
					new BattleShip("Vlot", 1)
		}
	);
		public string Name { get { return name; } set { name = value; } }
		public Fleet Armada { get { return armada; } set { armada = value; } }
		public Board BattleGround { get { return battleGround; } set { battleGround = value; } } 
		public Contestant PlayerType { get { return playerType; } set { playerType = value; } }
		public Observer(ISubject subject)
		{
			SetupObserver(subject, "Computer Dummy", Contestant.Computer);
		}
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
			this.battleGround=new Board();
			subject.RegisterPlayer(this);
		}

		public bool Update(string name)
		{
			// bool win = false;
			Console.WriteLine($"Start {playerType}'s move of {name}");
			// win = water.PlayMove(water.BattleArea, playerType);
			return false; // standaard op nog 'geen  winnaar'
		}
		public void ShowFleet(){
			Console.WriteLine("Ëmpty fleet");
		}
	}
}
