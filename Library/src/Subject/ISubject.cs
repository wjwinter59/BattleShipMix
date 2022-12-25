using System;
using System.Collections.Generic;
using Library.src.Harbour;
using Library.src.Observer;


namespace Library.src.Subject
{
	/// <summary>
	/// The interface class
	/// </summary>
	/// 
	public interface ISubject
	{
		public void RegisterPlayer(IObserver observer, string name);
		public void RegisterPlayer(IObserver observer);
		bool Notify();
		// public void ShowFleet(Fleet navalShips);
	}
}

