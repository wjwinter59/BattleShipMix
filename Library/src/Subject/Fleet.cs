using System;
using System.Collections.Generic;

namespace Library.src.Subject
{
    public class Fleet
    {
        string name = "Default ships";
        List<BattleShip> battleShips;
        public List<BattleShip> BattleShips { get => battleShips; set => battleShips = value; }
        public Fleet()
        {
            battleShips = new List<BattleShip>{
                new BattleShip("Carrier", 5),
                new BattleShip("Battleship", 4),
                new BattleShip("Destroyer", 3),
                new BattleShip("Submarine", 3),
                new BattleShip("Patrolboat", 2)
            };
        }

        public Fleet(string name, List<BattleShip> battleShips)
        {
            this.name = name;
            this.battleShips = battleShips;
        }
        public void AddShip(BattleShip ship)
        {
            battleShips.Add(ship);
        }


        public void Show()
        {
            BattleShip vessel;
            foreach (var ship in battleShips)
            {
                Console.Write($"Ship :{ship.Name}\t\tlength: {ship.Length}\t");
                vessel = ship;
                foreach (var part in vessel.Locations)
                    Console.Write($": {part.x},{part.y}");
                Console.WriteLine("");
            }
        }
    	public Boolean Embark(List<BattleShip> fleet)
		{
			List<Location> los;   // List Occupied places
			List<Location> las; // List available spaces
			foreach (var ship in fleet)
			{
				los = FindOccupied(fleet);
				las = GetEmptySpotsList(los);
			}
            return true;
        }
     	/// <summary>
		/// Build list of locations retrieved from  all Battleships
		/// </summary>
		/// <param name="fleet"></param>
		/// <returns></returns>
		List<Location> FindOccupied(List<BattleShip> fleet)
		{
			List<Location> tmpList = new();
			foreach (var ship in fleet)
				tmpList.AddRange(ship.Locations);
			return tmpList;
		}
		List<Location> GetEmptySpotsList(List<Location> locations)
		{
			List<Location> tmpList = new();
			return tmpList;
		}

    }
}
