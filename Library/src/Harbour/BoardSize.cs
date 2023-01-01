namespace Library.src.Harbour
{
	public class BoardSize
	{
		public BoardSize()
		{
			this.X = 10;
			this.Y = 10;
		}
		public BoardSize(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
		public int X { get; set; }
		public int Y { get; set; }
		public override string ToString() => $"({X}, {Y})";
	}
}