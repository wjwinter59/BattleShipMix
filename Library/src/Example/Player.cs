using System;

namespace Library
{
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>

  public class Player : IPlayer
  {
    private string name;
    private Stock stock; // make it a grid

    // Constructor

    public Player(string name)
    {
      this.name = name;
    }

    public void Update(Stock stock)
    { //get input 
      Console.WriteLine($"Notified {name} of {stock.Symbol}'s change to {stock.Price:C}" );
    }

    // Gets or sets the stock

    public Stock Stock
    {
      get { return stock; }
      set { stock = value; }
    }
  }
}
