using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Library;

namespace Library.src
{/// <summary>
/// BattleShip holds info about the ship
///   based on the info in NavyAsset class ;)
/// </summary>
  public class BattleShip
  {
    
      int length = 0;
    string name = "SUNK";
    bool sunk = false;
    bool checkStatus;
    List<Location> location; 
    public string Name { get => name; }
    public int Length { get => length; }
    /// <summary>
    /// Initialize 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="length"></param>
    public BattleShip(string name, int length)
    {
      this.name = name;
      this.length = length;
      // make list of possible places (hor and ver) based on length of the ship
      // and change the Gridcell according to Kind.Ship
    }
  }
}
