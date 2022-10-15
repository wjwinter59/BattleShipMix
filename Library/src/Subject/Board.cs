using System;
using Library.src.Harbour;

namespace Library.src.Subject
{
	public class Board
	{
		BoardSize sea; //sea als in de vazameling van oceanen

		public BoardSize Sea { get { return sea; } }
		public Board(BoardSize ocean)
		{
			this.sea = ocean;
		}
		public Board()
		{
			this.sea = new BoardSize { x = 10, y = 10 };
		}
		/*
				public bool PlayMove(Wage battleField, Contestant playerType)
				{
					if (playerType == Contestant.Computer)
					{
						Console.WriteLine($"Playing {playerType}'s move");
						return battleField.PlayComputer(battleField);
					}
					else
						Console.WriteLine($"Scipping  {playerType}'s move");

					return false;
				}
		*/
		public void RegisterFleet(Fleet armada)
		{
			// battleArea.PutFleetOnTheGrid(armada);
			armada.Show();
		}
	}
}
