using System;
using System.Collections.Generic;

namespace Library.src.Harbor
{
  public class Fleet
  {
    string name = "";
    List<BattleShip> battleShips;
    public List<BattleShip> BattleShips{ get => battleShips; }
    
    public Fleet (string name, List<BattleShip> battleShips)
    {
      this.name = name;
      this.battleShips = battleShips;
    }
    public void AddShip(BattleShip ship)
    {
      battleShips.Add(ship);
    }

    public void Show()
    {
      BattleShip vessel;
      foreach (var ship in battleShips)
      {
        Console.Write($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
        vessel = ship;
        foreach (var part in vessel.Location)
          Console.Write($": {part.x},{part.y}");
        Console.WriteLine("");
      }
    }
  }
}
