using System;
using Xunit;
using Library.src.Harbour;

namespace XTest
{
	public class LocationTest1
	{
		[Fact]
		public void SmallLargeTest()
		{
			// Arrange 
			Location small = new Location() { X = 1, Y = 2 };
			Location large = new Location() { X = 2, Y = 3 };

			// Act
			bool result = (small > large);

			// Assert
			Assert.False(result);
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
