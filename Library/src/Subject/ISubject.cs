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
    public void RegisterPlayer(IPlayer observer, string name);
    //public void RegisterPlayer(IPlayer observer);
    public void RegiserBoard();
    void NotifyPlayers();
  }
}

