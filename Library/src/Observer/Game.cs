using System;
using System.Collections.Generic;
using Library.src;
using Library.src.Harbor;

namespace Library
{
  /// <summary>
  /// The 'ConcreteSubject' class
  /// </summary>

  public class Game : Board
  {
    List<Player> players = new List<Player>();
    List<BattleShip> armada = new();
    // Constructor
    public Game(BoardSize dimension) : base(new BoardSize { x = 10, y = 10 })
    {
      //AddFleet();
    }
    public void AddHumanPlayer(string name)
    {
      players.Add(new Human(name));
    }
    public void AddComputerPlayer(string name)
    {
      players.Add(new Computer(name));
    }

    public void AddFleet()
    {
      armada.Add(new BattleShip("Carrier", 5));
      armada.Add(new BattleShip("Battleship", 4));
      armada.Add(new BattleShip("Destroyer", 3));
      armada.Add(new BattleShip("Submarine", 3));
      armada.Add(new BattleShip("Patrolboat", 2));
      AddFleet("Willelm flottielje", armada);
    }
  }
}
