using System;
using System.Collections.Generic;
using Library.src.Harbour;

namespace Library.src.Subject
{
    public enum BoardPart { Stearn, Midship, Bow, Buffer, Gone, Water, Nothing };

    public class Board
    {
        BoardSize battleArea;  // 
        Fleet navalFleet;

        public BoardSize BattleArea { get { return battleArea; } }
        public Fleet NavalFleet { get { return navalFleet; } set { navalFleet = value; } }
        public Board()
        {
            battleArea = new BoardSize { x = 10, y = 10 };
            navalFleet = new Fleet();
            navalFleet.SetSail(navalFleet.BattleShips);
            Show();
        }
        public void Show() // Werkt niet
        {
            Location location;
            Console.WriteLine($"Fleet : \"{navalFleet.Name}\" Board situations");
            try
            {
                for (int i = 0; i < battleArea.x; i++)
                {
                    for (int j = 0; j < battleArea.y; j++)
                    {
                        location = navalFleet.BoardSituation.Find (loc => (loc.X == i) & (loc.Y == j));
                        if (location != null)
                            //Console.Write($"{location.Part}\t");
														Console.Write($"{location.X},{location.Y}\t");
                        else Console.Write($"?\t");
                    }
										Console.WriteLine(); 
                }
            }
            catch
            {
                Console.Write($"?\t");
            }
        }
    }
}
