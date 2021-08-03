using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary.Tests
{
    [TestClass()]
    public class TableTopTests
    {
        /// <summary>
        /// Test position outside boundary
        /// </summary>
        [TestMethod()]
        public void IsInBoundaryTest_OutsideBoundary()
        {
            var tTable = new TableTop {TableLength = 5, TableWidth = 5};
            var position = new Position(5, 6);
            var result = tTable.IsInBoundary(position);

            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test position inside boundary
        /// </summary>
        [TestMethod()]
        public void IsInBoundaryTest_InsideBoundary()
        {
            var tTable = new TableTop {TableLength = 5, TableWidth = 5};
            var position = new Position(3, 2);
            var result = tTable.IsInBoundary(position);

            Assert.AreEqual(true, result);
        }
    }
}