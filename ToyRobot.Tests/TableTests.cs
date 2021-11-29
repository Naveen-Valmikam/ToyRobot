using System;
using ToyRobotSimulator.Core;
using Xunit;

namespace ToyRobot.Tests
{
    public class TableTests
    {
        readonly Table table;

        public TableTests()
        {
            table = new Table(6, 6);
        }

        // Test valid position on the table
        [Fact]
        public void Table_Position_3_4_ShouldBe_Valid_Position()
        {
            // arrange
            var position = new Position(3, 4);

            //act
            var result = table.IsValidPosition(position);

            // assert
            Assert.True(result);
        }

        // Test invalid position on the table
        [Fact]
        public void Table_Position_7_6_ShouldBe_Invalid_Position()
        {
            // arrange
            var position = new Position(7, 6);

            //act
            var result = table.IsValidPosition(position);

            // assert
            Assert.False(result);
        }



    }
}
