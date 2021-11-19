using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.src;

namespace Library
{
  public class Observer : IObserver
  {
    string name;
    Contestant playerType;
    public string Name { get { return name; } set { name = value; } }
    public Contestant PlayerType { get { return playerType; } set { playerType = value; } }

    public Observer(ISubject subject, string name, Contestant playerType)
    {
      this.name = name;
      this.playerType = playerType;
      subject.RegisterPlayer(this, "Default");
    }

    public Observer(ISubject subject, string name)
    {
      this.name = name;
      this.playerType = Contestant.Computer;
      subject.RegisterPlayer(this, name);//Register Player with a subject
    }

    public void Update(string name)
    {
      Console.WriteLine($"Update name from Observer: {name}");
    }
  }
}
