using System;
namespace DealerOn.CodingTest.MarsRovers.Logic
{
    public class Plateau
    {
        public Plateau(int limitX, int limitY)
        {
            if (limitX < 0 || limitY < 0 || limitX + limitY == 0)
                throw new Exception("Invalid boundaries for plateau.");

            this.LimitX = limitX;
            this.LimitY = limitY;
        }

        public int LimitX { get; set; }

        public int LimitY { get; set; }

        public void ValidatePosition(int x, int y)
        {
            if (x < 0 || y < 0 || x > LimitX || y > LimitY)
                throw new Exception("Position is out of the boundaries of the plateau.");
        }
    }
}
