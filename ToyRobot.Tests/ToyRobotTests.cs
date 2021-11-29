using ToyRobotSimulator.Core;
using Xunit;

namespace ToyRobot.Tests
{
    /// <summary>
    /// Tests for toy robot actions
    /// </summary>
    public class RobotTests
    {
        readonly ToyRobotSimulator.Core.ToyRobot toyRobot;

        // arrange - set the toy robot on the table 
        public RobotTests()
        {
            toyRobot = new ToyRobotSimulator.Core.ToyRobot { Direction = Direction.NORTH, Position = new Position(1, 1) };
        }

        // Test move command
        [Fact]
        public void ToyRobot_At_1_1_North_Move_LandsAt_1_2_North()
        {
             
            // act
            var newPosition = toyRobot.Move();

            //assert
            Assert.True(newPosition.X == 1 && newPosition.Y == 2 && toyRobot.Direction == Direction.NORTH);
        }

        // Test turn left command
        [Fact]
        public void ToyRobot_At_1_1_North_TurnLeft_LandsAt_1_1_West()
        {
             
            // act
            toyRobot.TurnLeft();

            //assert
            Assert.True(toyRobot.Position.X == 1 && toyRobot.Position.Y == 1 && toyRobot.Direction == Direction.WEST);
        }

        // Test turn right action
        [Fact]
        public void ToyRobot_At_1_1_North_TurnRight_LandsAt_1_1_East()
        {
            // act
            toyRobot.TurnRight();

            //assert
            Assert.True(toyRobot.Position.X == 1 && toyRobot.Position.Y == 1 && toyRobot.Direction == Direction.EAST);
        }

        // Test place command for the toy robot
        [Fact]
        public void ToyRobot_Place_2_3_South_IsValid()
        {
            //act
            toyRobot.Place(new Position(2, 3), Direction.SOUTH);
            //assert
            Assert.True(toyRobot.Direction == Direction.SOUTH && toyRobot.Position.X == 2 && toyRobot.Position.Y == 3);

        }
    }
}
