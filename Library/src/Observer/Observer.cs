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
		private Board myBoard; // Holds board given by the Subject class
		private Fleet myFleet; // Holds fleet given by the Subject class

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

			subject.RegisterPlayer(this); // register board and fleet from within Subject class
		}
		public bool Update(string name)
		{
			Console.WriteLine($"{playerType} : Player's {name} move  :");
			// Play a move ?? but when
			return false;
		}
		public Boolean DoMove()
		{
			return true;
		}
		// Nieuw nog uitwerken
		//public void dbgShow(BoardSize size, List<Location> locationList) // Werkt wel
		public void dbgShow() // 
		{
			Location location;
			Console.WriteLine($"Board ship locations.");
			try
			{
				for (int j = 0; j < MyBoard.Size.Y; j++)
				{
					for (int i = 0; i < MyBoard.Size.X; i++)
					{
						location = MyBoard.FleetLocations.Find(loc => (loc.X == i) & (loc.Y == j));
						if (location != null)
							//Console.Write($"{location.X},{location.Y}\t");
							Console.Write($"{location.ShipPart}\t");
						else
							Console.Write($"?\t");
					}
					Console.WriteLine();
				}
			}
			catch
			{
				Console.Write($"Shit\t");
			}
		}
	}
}
