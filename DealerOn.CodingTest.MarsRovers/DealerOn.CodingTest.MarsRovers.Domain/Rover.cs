using System;
namespace DealerOn.CodingTest.MarsRovers.Logic
{
    public class Rover
    {
        public Rover(int x, int y, Direction direction, Plateau plateau)
        {
            if (x < 0 || y < 0)
                throw new Exception("Invalid rover coordinates");

            plateau.ValidatePosition(x, y);

            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.Plateau = plateau;
        }

        public Plateau Plateau;

        private Direction Direction { get; set; }

        private int X { get; set; }

        private int Y { get; set; }

        public void SendInstructions(string instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;
                    default:
                        throw new Exception("Invalid instruction received.");
                }
            }
        }

        public void TurnLeft()
        {
            if (this.Direction == Direction.North)
                this.Direction = Direction.West;
            else
                this.Direction -= 1;
        }

        public void TurnRight()
        {
            if (this.Direction == Direction.West)
                this.Direction = Direction.North;
            else
                this.Direction += 1;
        }

        public void MoveForward()
        {
            var x = this.X;
            var y = this.Y;

            switch(Direction)
            {
                case Direction.North:
                    y += 1;
                    break;
                case Direction.South:
                    y -= 1;
                    break;
                case Direction.East:
                    x += 1;
                    break;
                case Direction.West:
                    x -= 1;
                    break;

            }

            ApplyPosition(x, y);
        }

        public string PrintCurrentPosition()
        {
            return X.ToString() + " " + Y.ToString() + " " + Direction.ToString()[0];
        }

        private void ApplyPosition(int x, int y)
        {
            if (this.Plateau == null)
                throw new Exception("Rover is missing plateau information.");

            this.Plateau.ValidatePosition(x, y);

            this.X = x;
            this.Y = y;
        }
    }
}
