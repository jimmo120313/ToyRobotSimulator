using System;
using System.Data;
using System.Diagnostics;
using EngineLibrary;


namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Robot Simulator");
            Console.WriteLine("Type 'Leave' to Exit the console app");
            Console.WriteLine("Command you can use: \n PLACE X,Y,DIRECTION \n MOVE \n LEFT \n RIGHT \n REPORT");

            var cRobot = new Robot();

            var tableTop = new TableTop {TableLength = 6, TableWidth = 6};
            var simulator = new Command(tableTop);
            while (true)
            {
                var input = Console.ReadLine()?.Trim().ToUpper();

                if (String.IsNullOrWhiteSpace(input))
                {
                    continue;
                }
                else if (input == "LEAVE")
                {
                    break;
                }
                else
                {
                    if (simulator.IsValidCommand(input, cRobot.IsOnTable))
                    {
                        cRobot = simulator.ExecuteCommand(input, cRobot);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command");
                    }

                    continue;
                }
            }

            Console.WriteLine("Thanks for using Robot simulator");
        }
    }
}