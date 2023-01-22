using Library.src.Harbour;
using Library.src.Subject;
using System.Collections.Generic;
using Xunit;

namespace XTest
{
	public class Orientation
	{
		BattleShip s;
		[Fact]
		public void ShowHorVer()
		{
			// Arrange 
			s = new BattleShip("Carrier", 5);
			// Act
			// Create a vertical position based on the fact that the x value remains the same
			s.AddLocation(new Location(0, 1, ShipPart.Bow));
			s.AddLocation(new Location(0, 2, ShipPart.Stearn));

			// Assert
			Assert.False(s.Horizontal);
			Assert.True(s.Vertical);
		}

		[Fact]
		public void ShowDiagonal()
		{
			s = new BattleShip("Bootje", 3);
			// Act
			// Create a diagonal position
			// based on the fact that neither x and y keep the same value
			s.AddLocation(new Location(0, 1, ShipPart.Bow));
			s.AddLocation(new Location(1, 2, ShipPart.Stearn));
			// Assert 
			// because neither x or y keep the same value both test should be false
			Assert.False(s.Horizontal);
			Assert.False(s.Vertical);
		}
	}
}
