namespace Library.src.Harbour
{
  public class BoardSize
  {
    int x;
    int y;
    public BoardSize(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
    public int X { get { return x; } set { x = value; } }
    public int Y { get { return y; } set { y = value; } }
    public override string ToString() => $"({X}, {Y})";
  }
}