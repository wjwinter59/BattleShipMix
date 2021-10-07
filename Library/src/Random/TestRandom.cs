using System;
using System.Collections.Generic;

namespace Library
{
   public class TestRandom : IRandomize
  {
    private readonly List<int> numbers;
    private int top;

    public TestRandom()
    {
      numbers = new List<int> { 1, 1, 2, 3, 5, 8, 13, 21 };
      top = 0;
    }

    public int Get()
    {
      return (top >= numbers.Count)
              ? 0
              : numbers[top++];
    }
  }
}
