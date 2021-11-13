using System;
using System.Collections.Generic;
using Library.src;

namespace Library
{
  /// <summary>
  /// The 'ConcreteSubject' class
  /// </summary>
  public class Game : Player
  {
    List<Player> players = new List<Player>();
    List<BattleShip> armada = new();
    //Board sea;
    BoardSize dimension;
    // Constructor

    public Game(BoardSize dimension)// : base(new BoardSize { x = 10, y = 10 })
    {
      this.dimension=dimension; //waarschijnlijk overbodig
    }
    public void AddPlayer (Player player){
      player.zee = new Board();
      players.Add(player);
      Console.WriteLine($"{player.Name} entered the game.");
    }
    /*
    public void AddHumanPlayer(string name)
    {
      players.Add(new Human(name));
      Console.WriteLine($"{name} entered the game.");
    }
    public void AddComputerPlayer(string name)
    {
      players.Add(new Computer(name));
      Console.WriteLine($"Computer {name} entered the game.");
    }
    */
    public override void Update(Board sea) {
      Console.WriteLine($"Update from Game {sea.ToString() }");
    }
    public void ShowPlayers(){
      foreach (var player in players)
      {
        Console.WriteLine($"{player.Name}");
      }
    }
    public void AddFleet()
    {
      armada.Add(new BattleShip("Carrier", 5));
      armada.Add(new BattleShip("Battleship", 4));
      armada.Add(new BattleShip("Destroyer", 3));
      armada.Add(new BattleShip("Submarine", 3));
      armada.Add(new BattleShip("Patrolboat", 2));
      //AddFleet("Willelm flottielje", armada);
    }
  }
}
