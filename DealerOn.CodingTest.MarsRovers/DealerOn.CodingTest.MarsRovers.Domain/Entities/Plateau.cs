using System;
using System.Collections.Generic;

namespace DealerOn.CodingTest.MarsRovers.Domain
{
    public class Plateau
    {
        public Plateau(int limitX, int limitY)
        {
            if (limitX < 0 || limitY < 0 || limitX + limitY == 0)
                throw new Exception("Invalid boundaries for plateau.");

            this.LimitX = limitX;
            this.LimitY = limitY;

            this.Rovers = new List<Rover>();
        }

        public int LimitX { get; set; }

        public int LimitY { get; set; }

        public List<Rover> Rovers { get; set; }

        public void ValidatePosition(int x, int y)
        {
            if (x < 0 || y < 0 || x > LimitX || y > LimitY)
                throw new Exception("Position is out of the boundaries of the plateau.");

            foreach (var rover in Rovers)
            {
                if(rover.GetCurrentPosition() == (x, y))
                {
                    throw new Exception("Position is already occupied.");
                }
            }
        }
    }
}
