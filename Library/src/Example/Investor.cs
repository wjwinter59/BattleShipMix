using System;

namespace Library
{
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>

  public class Investor : IInvestor
  {
    private string name;
    private Stock stock;

    // Constructor

    public Investor(string name)
    {
      this.name = name;
    }

    public void Update(Stock stock)
    {
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
