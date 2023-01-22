using System;
using Xunit;
using Library.src.Harbour;
using Library.src.Subject;
using System.Collections.Generic;

namespace XTest
{
	public class FleetTest
	{
		[Fact]
		public void Extent()
		{
			// Arrange 

			List<BattleShip> EnglishFleet = new List<BattleShip>{
				new BattleShip("Carrier", 5),
				new BattleShip("Battleship", 4),
				new BattleShip("Destroyer", 3),
				new BattleShip("Submarine", 3),
				new BattleShip("Patrolboat", 2)
		};
			// Act
			Fleet vloot = new Fleet("vlootje", EnglishFleet);

			// Assert
			Assert.Equal("Carrier", EnglishFleet[0].Name);
			Assert.Equal("Extent 0,2,1,5", EnglishFleet[0].ExtentShip.ToString());
		}
	}
	/*
	public class InlineRange
	{
		Location small;
		Location large;

		[Theory]
		[InlineData(2, 0)]
		[InlineData(1, 3)]
		[InlineData(100, 97)]
		public void CheckOperatorLess(int x, int y)
		{
			Boolean s;
			small = new Location() { X = x, Y = y };
			large = new Location() { X = x + 1, Y = y + 1 };

			s = (small < large);
			Assert.True(s); // should be 'True' index 

			s = (small.X > large.Y);
			Assert.True(s);
		}
	}
	*/
}
