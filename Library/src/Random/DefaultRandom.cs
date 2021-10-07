using System;

namespace Library
{
public class DefaultRandom : IRandomize
  {
    private readonly Random random;

    public DefaultRandom()
    {
      random = new Random();
    }

    public int Get()
    {
      return random.Next();
    }
  }
}
