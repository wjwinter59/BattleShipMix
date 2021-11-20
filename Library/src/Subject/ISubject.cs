using System;
using System.Collections.Generic;
using Library.src;


namespace Library
{
  /// <summary>
  /// The interface class
  /// </summary>
  /// 
  public interface ISubject
  {
    public void RegisterPlayer(IObserver observer, string name);
    public void RegisterPlayer(IObserver observer);
    public void RegiserBoard(Board board); // Bij de battle
    bool NotifyPlayers();
  }
}

