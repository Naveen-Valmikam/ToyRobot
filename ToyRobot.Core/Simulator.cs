namespace ToyRobotSimulator.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Simulator
    {
        readonly IRobot robot;
        readonly IUserCommandParser userCommandParser;
        readonly Table table;

        public Simulator(IRobot robot, Table table,IUserCommandParser userCommandParser )
        {
            this.robot = robot;
            this.table = table;
            this.userCommandParser = userCommandParser;
        }

        public string Process(string userCommand)
        {

            var command = userCommandParser.ParseInputCommand(userCommand.Split(" "));

            if (command.CommandType != UserInputCommands.PLACE && robot.Position == null) return string.Empty;

            switch (command.CommandType)
            {
                case UserInputCommands.PLACE:

                    var isRobotOnTable = !(robot.Position.X == -1 && robot.Position.Y == -1);

                    var placeCommand = userCommandParser.ParsePlaceCommand(userCommand.Split(" "), isRobotOnTable, robot.Direction);

                    if (table.IsValidPosition(placeCommand.Position))
                        robot.Place(placeCommand.Position, placeCommand.Direction);
                    break;

                case UserInputCommands.MOVE:
                    var newPosition = robot.Move();

                    if (table.IsValidPosition(newPosition))
                        robot.Position = newPosition;
                    break;
                case UserInputCommands.LEFT:
                    robot.TurnLeft();
                    break;
                case UserInputCommands.RIGHT:
                    robot.TurnRight();
                    break;
                case UserInputCommands.REPORT:
                    return $"Output: {robot.Position.X},{robot.Position.Y},{robot.Direction}";
            }

            return string.Empty;
        }        
    }
}
