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
      // Create IBM stock and attach investors

      IBM ibm = new IBM("IBMpc", 120.00);
      ibm.Attach(new Investor("Sorros"));
      ibm.Attach(new Investor("Willempie"));
      ibm.Attach(new Investor("Berkshire"));

      // Fluctuating prices will notify investors

      ibm.Price = 120.10;
      ibm.Price = 121.00;
      ibm.Price = 121.00; //noc change ! do nothing
      ibm.Price = 120.50;
      ibm.Price = 120.75;
    }
  }
}
