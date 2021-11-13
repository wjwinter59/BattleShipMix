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
    public string Name { get => name; }
    public ObserverComputer( ISubject subject, string name)
    {
      this.name = name;
      subject.RegisterPlayer(this, name);//Register Player with a Board
    }
    public void Update(string name)
    {
      Console.WriteLine($"Update Computer : {name}");
    }
  }
}
