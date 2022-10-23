using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src.Harbour
{
		enum Direction { Horizontal, Vertical, Undefined }
/// <summary>
/// Start locations where a ship can be placed
/// </summary>
	internal class Space
	{
		int x;
		int y;
		Direction hv;
	}
}
