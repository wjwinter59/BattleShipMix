using System;
using System.Collections.Generic;
using Library.src;
using Library.src.Harbor;

namespace Library
{/// <summary>
/// Is copy of Board, trying to creaate two inplemantations, by abstract and interface
/// </summary>
  public class Subject : ISubject
  {
    List<IObserver> players = new List<IObserver>();
    Board board;
    BoardSize sea; //sea als in de vazameling van oceanen, hoort hier niet.
    Fleet armada;
    Grid battleArea;
    public Subject(Board sea)
    {
      this.sea = sea.Ocean;
      board = sea;
      battleArea = new Grid(sea.Ocean.x, sea.Ocean.y);
    }
    public Subject()
    {
      this.sea = new BoardSize { x = 10, y = 10 };
      board = new Board(sea);
      battleArea = new Grid(sea.x, sea.y);
    }
    /// <summary>
    /// Registreer een bord bij het subject, bord kan appart worden samengesteld
    /// bord later toevoegen aan player want die hebben een 'eigen' bord en dat van de tegenstander
    /// </summary>
    /// <param name="ocean"></param>
    public void RegiserBoard(Board board)
    {
      this.board = board;
    }
    /// <summary>
    /// register default Board
    /// </summary>
    public void RegiserBoard()
    {
      board = new Board(sea);
    }
    public void RegisterPlayer(IObserver observer, string name)
    //public void RegisterPlayer(IPlayer observer)
    {
      Console.WriteLine($"Adding {observer.GetType().Name} name : {name}");

      //observer.RegiserBoard(board);
      players.Add(observer);
    }

    public void NotifyPlayers()
    {
      Console.WriteLine($"Notifiing players");
      foreach (var player in players)
      {
        Console.WriteLine($"Notifying : {player.Name} to play it's move");
        player.Update(player.Name); //Checken op lost ??
      }
    }
    public void ShowPlayers()
    {
      Console.WriteLine($"Players :");
      foreach (var player in players)
      {
        Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
      }
    }

    /// <summary>
    /// FindPlacesOnTheGrid becomes place fleet on the grid
    /// </summary>
    /// <param name="armada"></param>
    public void AddFleet(Fleet armada)
    {
      battleArea.PutFleetOnTheGrid(armada);
    }
    /// <summary>
    /// Add a 'named' fleet by using a list of ships.
    /// Method should be added to the Board
    /// </summary>
    /// <param name="name"></param>
    /// <param name="ships"></param>
    public void AddFleet(string name, List<BattleShip> ships)
    {
      armada = new Fleet(name, ships);
      battleArea.PutFleetOnTheGrid(armada);
    }
    public void ShowFleet()
    {
      armada.Show();
    }
  }
}
