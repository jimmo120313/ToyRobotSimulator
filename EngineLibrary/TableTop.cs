using System;
using System.Collections.Generic;
using System.Text;

namespace EngineLibrary
{
    public class TableTop
    {
        public int TableLength { get; set; }

        public int TableWidth { get; set; }

        public bool IsInBoundary(Position position)
        {
            return TableLength > position.X && position.X >= 0 && TableWidth > position.Y && position.X >= 0;
        }
    }
}