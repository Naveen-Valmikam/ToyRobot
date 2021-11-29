using System;
namespace ToyRobotSimulator.Core
{
    // Validates the user input commands
    public class UserCommandParser :IUserCommandParser
    {
        // Validate and parse 
        public UserCommand ParseInputCommand(string[] input)
        {

            if (!Enum.TryParse(input[0], true, out UserInputCommands userCommand))
                throw new ArgumentException("Input command is not recognized. Please pass a valid command from PLACE x,y,direction;MOVE;LEFT;RIGHT;REPORT");

            return new UserCommand {  CommandType = userCommand};
        }

        public PlaceUserCommand ParsePlaceCommand(string[] userInputCommand,bool isRobotOnTable, Direction currentDirection)
        {
            // Check place user command is passed along with position and/or direction
            if (userInputCommand.Length != 2)
                throw new ArgumentException("Invalid place command. Place command should be of the format: PLACE X,Y,Direction");

            // Checks that two/three command parameters are provided for the PLACE command.   
            var inputParams = userInputCommand[1].Split(',');

            // Place command should have direction passed if toy robot is not already on the table
            if (inputParams.Length != 3 && !isRobotOnTable)
                throw new ArgumentException("Invalid place command");

            // Checks the direction which the toy is going to be facing.
            
            Direction direction = currentDirection;

            if (!isRobotOnTable && !Enum.TryParse(inputParams[^1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(inputParams[0]);
            var y = Convert.ToInt32(inputParams[1]);            

            return new PlaceUserCommand(new Position(x,y), direction);
        }
    }
     
    public class PlaceUserCommand : UserCommand
    {
        public PlaceUserCommand(Position position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public Position Position { get; set; }
        public Direction Direction { get; set; }
    }
}
