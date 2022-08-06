
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.src.Subject{
	public class Subject {

		public Subject() {
		}

		internal List players = new List<IObserver>()undefinedundefined;

		internal Board board;

		public void Subject() {
			// TODO implement here
		}

		/// <summary>
		/// @param board 
		/// @return
		/// </summary>
		public void RegiserBoard(Board board) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// @param observer 
		/// @param name 
		/// @return
		/// </summary>
		public void RegisterPlayer(Observer observer, string name) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// @param observer 
		/// @return
		/// </summary>
		public void RegisterPlayer(Observer observer) {
			// TODO implement here
			return null;
		}

		/// <summary>
		/// @return
		/// </summary>
		public bool NotifyPlayers() {
			// TODO implement here
			return False;
		}

		/// <summary>
		/// @return
		/// </summary>
		public void ShowPlayers() {
			// TODO implement here
			return null;
		}

	}
}