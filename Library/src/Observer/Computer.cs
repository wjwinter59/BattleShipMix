using System;

namespace Library
{
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>

  public class Computer : Player
  {
    public Computer(string name) : base(name) { }
    public override void Update(Board sea)
    { //get input 
      Console.WriteLine($"Notified {Name} of ??" );
    }
  }
}
