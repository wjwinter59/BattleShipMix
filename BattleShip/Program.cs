using System;
using System.Collections.Generic;

using Library.src.Subject;
using Library.src.Observer;
using Library.src.Harbour;
using System.Text;

namespace BattleShipGame
{
	class Program
	{
		static void DoNewGame()
		{
			Subject Battle = new Subject();
			Battle.RegisterPlayer(new Observer("Rene", Contestant.Human));
			Battle.RegisterPlayer(new Observer("IbmMetje"));
			Battle.RegisterPlayer(new Observer("Willelm", Contestant.Human));

			Battle.ShowPlayers();

			Battle.NotifyPlayers();
		}
		static void Main(string[] args)
		{
			// Create a UTF-8 encoding.
			DoNewGame();
		}
	}
}
