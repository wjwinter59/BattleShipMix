using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.src;

namespace Library
{/// <summary>
/// Player registreren ..... nader bekijken
/// </summary>
  public class ObserverComputer : IObserver
  {
    string name;
    Contestant playerType;

    public string Name { get => name; set { name = value; } }
    public Contestant PlayerType { get { return playerType; } set { playerType = value; } }

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
