/// <summary>
/// The blue color [~] represents water that is unexplored.
// The red color [*] represents your/enemy ship being hit.
// The green color [O] represents your ship.
// The dark color is the position that is being shot, but miss.
// The left-hand side is your fireboat, where the right-hand side is the fire scoreboard by your enemy (computer).
// Indicators serve as a scoreboard to shows how many ships remaining of each player.
/// There are only two classes being created in this console, one is Position and another one is NavyAsset.
/// </summary>
namespace Library
{/// <summary>
 /// Since the Battleship board is 10 x 10, so it is not hard to imagine
 /// I define each position with (x,y) coordinates. 
 /// A Position class is created to store coordinate.
 /// </summary>
  public class Location
  {
    public int x { get; set; } = -1;
    public int y { get; set; } = -1;
    bool hit=false;
  }
}
