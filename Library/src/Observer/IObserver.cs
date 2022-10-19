using System;
using System.Xml.Linq;
using Library.src.Harbour;
using Library.src.Subject;

namespace Library.src.Observer
{
	/// <summary>
	/// The 'Observer' interface
	/// </summary>

	public interface IObserver
	{

		public string Name { get; set; }
		public Contestant PlayerType { get; set; }
		public Board BattleGround { get; set; } 
		bool Update(string name);
		public void ShowFleet();
	}

}
