using System;
using System.Collections.Generic;

namespace Library
{
  /// <summary>
  /// The 'Subject' abstract class
  /// </summary>

  public abstract class GameTwee
  {
    private string symbol;
    private double price;
    private List<IPlayer> players = new List<IPlayer>();

    // Constructor

    public GameTwee(string symbol, double price)
    {
      this.symbol = symbol;
      this.price = price;
    }

    public void Attach(IPlayer player)
    {
      players.Add(player);
    }

    public void Detach(IPlayer player)
    {
      players.Remove(player);
    }

    public void Notify()
    {
      foreach (IPlayer player in players)
      {
        //player.Update(this);
      }

      Console.WriteLine("");
    }

    // Gets or sets the price

    public double Price
    {
      get { return price; }
      set
      {
        if (price != value)
        {
          price = value;
          Notify();
        }
      }
    }

    // Gets the symbol

    public string Symbol
    {
      get { return symbol; }
    }
  }
}
