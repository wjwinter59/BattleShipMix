using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
  public class Observer : IPlayer
  {
    string name;
    public string Name { get=>name; }
    public Observer( ISubject subject, string name)
    {
      this.name = name;
      subject.RegisterPlayer(this, name);//Register Player with a subject
    }
    public void Update(string name)
    {
      Console.WriteLine($"Update name from Observer: {name}");
    }
  }
}
