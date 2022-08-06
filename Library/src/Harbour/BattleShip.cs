using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.src.Harbour
{/// <summary>
/// BattleShip holds info about the ship
/// </summary>
  public class BattleShip
  {
    int length = 0;
    string name = "Drop";
    List<Location> location;
    public string Name { get => name; }
    public int Length { get => length; }
    public List<Location> Location { get => location; set => location = value; }
    /// <summary>
    /// Initialize 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="length"></param>
    public BattleShip(string name, int length)
    {
      this.name = name;
      this.length = length;
      location = new List<Location>(); //Filled if placed on the grid
      // make list of possible places (hor and ver) based on length of the ship
      // and change the Gridcell according to GamePiece.Ship
    }
  }
}
