using System;
using System.Collections.Generic;

/// <summary>
/// Cells hold the status of the gridcells by enum
/// </summary>
namespace Library.src.Harbour
{
    /// <summary>
    /// initilaize the grid to GamePiece.Water sized by x,y parameeres
    /// </summary>

    public class Grid
    {
        GamePiece[,] cells; // Changes to list in version 2 ?
        List<GamePiece> pieceList; // For second version
        BoardSize gridSize;
        public GamePiece[,] Cells { get => cells; }
        public Grid(BoardSize gridSize)
        {
            this.gridSize = gridSize;
            InitGrid(gridSize, GamePiece.Water);
        }
        public Grid(int xSize, int ySize)
        {
            gridSize.x = xSize;
            gridSize.y = ySize;
            InitGrid(gridSize, GamePiece.Water);
        }
        void InitGrid(BoardSize grid, GamePiece what)
        {
            cells = new GamePiece[grid.x, grid.y];

            for (int i = 0; i < grid.x; i++)
            {
                for (int j = 0; j < grid.y; j++)
                {
                    cells[i, j] = what;
                }
            }
        }
        public bool PlayComputer(Grid battleField)
        {// Doe een zet 
            return false;
        }
        /// <summary>
        /// New method for adding a Fleet to the board, start with empty grid 
        /// </summary>
        /// <param name="armada"></param>
        public void PutFleetOnTheGrid(Fleet armada)
        {
            foreach (var ship in armada.BattleShips)
                //TryShipOnTheGrid(ship); // Moet put worden en try in de put poging returning boolean of het gelukt is
                PutShipOnTheGrid(ship); // Moet put worden en try in de put poging returning boolean of het gelukt is
        }
        /// <summary>
        /// Holds a list of coordinates that will hold 1 ship, one ship is randomply chosen from the list
        /// if the list is empty than there is no room for the ship of size 'length' on the grid
        /// the length property will provide a number from witch the ship wil start randomly
        /// </summary>
        //public void TryShipOnTheGrid(BattleShip ship)
        public bool PutShipOnTheGrid(BattleShip ship)
        { // hash table van maken ?
            List<Space> Spaces = new List<Space>();

            FindXSpace(Spaces, ship);
            Console.WriteLine($"Ship : {ship.Name} \t length {ship.Length} \t X Spaces : {Spaces.Count}");
            FindYSpace(Spaces, ship);
            Console.WriteLine($"Ship : {ship.Name} \t length {ship.Length} \t Y Spaces : {Spaces.Count}");

            if (Spaces.Count > 0)
            {
                PlaceBattleShip(Spaces, ship); // Moet true of false gaan opleveren 
                Console.WriteLine($"Peices so far :");
                foreach (var cel in cells)
                {
                    if (cel != GamePiece.Water)
                        Console.Write($"{cel}"); // Contens of Grid
                }
                return true;
            }
            // Er was geen ruimte voor een schip 
            return false;
        }
        /// <summary>
        /// A space in the list of spaces has room ('spaceLemgth') for a ship of 'Length' size 
        /// horizontal or vertical (!horizontal)
        /// 
        /// Plaats het schip random op de battlefield
        /// 
        /// </summary>
        /// <param name="spaces"></param>
        /// <param name="ship"></param>
        /// <returns></returns>
        bool PlaceBattleShip(List<Space> spaces, BattleShip ship)
        {
            Random random = new();
            int startPosition = 0, randomSpace = 0;
            if (spaces.Count == 0) return false;

            randomSpace = spaces.Count > 0 ? random.Next(spaces.Count) : 0;
            startPosition = random.Next(spaces[randomSpace].spaceLength);
            Console.ResetColor();

            for (int i = 0; i < ship.Length; i++)
            {
                if (spaces[randomSpace].horizontal)
                {
                    cells[spaces[randomSpace].x + startPosition + i, spaces[randomSpace].y] = GamePiece.Ship;
                    ship.Locations.Add((new Location() { x = spaces[randomSpace].x + startPosition + i, y = spaces[randomSpace].y }));
                }
                else
                {
                    cells[spaces[randomSpace].x, spaces[randomSpace].y + startPosition + i] = GamePiece.Ship;
                    ship.Locations.Add(new Location() { x = spaces[randomSpace].x, y = spaces[randomSpace].y + startPosition + i });
                }
            }
            return true;
        }
        /// <summary>
        /// Just show on the console app the contens of the cells on the Grid
        /// </summary>
        public void ShowCells()
        {
            char cellType;
            for (int i = 0; i < gridSize.x; i++)
            {
                for (int j = 0; j < gridSize.y; j++)
                {
                    cellType = (cells[i, j] == GamePiece.Water) ? ShipPart.SW : ShipPart.SM;
                    Console.Write($"{cellType}");
                }
                Console.WriteLine("/n");
            }
        }
        /// <summary>
        /// FindPlaces is the new yet to program method to replace FindX and FindY
        /// return true if there is at least one space to place a ship
        /// </summary>
        /// <param name="Spaces"></param>
        /// <param name="Ship"></param>
        bool FindPlaces(List<Space> Spaces, BattleShip Ship)
        {
            return true;
        }
        /// <summary>
        /// Search for space in the 
        /// </summary>
        /// <param name="Spaces"></param>
        /// <param name="Ship"></param>
        void FindXSpace(List<Space> Spaces, BattleShip Ship)
        {
            int y, s = 0;
            // -------------------- xxxxxxx ---------------------------
            for (int i = 0; i < gridSize.x; i++) //Loop alle x posities bijlangs
            {
                y = 0;
                s = 0; //start potetial space for ship in y richting
                while (y < gridSize.y - Ship.Length) //niet verder dan er ruimte is voor ship
                {
                    if ((cells[i, y++] != GamePiece.Water) | (y == gridSize.y - Ship.Length))
                    {
                        //Console.Write($"Geen Water of eol: {cells[]},");
                        if (y + Ship.Length <= gridSize.y) // is er ruimte
                            Spaces.Add(new Space() { x = i, y = s, spaceLength = y - s, horizontal = false });
                        s = ++y;//skip 'non water'
                    }
                }
            }
        }
        void FindYSpace(List<Space> Spaces, BattleShip Ship)
        {
            int x, s = 0;
            // -------------------- YYYYYYY ---------------------------
            for (int i = 0; i < gridSize.y; i++) //Loop alle y posities bijlangs
            {
                x = 0;
                s = 0; //start potetial space for ship
                while (x < gridSize.x - Ship.Length) //niet verder dan er ruimte is voor ship
                {
                    if ((cells[x++, i] != GamePiece.Water) | (x == gridSize.x - Ship.Length))
                    {
                        //Console.Write($"Geen Water of eol: {cells[]},");
                        if (x + Ship.Length <= gridSize.x) // is er ruimte
                            Spaces.Add(new Space() { x = s, y = i, spaceLength = x - s, horizontal = true });
                        s = ++x;//skip 'non water'
                    }
                }
            }
        }
    }
}
