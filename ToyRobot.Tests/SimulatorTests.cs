using ToyRobotSimulator.Core;
using Xunit;


namespace ToyRobot.Tests
{
    public class SimulatorTests
    {
        readonly Table table;
        readonly UserCommandParser parser;
        readonly ToyRobotSimulator.Core.ToyRobot toyRobot;
        readonly Simulator simulator;

        // Initial Set up for the tests assuming the table is 6X6
        public SimulatorTests()
        {
            table = new Table(6, 6);
            parser = new UserCommandParser();
            toyRobot = new ToyRobotSimulator.Core.ToyRobot();
            simulator = new Simulator(toyRobot, table, parser);
        }

        // Test valid PLACE command
        [Fact]
       public void Simulator_Place_1_1_North_ShouldBe_Valid()
        {
            //arrange
            var userCommand = "PLACE 1,1,NORTH";

            //act
            simulator.Process(userCommand);

            //assert
            Assert.True(toyRobot.Position.X == 1 && toyRobot.Position.Y == 1 && toyRobot.Direction == Direction.NORTH);

        }

        // Test PLACE command should be discarded if it puts robot outside the table
        [Fact]
        public void Simulator_Place_6_6_North_ShouldBe_Invalid()
        {
            //arrange
            var userCommand = "PLACE 6,6,NORTH";

            //act
            simulator.Process(userCommand);

            //assert
            Assert.True(toyRobot.Position.X == -1 && toyRobot.Position.Y == -1);

        }

        // Test subsequent valid PLACE commands with different positions and different directions
        [Fact]
        public void Simulator_Place_2_0_North_After_Place_3_1_East_ShouldBe_Valid()
        {
            //arrange
         
            var userCommand = "PLACE 0,0,NORTH";

            //act
            simulator.Process(userCommand);
            userCommand = "PLACE 2,0,NORTH";
            simulator.Process(userCommand);

            //assert

            Assert.True(toyRobot.Position.X == 3 && toyRobot.Position.Y == 1 && toyRobot.Direction == Direction.EAST);

        }

        // Test PLACE and MOVE commmand
        [Fact]
        public void Simulator_Place_1_1_North_FollowedBy_Move_ShouldBeValid()
        {
            //arrange
           
            var userCommand = "PLACE 1,1,NORTH";

            //act
            simulator.Process(userCommand);
            userCommand = "MOVE";
            simulator.Process(userCommand);

            //assert

            Assert.True(toyRobot.Position.X == 1 && toyRobot.Position.Y == 2 && toyRobot.Direction == Direction.NORTH);

        }


        // Test MOVE command which will put the robot outside the table should be discarded and robot should remain at same position it was placed
        [Fact]
        public void Simulator_Place_5_5_North_ThenMove_ShouldBeInvalid_AndDiscarded()
        {
            //arrange

            var userCommand = "PLACE 5,5,NORTH";

            //act
            simulator.Process(userCommand);
            userCommand = "MOVE";
            simulator.Process(userCommand);
            
            //assert

            Assert.True(toyRobot.Position.X == 5 && toyRobot.Position.Y == 5 && toyRobot.Direction == Direction.NORTH);

        }

        // Test use case where robot is prevented from falling and subsequent left turn command is valid 
        [Fact]
        public void Simulator_Test_PreventRobotFalling_FollwedBy_LeftTurn_ShouldBeValid()
        {
            // Place toy robot at 5,5,NORTH
            var userCommand = "PLACE 5,5,NORTH";
            simulator.Process(userCommand);

            // MOVE out of table, this action should be discarded
            userCommand = "MOVE";
            simulator.Process(userCommand);

            // TURN LEFT
            userCommand = "LEFT";
            simulator.Process(userCommand);

            //assert
            // Check Left turn from North should change direction to West
            Assert.Equal( Direction.WEST,toyRobot.Direction);

        }

        // Test that once robot is on table, place command without direction is valid    
        [Fact]
        public void Simulator_Place_1_1_North_FollowedBy_Place_2_2_WithoutDirection_ShouldBe_Valid()
        {
            // First valid place command with direction
            var userCommand = "PLACE 2,5,EAST";
            simulator.Process(userCommand);

            // Another place command without direction, this should be accepted as a valid command
            userCommand = "PLACE 3,4";
            simulator.Process(userCommand);

            Assert.True(toyRobot.Position.X == 3 && toyRobot.Position.Y == 4 && toyRobot.Direction == Direction.EAST);
        }

        // Test that all commands before a a valid PLACE Command are discarded
        [Fact]
        public void Simulator_Discard_MoveCommand_Till_Valid_Place_Command()
        {
            //arrage
            var userCommand = "MOVE";
            simulator.Process(userCommand);

            //assert
            Assert.Equal( -1, toyRobot.Position.X);
        }


        // Test that all commands before a a valid PLACE Command are discarded
        [Fact]
        public void Simulator_Discard_ReportCommand_Till_Valid_Place_Command()
        {
            //arrage
            var userCommand = "REPORT";
            simulator.Process(userCommand);

            //assert
            Assert.Equal(-1, toyRobot.Position.X);
        }

        // Test that all commands before a a valid PLACE Command are discarded
        [Fact]
        public void Simulator_Discard_LeftCommand_Till_Valid_Place_Command()
        {
            //arrage
            var userCommand = "LEFT";
            simulator.Process(userCommand);

            //assert
            Assert.Equal(-1, toyRobot.Position.X);
        }

        // Test that all commands before a a valid PLACE Command are discarded
        [Fact]
        public void Simulator_Discard_RightCommand_Till_Valid_Place_Command()
        {
            //arrage
            var userCommand = "RIGHT";
            simulator.Process(userCommand);

            //assert
            Assert.Equal(-1, toyRobot.Position.X);
        }
    }
}
