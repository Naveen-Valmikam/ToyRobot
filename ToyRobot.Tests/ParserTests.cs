using System;
using ToyRobotSimulator.Core;
using Xunit;

namespace ToyRobot.Tests
{
    public class ParserTests
    {
        // Test that command text passed is one of the allowed commands - PLACE, MOVE, LEFT, RIGHT, REPORT
        [Fact]
        public void UserCommandParser_MOVE_Is_ValidCommand()
        {
            var inputCommandParser = new UserCommandParser();
            var userCommand = "MOVE";

            var result = inputCommandParser.ParseInputCommand(userCommand.Split(" "));

            Assert.True(result.CommandType == UserInputCommands.MOVE);
        }

        // Test that JUMP is not a valid supported command
        [Fact]
        public void UserCommandParser_JUMP_Is_InValidCommand()
        {
            var inputCommandParser = new UserCommandParser();
            var userCommand = "JUMP";

            var result = Assert.Throws<ArgumentException>(()=>inputCommandParser.ParseInputCommand(userCommand.Split(" ")));
        }

        // Test Valid Place command
        [Fact]
        public void UserCommandParser_Place_1_1_North_Is_ValidCommand()
        {
            var inputCommandParser = new UserCommandParser();
            bool isRobotOnTable = false ;
            var userCommand = "PLACE 1,1,NORTH";

            var result = inputCommandParser.ParsePlaceCommand(userCommand.Split(" "),isRobotOnTable, Direction.EAST);

            Assert.True(result.CommandType == UserInputCommands.PLACE);
        }

        // Test once the robot is on the table  Place command can be executed without the direction
        [Fact]
        public void UserCommandParser_After_ToyRobotOnTable_PlaceWithoutDirection_Is_ValidCommand()
        {
            var inputCommandParser = new UserCommandParser();
            bool isRobotOnTable = true;
            var userCommand = "PLACE 2,3";
            
            var result = inputCommandParser.ParsePlaceCommand(userCommand.Split(" "), isRobotOnTable, Direction.EAST);



            Assert.True(result.CommandType == UserInputCommands.PLACE);
        }


    }
}
