using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EngineLibrary
{
    public class Robot
    {
        public Position Position { get; set; }

        public Direction Direction { get; set; }

        public bool IsOnTable { get; set; } = false;

        /// <summary>
        /// Update robot position for MOVE Command
        /// </summary>
        public Position NextPosition()
        {
            var updatedPosition = new Position(Position.X, Position.Y);

            switch (Direction)
            {
                case Direction.EAST:

                    updatedPosition.X = updatedPosition.X + 1;
                    break;
                case Direction.WEST:
                    updatedPosition.X = updatedPosition.X - 1;
                    break;
                case Direction.SOUTH:
                    updatedPosition.Y = updatedPosition.Y - 1;
                    break;
                case Direction.NORTH:
                    updatedPosition.Y = updatedPosition.Y + 1;
                    break;
            }

            return updatedPosition;
        }

        /// <summary>
        /// Update robot facing for LEFT and RIGHT Command
        /// </summary>
        /// <param name="lr"></param>
        public void UpdatedDirection(string lr)
        {
            switch (lr)
            {
                case "LEFT":
                    if ((int) this.Direction - 1 < 0)
                    {
                        this.Direction = Direction.WEST;
                    }
                    else
                    {
                        this.Direction = this.Direction - 1;
                    }

                    break;
                case "RIGHT":
                    if ((int) this.Direction + 1 > 3)
                    {
                        this.Direction = Direction.NORTH;
                    }
                    else
                    {
                        this.Direction = this.Direction + 1;
                    }

                    break;
            }
        }
    }
}