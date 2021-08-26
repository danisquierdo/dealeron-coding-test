using System;
namespace DealerOn.CodingTest.MarsRovers.Logic
{
    public static class EntityCreator
    {

        public static Plateau CreatePlateau(string line)
        {
            var coordinates = line.Split(' ');

            var x = Convert.ToInt32(coordinates[0]);
            var y = Convert.ToInt32(coordinates[1]);

            return new Plateau(x, y);
        }

        public static Rover CreateRover(string line, Plateau plateau)
        {
            var coordinates = line.Split(' ');

            var x = Convert.ToInt32(coordinates[0]);
            var y = Convert.ToInt32(coordinates[1]);
            var direction = coordinates[2];

            return new Rover(x, y, GetDirectionFromText(direction), plateau);
        }

        private static Direction GetDirectionFromText(string letter)
        {
            switch (letter)
            {
                case "N":
                    return Direction.North;
                case "E":
                    return Direction.East;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                default:
                    throw new Exception("Invalid direction received.");
            }
        }
    }
}
