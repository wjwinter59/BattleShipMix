// The red color [*] represents your/enemy ship being hit.
// The green color [O] represents your ship.
// The dark color is the position that is being shot, but miss.
// The left-hand side is your fireboat, where the right-hand side is the fire scoreboard by your enemy (computer).
// Indicators serve as a scoreboard to shows how many ships remaining of each player.
using Library.src.Harbour;
using Library.src.Subject;

/// <summary>
/// The blue color [~] represents water that is unexplored.
/// There are only two classes being created in this console, one is Position and another one is NavyAsset.
/// </summary>
namespace Library
{
  public class Location
  {
    int x, y;
    BoardPart part;
    public int X { get { return x; } set { x = value; } }
    public int Y { get { return y; } set { y = value; } }
    public BoardPart Part { get { return part; } set { part = value; } }
    // bool hit=false;
    public Location()
    {
      x = 0;
      y = 0;
      part = BoardPart.Buffer;
    }
    public Location(Location loc)
    {
      this.x = loc.x;
      this.y = loc.y;
      this.part = loc.part;
    }
    public Location(int x, int y, BoardPart part)
    {
      this.x = x;
      this.y = y;
      this.part = part;
    }
  }
}
