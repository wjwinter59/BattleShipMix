using System;

namespace Library.src.Harbour
{
  public enum Contestant { Human, Computer };
  public enum GamePiece { Water, Splash, Ship, Bommed };
  public struct BoardSize
  {
    public int x;
    public int y;
  }
  /// <summary>
  /// Space holds information in order to determine where to place a ship on the grid.
  /// </summary>
  public struct Space
  {
    public int x;
    public int y;
    public int spaceLength;
    public bool horizontal;
  }
  public static class ShipPart
  {
    public const char SL = '\u25C4'; //'\u25D6'; // Ship left
    public const char SR = '\u25BA'; //'\u25D7'; // Ship rigth
    public const char SU = '\u25B2'; //'\u2BCA'; // Ship Up
    public const char SD = '\u25BC'; //'\u2BCB'; // Ship down
    public const char SM = '\u25A0'; //'\u25FC'; // Ship middle
    public const char SB = '\u263C'; // Bomb
    public const char SW = '\u2248'; // Water
    public static void Show()
    {
      Console.WriteLine($"{ShipPart.SD.GetType()} {ShipPart.SL}, {ShipPart.SR}, {ShipPart.SU}, {ShipPart.SW}");
    }
  }
}
