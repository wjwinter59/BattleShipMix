using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{/// <summary>
/// Player registreren ..... nader bekijken
/// </summary>
  public class ObserverComputer : IPlayer
  {
    string name;
    public ObserverComputer(string name, ISubject subject)
    {
      this.name = name;
      subject.RegisterPlayer(this);//Register Player with a Board
    }
    public void Update(string name)
    {
      Console.WriteLine($"Update Computer : {name}");
    }
  }
}
