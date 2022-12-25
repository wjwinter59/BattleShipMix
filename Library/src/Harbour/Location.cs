// The red color [*] represents your/enemy ship being hit.
// The green color [O] represents your ship.
// The dark color is the position that is being shot, but miss.
// The left-hand side is your fireboat, where the right-hand side is the fire scoreboard by your enemy (computer).
// Indicators serve as a scoreboard to shows how many ships remaining of each player.
using Library.src.Harbour;
using Library.src.Subject;
using System;

/// <summary>
/// The blue color [~] represents water that is unexplored.
/// There are only two classes being created in this console, one is Position and another one is NavyAsset.
/// </summary>
namespace Library.src.Harbour
{
	public class Location
	{
		int x, y;
		BoardPart part;
		public int X { get { return x; } set { x = value; } }
		public int Y { get { return y; } set { y = value; } }
		public BoardPart Part { get { return part; } set { part = value; } }
		#region Constructor
		public Location()
		{
			x = -1;
			y = -1;
			part = BoardPart.Nothing;
			//-1,-1 ipv 0.0, 0,0 initialiseren zou een geldige coordinaat opleveren 
			//  kan niet voor een leeg bord.
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
		#endregion
		#region Overloading 
		public static Location operator -(Location a, Location b)
		{
			Location len = new Location(); 
			len.X = a.X - b.X;
			len.Y = a.Y - b.Y;
			return len;
		}
		public static Boolean operator <(Location a, Location b)
		{
			return (a.X < b.X) && (a.Y < b.Y);
		}
		public static Boolean operator >(Location a, Location b)
		{
			return (a.X > b.X) && (a.Y > b.Y);
		}
		#endregion
	}
}
