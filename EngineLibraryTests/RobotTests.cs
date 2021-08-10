using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary.Tests
{
    [TestClass()]
    public class RobotTests
    {
        [TestMethod]
        public void RobotTurnLeftTestEast()
        {
            var robot = new Robot {Direction = Direction.EAST, Position = new Position(0, 0)};

            robot.UpdatedDirection("LEFT");

            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnLeftTestSouth()
        {
            var robot = new Robot {Direction = Direction.SOUTH, Position = new Position(0, 0)};

            robot.UpdatedDirection("LEFT");

            Assert.AreEqual(Direction.EAST, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnLeftTestWest()
        {
            var robot = new Robot {Direction = Direction.WEST, Position = new Position(0, 0)};

            robot.UpdatedDirection("LEFT");

            Assert.AreEqual(Direction.SOUTH, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnLeftTestNorth()
        {
            var robot = new Robot {Direction = Direction.NORTH, Position = new Position(0, 0)};

            robot.UpdatedDirection("LEFT");

            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnRightTestEast()
        {
            var robot = new Robot {Direction = Direction.EAST, Position = new Position(0, 0)};

            robot.UpdatedDirection("RIGHT");

            Assert.AreEqual(Direction.SOUTH, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnRightTestSouth()
        {
            var robot = new Robot {Direction = Direction.SOUTH, Position = new Position(0, 0)};

            robot.UpdatedDirection("RIGHT");

            Assert.AreEqual(Direction.WEST, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnRightTestWest()
        {
            var robot = new Robot {Direction = Direction.WEST, Position = new Position(0, 0)};

            robot.UpdatedDirection("RIGHT");

            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [TestMethod]
        public void RobotTurnRightTestNorth()
        {
            var robot = new Robot {Direction = Direction.NORTH, Position = new Position(0, 0)};

            robot.UpdatedDirection("RIGHT");

            Assert.AreEqual(Direction.EAST, robot.Direction);
        }

        [TestMethod]
        public void UpdatedPositionTest()
        {
            var robot = new Robot {Direction = Direction.NORTH, Position = new Position(1, 2)};

            var updatedRobot = robot.NextPosition();

            Assert.AreEqual(1, updatedRobot.X);
            Assert.AreEqual(3, updatedRobot.Y);
        }
    }
}