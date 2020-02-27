using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marsRoverProject
{
    public enum Rotation
    {
        N = 1,
        E = 2,
        S = 3,
        W = 4
    }

    public interface IRover
    {
        IPlateau RoverPlateau { get; set; }
        IPosition RoverPosition { get; set; }
        Rotation RoverRotation { get; set; }
        void ProcessCommands(string commands);
        string ToString();
    }

    public class Rover : IRover
    {
        public IPlateau RoverPlateau { get; set; }
        public IPosition RoverPosition { get; set; }
        public Rotation RoverRotation { get; set; }

        public Rover(IPlateau roverPlateau, IPosition roverPosition, Rotation roverRotation)
        {
            RoverPlateau = roverPlateau;
            RoverPosition = roverPosition;
            RoverRotation = roverRotation;
        }

        public void ProcessCommands(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        private void TurnLeft()
        {
            RoverRotation = (RoverRotation - 1) < Rotation.N ? Rotation.W : RoverRotation - 1;
        }

        private void TurnRight()
        {
            RoverRotation = (RoverRotation + 1) > Rotation.W ? Rotation.N : RoverRotation + 1;
        }

        private void Move()
        {
            if (RoverRotation == Rotation.N)
            {
                RoverPosition.YCoordinate++;
                if (!isValidNewPosition()){
                    RoverPosition.YCoordinate--;
                }
            }
            else if (RoverRotation == Rotation.E && isValidNewPosition())
            {
                RoverPosition.XCoordinate++;
                if (!isValidNewPosition())
                {
                    RoverPosition.XCoordinate--;
                }
            }
            else if (RoverRotation == Rotation.S && isValidNewPosition())
            {
               RoverPosition.YCoordinate--;
                if (!isValidNewPosition())
                {
                    RoverPosition.YCoordinate++;
                }
            }
            else if (RoverRotation == Rotation.W && isValidNewPosition())
            {
               RoverPosition.XCoordinate--;
                if (!isValidNewPosition())
                {
                    RoverPosition.XCoordinate++;
                }
            }
        }

        private bool isValidNewPosition()
        {
            var isValidX = RoverPosition.XCoordinate >= 0 && RoverPosition.XCoordinate <= RoverPlateau.PlateauPosition.XCoordinate;
            var isValidY = RoverPosition.YCoordinate >= 0 && RoverPosition.YCoordinate <= RoverPlateau.PlateauPosition.YCoordinate;
            return isValidX && isValidY;
        }

        public string WriteRoverPositon()
        {
            return string.Format("{0} {1} {2}", RoverPosition.XCoordinate, RoverPosition.YCoordinate, RoverRotation);
        }
    }
}
