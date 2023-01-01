using System;
using Xunit;
using Library.src.Harbour;

namespace XTest
{
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
}
