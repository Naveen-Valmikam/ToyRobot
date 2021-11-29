namespace ToyRobotSimulator.Core
{
    public class ToyRobot: IRobot
    {
        // Initialize a toy robot with -1,-1 position to indicate that toy robot is not on the table yet
        public ToyRobot()
        {
            this.Position = new Position(-1, -1);
        }

        public Position Position { get; set; }

        public Direction Direction { get; set; }

        // Places the toy robot on the board at a given position and direction
        public void Place(Position position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        // Moves the robot by 1 unit to next position on the board
        public Position Move()
        {
            var newPosition = new Position(Position.X, Position.Y);

            switch (Direction)
            {
                case Direction.EAST:
                    newPosition.X++;
                    break;
                case Direction.WEST:
                    newPosition.X--;
                    break;
                case Direction.NORTH:
                    newPosition.Y++;
                    break;
                case Direction.SOUTH:
                    newPosition.Y--;
                    break;
                 
            }

            return newPosition;
        }

        // Turns the robot by 90 degrees to the left
        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.EAST:
                    Direction = Direction.NORTH;
                    break;
                case Direction.WEST:
                    Direction = Direction.SOUTH;
                    break;
                case Direction.NORTH:
                    Direction = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    Direction = Direction.EAST;
                    break;
            }
        }

        // Turns the robot by 90 degrees to the right
        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.EAST:
                    Direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    Direction = Direction.NORTH;
                    break;
                case Direction.NORTH:
                    Direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    Direction = Direction.WEST;
                    break;
            }
        }     
    }
}
