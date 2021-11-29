namespace ToyRobotSimulator.Core
{
    public interface IRobot
    {
        Position Position { get; set; }
        Direction Direction { get; set; }
        void Place(Position position, Direction direction);
        Position Move();
        void TurnLeft();
        void TurnRight();
    }
}
