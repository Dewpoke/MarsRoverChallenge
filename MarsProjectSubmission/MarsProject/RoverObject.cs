using System;
using System.Collections.Generic;
using System.Text;

namespace MarsProject
{
    class RoverObject
    {
        int[] coordsArr = new int[2]; //(x, y)
        int dir; //0 means east, 1 means north, 2 means west, and 3 means south
        String roverCommands;

        public RoverObject(int[] newCoords, int newDir, String newRoverCommands)
        {
            SetCoords(newCoords);
            SetDir(newDir);
            SetRoverCommands(newRoverCommands);
        }

        public void TurnRight()
        {
            dir--;
            if (dir < 0)
                dir += 4;
            dir = dir % 4; //Keeps direction between 0 and 3
        }

        public void TurnLeft()
        {
            dir++;
            dir = dir % 4;//Keeps direction between 0 and 3
        }

        public void MoveForward()
        {
            switch (dir)
            {
                case 0://east
                    coordsArr[0]++; 
                    break;

                case 1://north
                    coordsArr[1]++;
                    break;

                case 2://west
                    coordsArr[0]--;
                    break;

                case 3://south
                    coordsArr[1]--;
                    break;

                default:
                    Console.WriteLine("Invalid Direction");
                    Console.WriteLine(dir);
                    break;
            }
        }

        public void SetCoords (int [] newCoords)
        {
            coordsArr = newCoords;
        }

        public void SetDir (int newDir)
        {
            dir = newDir;
        }

        public void SetRoverCommands(String newRoverCommands)
        {
            roverCommands = newRoverCommands;
        }

        public int[] GetCoords()
        {
            return coordsArr;
        }

        public int GetDir()
        {
            return dir;
        }

        public string GetDirCardinal()
        {
            switch (dir)
            {
                case 0:
                    return  "E";
                    break;
                case 1:
                    return "N";
                    break;
                case 2:
                    return "W";
                    break;
                case 3:
                    return "S";
                    break;
                default:
                    Console.WriteLine("You shouldn't be able to get to this line but okay");
                    return "?";
                    break;
            }
        }

        public String GetRoverCommands()
        {
            return roverCommands;
        }

        public String PrintRoverPositionAndDirection()
        {
            char cardinalPoint = '?';
            switch (dir)
            {
                case 0:
                    cardinalPoint = 'E';
                    break;
                case 1:
                    cardinalPoint = 'N';
                    break;
                case 2:
                    cardinalPoint = 'W';
                    break;
                case 3:
                    cardinalPoint = 'S';
                    break;
                default:
                    Console.WriteLine("You shouldn't be able to get to this line but okay");
                    break;
            }

            return ("Rover Position is: (" + coordsArr[0] + ", " + coordsArr[1] + ").\n Rover Direction is " + cardinalPoint + ".");
        }
    }
}
