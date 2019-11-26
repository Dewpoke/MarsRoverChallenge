using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MarsProject
{
    class RoverController
    {
        int[] mapSizeArr = new int[2];
        RoverObject[] roversArr;

        public RoverController(String[] lines) //The input text, broken up into lines. Correct input has the 0-index containing map data, then each pair of line thereafter containing rover position/direction and instructions
        {
            //Map initialisation with error checking
            string[] parsedLine = lines[0].Split(' ');//The line further broken up into individual elements
            
            if(parsedLine.Length < 2)//if the map coords have less than two elements
            {
                WriteErrorToTextFile("Too few Map Parameters. Parameters are of the format 'X Y'");
                Environment.Exit(0);
            }

            for (int i = 0; i < 2; i++)//Put the first two elements of line one into the array.
            {
                if (!Int32.TryParse(parsedLine[i], out mapSizeArr[i]))
                {
                    WriteErrorToTextFile("Invalid Map Parameters. Parameters must be numbers");
                    Environment.Exit(0);
                }
            }
            //Rover initialisation
            if (lines.Length % 2 == 0)
            {
                WriteErrorToTextFile("Invalid Rover Parameters. There should be one rover position input followed by one rover commands input, per rover");
                Environment.Exit(0);
            }

            roversArr = new RoverObject[(lines.Length - 1) / 2]; //If input is good, number of rovers equals 1/2 * (number of input lines minus 1)
            for (int i = 1; i < lines.Length; i = i + 2)//ignore map input line, work with the next two input lines, then the next two lines, then the next etc etc.
            {
                parsedLine = lines[i].Split(' ');//The position/direction line broken up into x, y, and dir elements.
                int[] parsedCoords = new int[2];
                if (!(Int32.TryParse(parsedLine[0], out parsedCoords[0]) && Int32.TryParse(parsedLine[1], out parsedCoords[1])))//put the coords in parsedCoords
                {
                    WriteErrorToTextFile("Invalid Rover Co-ordinates for Rover ID" + (i - 1) / 2);
                    Environment.Exit(0);
                }
                int givenDir = 0;
                switch (parsedLine[2])
                {
                    case "E":
                    case "e":
                        givenDir = 0;
                        break;

                    case "N":
                    case "n":
                        givenDir = 1;
                        break;

                    case "W":
                    case "w":
                        givenDir = 2;
                        break;

                    case "S":
                    case "s":
                        givenDir = 3;
                        break;

                    default:
                        WriteErrorToTextFile("Invalid Rover Direction for Rover ID" + (i - 1) / 2);
                        Environment.Exit(0);
                        break;
                }

                string givenCommands = lines[i + 1];

                roversArr[(i - 1) / 2] = new RoverObject(parsedCoords, givenDir, givenCommands);
            }
            
        }

        public void ExecuteCommands()
        {
            for (int i = 0; i < roversArr.Length; i++)//For each rover
            {
                String roverCommands = roversArr[i].GetRoverCommands();
                for (int j = 0; j < roverCommands.Length; j++)//loop through each instruction Letter
                {
                    if (roverCommands[j] == 'M')
                    {
                        roversArr[i].MoveForward();
                        if (DoRoversCollide(i))
                        {
                            WriteErrorToTextFile("Rover" + i + " has hit another rover");
                            Environment.Exit(0);
                        }
                        if (IsRoverOutOfBounds())
                        {
                            WriteErrorToTextFile("Rover" + i + " has fallen off the plateau!");
                            Environment.Exit(0);
                        }
                    }
                    else if (roverCommands[j] == 'L')
                    {
                        roversArr[i].TurnLeft();
                    }
                    else if (roverCommands[j] == 'R')
                    {
                        roversArr[i].TurnRight();
                    }
                    else
                    {
                        WriteErrorToTextFile("Invalid instruction for Rover " + i + ", at instruction position " + j + ", moving on to next");
                    }
                }
            }
        }

        bool DoRoversCollide(int currRover)
        {
            for (int i = 0; i < roversArr.Length; i++)
            {
                if (i != currRover)
                {
                    if (roversArr[currRover].GetCoords()[0] == roversArr[i].GetCoords()[0] && roversArr[currRover].GetCoords()[1] == roversArr[i].GetCoords()[1])//compare coordinates
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool IsRoverOutOfBounds()
        {
            for (int i = 0; i < roversArr.Length; i++)
            {
                if (roversArr[i].GetCoords()[0] < 0 || roversArr[i].GetCoords()[1] < 0)
                {
                    return true;
                }
                else if (roversArr[i].GetCoords()[0] > mapSizeArr[0] || roversArr[i].GetCoords()[1] > mapSizeArr[1])
                {
                    return true;
                }
            }
            return false;
        }

        public String PrintRoverPositionsAndDirections()
        {
            string printedString = "";
            for (int i = 0; i < roversArr.Length; i++)
            {
                printedString += "Rover" + i + ": " + roversArr[i].PrintRoverPositionAndDirection() + "\n\n";
            }
            return printedString;
        }

        public String PrintOutputBasic()
        {
            string printedString = "";
            for (int i = 0; i < roversArr.Length; i++)
            {
                printedString += roversArr[i].GetCoords()[0] + " " + roversArr[i].GetCoords()[1] + " " + roversArr[i].GetDirCardinal() + "\n";
            }
            //printedString += "\n";
            return printedString;
        }


        void WriteErrorToTextFile(string errorText)
        {
            File.WriteAllText(@"F:\VisualStudioRepos\MarsProject\MarsProject\output.txt", errorText);
            Environment.Exit(0);
        }
    }
}
