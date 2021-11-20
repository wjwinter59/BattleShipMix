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
    public Subject(Board board)
    {
      this.board = board;
    }
    /// <summary>
    /// Registreer een bord bij het subject, bord kan appart worden samengesteld
    /// bord later toevoegen aan player want die hebben een 'eigen' bord en dat van de tegenstander
    /// </summary>   

    public void RegiserBoard(Board board)
    {
      this.board = board;
    }
    /// <summary>
    /// register default Board
    /// </summary>
    public void RegisterPlayer(IObserver observer, string name)
    //public void RegisterPlayer(IPlayer observer)
    {
      Console.WriteLine($"Adding {observer.GetType().Name} name : {name}");
      //observer.RegiserBoard(board);
      players.Add(observer);
    }
    public void RegisterPlayer(IObserver observer)
    //public void RegisterPlayer(IPlayer observer)
    {
      Console.WriteLine($"Adding default {observer.GetType().Name} name : {observer.Name}");
      //observer.RegiserBoard(board);
      players.Add(observer);
    }

    public bool NotifyPlayers()
    {
      Console.WriteLine($"Notifiing players");
      //while { }

      foreach (var player in players)
      {
        Console.WriteLine($"Notifying : {player.Name} to play it's move");
        if (player.Update(player.Name))
          return true; //Checken op lost ??
      }
      return false;
    }
    public void ShowPlayers()
    {
      Console.WriteLine($"Players :");
      foreach (var player in players)
      {
        Console.WriteLine($"\t :{player.Name}, is  {player.PlayerType} ");
        player.ShowFleet();
      }
    }
  }
}
