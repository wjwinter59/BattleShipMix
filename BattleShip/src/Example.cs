using System;
using Library;

namespace BattleFleetHarbor
{
  /// <summary>
  /// Observer Design Pattern
  /// </summary>

  public class Example
  {
    public void DoExample ()
    {
      // Create IBM stock and attach players

      IBM ibm = new IBM("IBMpc", 120.00);
      ibm.Attach(new Player("Sorros"));
      ibm.Attach(new Player("Willempie"));
      ibm.Attach(new Player("Berkshire"));

      // Fluctuating prices will notify players

      ibm.Price = 120.10;
      ibm.Price = 121.00;
      ibm.Price = 121.00; //noc change ! do nothing
      ibm.Price = 120.50;
      ibm.Price = 120.75;
    }
  }
}
