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
    List<IPlayer> players = new List<IPlayer>();
    Board board;
    BoardSize sea; //sea als in de vazameling van oceanen
    Fleet armada;
    Grid battleArea;
    public Subject(BoardSize sea)
    {
      this.sea = sea;
      battleArea = new Grid(sea.x, sea.y);
    }
    public Subject()
    {

    }
    /// <summary>
    /// Registreer een bord bij het subject, bord kan appart worden samengesteld
    /// bord later toevoegen aan player want die hebben een 'eigen' bord en dat van de tegenstander
    /// </summary>
    /// <param name="ocean"></param>
    public void RegiserBoard(BoardSize ocean)
    {
      board = new Board(ocean);
    }
    /// <summary>
    /// register default Board
    /// </summary>
    public void RegiserBoard()
    {
      board = new Board(sea);
    }

    public void RegisterPlayer(IPlayer observer)
    {
      players.Add(observer);
    }

    public void NotifyPlayers()
    {
      Console.WriteLine($"Notifiing players");
      foreach (var player in players)
        player.Update(player.ToString());
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
