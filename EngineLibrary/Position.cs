using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    /// <summary>
    /// Represent position of Robot
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}