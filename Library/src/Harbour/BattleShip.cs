using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.src.Harbour
{/// <summary>
 /// BattleShip holds info about the ship
 /// </summary>
    public class BattleShip
    {
        int length = 0;
        string name = "Boem"; //what's in a name
        List<Location> locations;
        public string Name { get => name; }
        public int Length { get => length; }

        //Oplossen met iterator
        public List<Location> Locations
        {
            get => locations;
            //set => location = value; 
        }
        /// <summary>
        /// Initialize 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length"></param>
        public BattleShip(string name, int length)
        {
            this.name = name;
            this.length = length;
            locations = new List<Location>(); // List of locations when placed on the grid. 
                                              // make list of possible places (hor and ver) based on length of the ship
                                              // and change the Gridcell according to GamePiece.Ship
        }
    }
}
