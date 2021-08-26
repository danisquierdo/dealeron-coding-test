using DealerOn.CodingTest.MarsRovers.Domain;
using NUnit.Framework;
using System;
namespace DealerOn.CodingTest.MarsRovers.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void ExampleTestCases_ReturnsExpectedAnswers()
        {
            var plateau1 = new Plateau(5, 5);

            var rover1 = new Rover(1, 2, Direction.North, plateau1);

            rover1.SendInstructions("LMLMLMLMM");

            var answer1 = rover1.PrintCurrentPosition();

            Assert.AreEqual("1 3 N", answer1);

            var rover2 = new Rover(3, 3, Direction.East, plateau1);

            rover2.SendInstructions("MMRMMRMRRM");

            var answer2 = rover2.PrintCurrentPosition();

            Assert.AreEqual("5 1 E", answer2);

        }

        [Test()]
        public void SendRoverOutOfBoundary_Fails()
        {
            var plateau1 = new Plateau(1, 1);

            var rover1 = new Rover(0, 0, Direction.North, plateau1);

            Assert.Throws<Exception>(() => rover1.SendInstructions("MMMMMMMM"));
            Assert.Throws<Exception>(() => rover1.SendInstructions("LMMMMMMM"));
            Assert.Throws<Exception>(() => rover1.SendInstructions("RMMMMMMM"));
            Assert.Throws<Exception>(() => rover1.SendInstructions("LLMMMMMMM"));
            Assert.Throws<Exception>(() => rover1.SendInstructions("RRsMMMMMMM"));

        }

        [Test()]
        public void CreateInvalidPlateau_Fails()
        {
            Assert.Throws<Exception>(() => new Plateau(0, 0));
            Assert.Throws<Exception>(() => new Plateau(-1, 0));
            Assert.Throws<Exception>(() => new Plateau(-1, -1));
        }

        [Test()]
        public void CreateInvalidRover_Fails()
        {
            var plateau1 = new Plateau(1, 1);
            Assert.Throws<Exception>(() => new Rover(-1, 0, Direction.North, plateau1));
            Assert.Throws<Exception>(() => new Rover(0, -2, Direction.North, plateau1));
            Assert.Throws<Exception>(() => new Rover(-1, -2, Direction.North, plateau1));
        }

        [Test()]
        public void CreateRoverOutOfPlateau_Fails()
        {
            var plateau1 = new Plateau(1, 1);
            Assert.Throws<Exception>(() => new Rover(2,2, Direction.North, plateau1));
        }

        [Test()]
        public void CreateRoverWithoutPlateau_Fails()
        {
            Assert.Throws<ArgumentNullException>(() => new Rover(2, 2, Direction.North, null));
        }

        [Test()]
        public void CreateRoverInOccupiedSpace_Fails()
        {
            var plateau1 = new Plateau(3, 3);
            var rover1 = new Rover(1, 2, Direction.North, plateau1);
            Assert.Throws<Exception>(() => new Rover(1, 2, Direction.North, plateau1));
        }

        [Test()]
        public void SendRoverToOccupiedSpace_Fails()
        {
            var plateau1 = new Plateau(3, 3);
            var rover1 = new Rover(1, 2, Direction.North, plateau1);
            var rover2 = new Rover(1, 1, Direction.West, plateau1);
            rover2.TurnRight();
            Assert.Throws<Exception>(() => rover2.MoveForward());
        }

    }
}