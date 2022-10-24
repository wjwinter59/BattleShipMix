using System;

using Library.src.Subject;
using Library.src.Observer;
using Library.src.Harbour;

namespace BattleShipGame
{
	class Program
	{
		static void DoNewGame()
		{
			Subject Battle = new Subject();
			Observer Player1 = new Observer(Battle, "Rene", Contestant.Human);
			Observer Player2 = new Observer(Battle,"IbmMetje");
			Observer Player3 = new Observer(Battle,"Willelm", Contestant.Human);

			Battle.ShowPlayers();
			Battle.NotifyPlayers();
		}
		static void Main(string[] args)
		{
			// Create a UTF-8/16 encoding.
			DoNewGame();
		}
	}
}
