using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Library.src.Harbour
{
	public class Extent
	{
		#region get set 
		public int MinX { get; set; }
		public int MinY { get; set; }
		public int MaxX { get; set; }
		public int MaxY { get; set; }
		public Extent ExtentThis { get { return this; } } //I don't like this
		#endregion
		/// <summary>
		/// Initialize the Extent with the first element of a possible future series of locations
		/// </summary>
		/// <param name="init"></param>
		#region Constructors
		public Extent() { }
		public Extent(int minX, int maxX, int minY, int maxY)
		{
			this.MinX = minX;
			this.MaxX = maxX;
			this.MinY = minY;
			this.MaxY = maxY;
		}
		public Extent(List<Location> locations)
		{
			CalcExtent(locations);
		}
		#endregion
		/// <summary>
		/// Initialize the internal extent properties, use 'AddExtent' to test the rest
		/// </summary>
		/// <param name="extend"></param>
		public void InitExtent(Location extent)
		{
			this.MinX = extent.X;
			this.MinY = extent.Y;
			this.MaxX = extent.X;
			this.MaxY = extent.Y;
		}
		/// <summary>
		/// Add one location to the internal properties class
		/// </summary>
		/// <param name="extend"></param>
		public void AddExtent(Location extent)
		{
			MinX = (extent.X < MinX) ? extent.X : MinX;
			MinY = (extent.Y < MinY) ? extent.Y : MinY;
			MaxX = (extent.X > MaxX) ? extent.X : MaxX;
			MaxY = (extent.Y > MaxY) ? extent.Y : MaxY;
		}
		public void CalcExtent(List<Location> locations)
		{
			try
			{
				InitExtent(locations[0]); // Use the first location from the list to have a correct initialisation
				foreach (var item in locations)
					AddExtent(item);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("Locations list is empty. Unable to optain the Extent.");
			}
		}
		public void Show()
		{
			Console.Write($"Extent :");
			Console.WriteLine($"\tmin X:{MinX}\tmax X:{MaxX}\tmin Y:{MinY}\tmax Y:{MaxY}");
		}
		/// <summary>
		/// Usable for testing :)
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"Extent ({MinX},{MaxX},{MinY},{MaxY})";
	}
}