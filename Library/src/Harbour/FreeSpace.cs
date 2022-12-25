using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src.Harbour
{
	/// <summary>
	/// List of locations where there is room for a ship
	/// </summary>
	internal class FreeSpace
	{
		List<Location> spaces;
		public FreeSpace()
		{
			spaces = new();
		}
		public void Add(Location space)
		{
			spaces.Add(space);
		}
		public int Length { get => spaces.Count; }
	}
}
