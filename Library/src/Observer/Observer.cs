using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library;
using Library.src;
using Library.src.Harbor;

namespace Library
{
  public class Observer : IObserver
  {
    string name;
    Contestant playerType;
    Fleet armada;

    public string Name { get { return name; } set { name = value; } }
    public Contestant PlayerType { get { return playerType; } set { playerType = value; } }

    public Observer(ISubject subject)
    {
      /*
            this.name = "Dummy";
            armada = new();
            this.playerType = Contestant.Computer;
            subject.RegisterPlayer(this);//Register Player with a subject
      */
      SetupObserver(subject, "Dummy", Contestant.Computer);
    }
    public Observer(ISubject subject, string name)
    {
      /*
            this.name = name;
            armada = new();
            this.playerType = Contestant.Computer;
            subject.RegisterPlayer(this);//Register Player with a subject
      */
      SetupObserver(subject, name, Contestant.Computer);
    }

    public Observer(ISubject subject, string name, Contestant playerType)
    {
      SetupObserver(subject, name, playerType);
    }

    void SetupObserver(ISubject subject, string name, Contestant playerType)
    {
      this.name = name;
      this.playerType = playerType;
      armada = new();
      subject.RegisterPlayer(this);
    }

    /// <summary>
    /// Start the move of player 'name', return true when the player has won
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Update(string name)
    {
      Console.WriteLine($"Update name from Observer: {name}");
      return false; // standaard op nog 'geen  winnaar'
    }
    /// <summary>
    /// Add a 'named' fleet by using a list of ships.
    /// Method should be added to the Board
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ships"></param>
    public void ShowFleet()
    {
      armada.Show();
    }
    public void ChangeFleet(List<BattleShip> newShips)
    {
      armada.BattleShips = newShips;
    }
  }
}
