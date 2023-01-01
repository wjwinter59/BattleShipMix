using Library.src.Harbour;
using Library.src.Subject;
using System;

namespace Library.src.Observer
{
	/// <summary>
	/// The 'Observer' interface
	/// </summary>
	public interface IObserver
	{
		public string Name { get; set; }
		public Contestant PlayerType { get; set; }
		public Board MyBoard { get; set; }
		public Fleet MyFleet { get; set; }
		bool Update(string name);
		Boolean DoMove();
	}

}
