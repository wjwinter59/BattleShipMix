using System;
using System.Text;

namespace Library.src.Harbour
{
	public enum Contestant { Human, Computer };
	public enum GamePiece { Water, Splash, Ship, Bommed };
	public enum ShipPart { Stearn, Midship, Bow, Gone };
	public struct BoardSize
	{
		public int x;
		public int y;
	}
	/// <summary>
	/// Space holds information in order to determine where to place a ship on the grid.
	/// all available spaces are listed and one ship.
	/// </summary>
	public struct Space
	{
		public int x;
		public int y;
		public int spaceLength;
		public bool horizontal;
	}
	/// <summary>
	/// Uitzoeken hoe dit goed op te zetten via Unicodes
	/// </summary>
	public static class ShipSymbol
	{
		public const char SL = '\u25C4'; // Ship left
		public const char SR = '\u25BA'; // Ship rigth
		public const char SU = '\u25B2'; // Ship Up
		public const char SD = '\u25BC'; // Ship down
		public const char SM = '\u25A0'; // Ship middle
		public const string SS = "\u263A"; // Ship Single
		//public const string SS = "S"; // Ship Single
		public const string SB = "B"; // Bomb
		public const char SW = '\u2591'; // Water
		public static void Show()
		{
			Console.WriteLine($"Ship  Symbols : {ShipSymbol.SL}, {ShipSymbol.SR}, {ShipSymbol.SU}, {ShipSymbol.SD}, {ShipSymbol.SM}");
			Console.WriteLine($"Other Symbols : {ShipSymbol.SS}, {ShipSymbol.SB}, {ShipSymbol.SW}");
		}
	}
	/// <summary>
	/// Test zooi voor unicode 
	/// </summary>
	public static class MathSymb {
		public const char PlusMinSL = '\u2200'; // Ship left
		public static void Show()
		{
			Console.WriteLine($"Math  Symbols : {MathSymb.PlusMinSL}");
		}
	}
}
