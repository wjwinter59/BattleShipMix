using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
  public class Observer : IPlayer
  {
    string name;
    public Observer(string name, ISubject subject)
    //public Observer(string name)
    {
      this.name = name;
      subject.RegisterPlayer(this);//Register Player with a Board
    }
    public void Update(string name)
    {
      Console.WriteLine($"Update name : {name}");
    }
  }
}
