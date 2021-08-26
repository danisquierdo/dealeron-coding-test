using System;
namespace DealerOn.CodingTest.MarsRovers.Domain
{
    public static class RoverFactory
    {
        public static Rover CreateRover(string line, Plateau plateau)
        {
            var coordinates = line.Split(' ');

            var x = Convert.ToInt32(coordinates[0]);
            var y = Convert.ToInt32(coordinates[1]);
            var direction = coordinates[2][0];

            return new Rover(x, y, GetDirectionFromLetter(direction), plateau);
        }

        private static Direction GetDirectionFromLetter(char letter)
        {
            switch (letter)
            {
                case 'N':
                    return Direction.North;
                case 'E':
                    return Direction.East;
                case 'S':
                    return Direction.South;
                case 'W':
                    return Direction.West;
                default:
                    throw new Exception("Invalid direction received.");
            }
        }
    }
}
