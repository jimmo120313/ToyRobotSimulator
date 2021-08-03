using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary.Tests
{
    [TestClass]
    public class CommandTests
    {
        #region IsValidCommandTest

        /// <summary>
        /// Test for Initiated bot
        /// </summary>
        [TestMethod]
        public void IsValidCommandTest_PLACEInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("PLACE 1,2,NORTH", true);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsValidCommandTest_LEFTInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("LEFT", true);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsValidCommandTest_REPORTInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("REPORT", true);

            Assert.AreEqual(true, result);
        }


        /// <summary>
        /// Test for not initiated bot
        /// </summary>
        [TestMethod]
        public void IsValidCommandTest_WrongPLACENotInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("PLACE 1,2", false);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsValidCommandTest_RIGHTNotInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("RIGHT", false);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsValidCommandTest_PLACENotInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("PLACE 1,2,NORTH", false);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsValidCommandTest_REPORTNOTInitiated()
        {
            var command = new Command(new TableTop());

            var result = command.IsValidCommand("REPORT", false);

            Assert.AreEqual(false, result);
        }

        #endregion

        #region ExecuteCommandTest

        [TestMethod]
        public void ExecuteCommandTest_MixCommand()
        {
            var command = new Command(new TableTop {TableLength = 5, TableWidth = 5});
            var robot = new Robot {Position = new Position(2, 1), Direction = Direction.WEST, IsOnTable = true};
            robot = command.ExecuteCommand("PLACE 3,1,EAST", robot);
            robot = command.ExecuteCommand("PLACE 1,1,NORTH", robot);
            robot = command.ExecuteCommand("LEFT", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("RIGHT", robot);
            robot = command.ExecuteCommand("MOVE", robot);


            Assert.AreEqual(0, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, robot.Direction);
        }

        [TestMethod]
        public void ExecuteCommandTest_PLACE_YOutsideBoundary()
        {
            var command = new Command(new TableTop {TableLength = 5, TableWidth = 5});
            var robot = new Robot {Position = new Position(1, 1), Direction = Direction.NORTH, IsOnTable = true};
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);


            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(4, robot.Position.Y);
        }

        [TestMethod]
        public void ExecuteCommandTest_PLACE_XOutsideBoundary()
        {
            var command = new Command(new TableTop {TableLength = 5, TableWidth = 5});
            var robot = new Robot {Position = new Position(1, 1), Direction = Direction.EAST, IsOnTable = true};
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);
            robot = command.ExecuteCommand("MOVE", robot);

            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(4, robot.Position.X);
        }

        #endregion
    }
}