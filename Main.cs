using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marsRoverProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create Plateau Area
            Plateau plateau = new Plateau(new Position(5, 5));

            //First rover
            Rover firstRover = new Rover(plateau, new Position(1, 2), Rotation.N);
            firstRover.ProcessCommands("LMLMLMLMM");

            //Second rover
            Rover secondRover = new Rover(plateau, new Position(3, 3), Rotation.E);
            secondRover.ProcessCommands("MMRMMRMRRM");

            //Third rover
            Rover thirdRover = new Rover(plateau, new Position(0, 0), Rotation.N);
            thirdRover.ProcessCommands("LMMM");

            //Fourth rover
            Rover fourthRover = new Rover(plateau, new Position(5, 5), Rotation.N);
            fourthRover.ProcessCommands("MMM");


            Console.WriteLine("===Expected Output===");
            Console.WriteLine();
            Console.WriteLine(firstRover.WriteRoverPositon());
            Console.WriteLine(secondRover.WriteRoverPositon());
            Console.WriteLine(thirdRover.WriteRoverPositon());
            Console.WriteLine(fourthRover.WriteRoverPositon());
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    
}
