using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src.Harbour
{
	class LocationList<T> : List<T>
	{
		public new void Add(T obj)
		{
			Location l = obj as Location;
			if ((l.X <0 ) || (l.X > 6))
				base.Add(obj);
		}
	}
}
