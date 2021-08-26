using System;
namespace DealerOn.CodingTest.MarsRovers.Domain
{
    public static class PlateauFactory
    {
        public static Plateau CreatePlateau(string line)
        {
            var coordinates = line.Split(' ');

            var x = Convert.ToInt32(coordinates[0]);
            var y = Convert.ToInt32(coordinates[1]);

            return new Plateau(x, y);
        }
    }
}
