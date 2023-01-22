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
	//public enum ShipPart { Stearn, Midship, Bow, Buffer, Gone, Water, Nothing };
	public enum ShipPart { Stearn, Midship, Bow, Gone, Nothing };

	public class Location
	{
		int x, y;
		int xLen = 0;
		int yLen = 0;
		BufferPart bufferPart;
		ShipPart shipPart;

		public int X { get { return x; } set { x = value; } }
		public int Y { get { return y; } set { y = value; } }
		public int XLen { get { return xLen; } set { xLen = value; } }	
		public int YLen	{ get { return yLen; } set { yLen = value; } }
		public ShipPart ShipPart { get { return shipPart; } set { shipPart = value; } }
		public BufferPart BufferPart { get { return bufferPart; } set { bufferPart = value; } }
		#region Constructor
		public Location()
		{
			x = -1;
			y = -1;
			shipPart = ShipPart.Nothing;
			//-1,-1 ipv 0.0, 0,0 initialiseren zou een geldige coordinaat opleveren 
			//  kan niet voor een leeg bord.
		}
		public Location(Location loc)
		{
			this.x = loc.x;
			this.y = loc.y;
			this.shipPart = loc.shipPart;
		}
		public Location(int x, int y, ShipPart shipPart)
		{
			this.x = x;
			this.y = y;
			this.shipPart = shipPart;
		}
		#endregion
		#region Overloading
		public override string ToString()
		{
			//return base.ToString() + $"location {X},{Y}";
			return $"location {X},{Y}";
		}
		/// <summary>
		/// gebruik bij bepalen van extent vanuit een list
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Location operator -(Location a, Location b)
		{
			Location tmp = new Location(); 
			tmp.XLen = b.X - a.X;
			tmp.YLen = b.Y - a.Y;
			return tmp;
		}
		public static Boolean operator <(Location a, Location b) //Useful ?
		{
			return (a.X < b.X) && (a.Y < b.Y);
		}
		public static Boolean operator >(Location a, Location b) //Useful ?
		{
			return (a.X > b.X) && (a.Y > b.Y);
		}
		#endregion
	}
}
