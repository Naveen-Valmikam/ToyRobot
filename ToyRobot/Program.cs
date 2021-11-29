using System;
using ToyRobotSimulator.Core;

namespace ToyRobot.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var canceled = false;
            const string welcomeText = @"Welcome to toy robot simulator.
        1. Place the toy robot on a 6X6 table using following command:
           PLACE X,Y,Direction - where X and Y are integers and Direction is the direction the toy robot should be facing - EAST, WEST, NORTH or SOUTH.
        2. After the place command, following commands are allowed:
            REPORT - Outputs the current position of the robot
            MOVE - Moves the robot by one unit
            LEFT - Turns the robot to left by 90 degress
            RIGHT - Turns the robot to right by 90 degress
            STOP - Quits the simulator
            ";

            Console.WriteLine(welcomeText);

            IRobot toyRobot = new ToyRobotSimulator.Core.ToyRobot();

            Table table = new Table(6, 6);

            IUserCommandParser inputCommandParser   = new UserCommandParser();

            var simulator = new Simulator(toyRobot, table, inputCommandParser);

            do
            {
                var inputCommand = Console.ReadLine();

                if (inputCommand == null) continue;

                if (inputCommand.Equals("STOP"))
                    canceled = true;
                else
                {
                    try
                    {
                        var output = simulator.Process(inputCommand);

                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!canceled);
             
        }
    }
}
