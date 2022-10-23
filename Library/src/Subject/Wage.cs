using System;
using System.Collections.Generic;

using Library.src.Harbour;

/*
 *  Like "Wage War" 
*/
namespace Library.src.Subject
{
	public class Wage
	{
		BoardSize gridSize;
		public Wage(BoardSize gridSize)
		{
			this.gridSize = gridSize;
		}
		public Wage(int xSize, int ySize)
		{
			gridSize.X = xSize;
			gridSize.Y = ySize;
		}
		public bool PlayComputer(Wage battleField)
		{// Doe een zet 
			return false;
		}
	}
}