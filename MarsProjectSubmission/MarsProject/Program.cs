using System;
using System.IO;
using System.Linq;

namespace MarsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"F:\VisualStudioRepos\MarsProject\MarsProject\input.txt");

            RoverController roverController = new RoverController(lines);

            roverController.ExecuteCommands();

            File.WriteAllText(@"F:\VisualStudioRepos\MarsProject\MarsProject\output.txt", roverController.PrintOutputBasic());
        }
    }
}



