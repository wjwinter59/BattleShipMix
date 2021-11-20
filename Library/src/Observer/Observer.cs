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
    Board water;
    Fleet armada;

    public string Name { get { return name; } set { name = value; } }
    public Contestant PlayerType { get { return playerType; } set { playerType = value; } }

    public Observer(ISubject subject)
    {
      SetupObserver(subject, "Dummy", Contestant.Computer);
    }
    public Observer(ISubject subject, string name)
    {
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
      water = new Board();
      armada = new();
      water.RegisterFleet(new Fleet());
      subject.RegisterPlayer(this);
    }

    /// <summary>
    /// Start the move of player 'name', return 'true' when the player has won
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool Update(string name)
    {
      bool win = false;
      Console.WriteLine($"Start {playerType}'s move of {name}");
      win = water.PlayMove(water.BattleArea, playerType);
      return false; // standaard op nog 'geen  winnaar'
    }
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
