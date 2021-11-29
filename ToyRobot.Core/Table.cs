namespace ToyRobotSimulator.Core
{
    public class Table
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Table(int x, int y)
        {
            Rows = x;
            Columns = y;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < Rows &&
                position.Y >= 0 && position.Y < Columns;
        }        
        
    }
}

