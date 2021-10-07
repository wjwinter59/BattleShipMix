using System;

namespace Library
{
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>

  public class Player : IPlayer
  {
    private string name;
    //private Stock stock; // make it a grid

    // Constructor

    public Player(string name)
    {
      this.name = name;
    }

    public void Update(Board sea)
    { //get input 
      Console.WriteLine($"Notified {name} of ??" );
    }

    // Gets or sets the stock

    public string Name
    {
      get { return name; }
      set { name = value; }
    }
  }
}
