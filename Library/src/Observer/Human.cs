using System;

namespace Library
{
  /// <summary>
  /// The 'ConcreteObserver' class
  /// </summary>

  public class Human : Player
  {
    public Human(string name) : base(name) { }
    public Human(string name, Board zee) : base(name) { }
    public override void Update(Board sea)
    { //get input 
      Console.WriteLine($"Notified {Name} of ??" );
    }
  }
}
