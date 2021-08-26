using System;
using System.IO;
using DealerOn.CodingTest.MarsRovers.Domain;

namespace DealerOn.CodingTest.MarsRovers.ConsoleApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter path to input file.");

            var filePath = Console.ReadLine();

            StreamReader sr = new StreamReader(filePath);

            // assumption: only 2 rovers at a time for 1 plateau
            var plateau = PlateauFactory.CreatePlateau(sr.ReadLine());

            // first rover
            var rover1 = RoverFactory.CreateRover(sr.ReadLine(), plateau);
            rover1.SendInstructions(sr.ReadLine());
            Console.WriteLine(rover1.PrintCurrentPosition());

            // second rover
            var rover2 = RoverFactory.CreateRover(sr.ReadLine(), plateau);
            rover2.SendInstructions(sr.ReadLine());
            Console.WriteLine(rover2.PrintCurrentPosition());
        }
    }
}
