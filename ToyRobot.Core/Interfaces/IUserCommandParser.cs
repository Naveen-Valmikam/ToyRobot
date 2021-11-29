namespace ToyRobotSimulator.Core
{
    public interface IUserCommandParser
    {
        UserCommand ParseInputCommand(string[] inputCommand);
        PlaceUserCommand ParsePlaceCommand(string[] inputCommand, bool isRobotOnTable, Direction currentDirection);

    }
}
