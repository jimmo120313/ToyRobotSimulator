using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;


namespace EngineLibrary
{
    public class Command
    {
        public int TopX { get; set; }
        public int TopY { get; set; }
        public TableTop TableTop { get; set; }

        public Command(TableTop tTop)
        {
            TableTop = tTop;
        }

        /// <summary>
        /// Check Command is valid for given robot
        /// </summary>
        /// <param name="command"></param>
        /// <param name="initiated"></param>
        /// <returns></returns>
        public bool IsValidCommand(string command, bool initiated)
        {
            Regex rgx = initiated
                ? new Regex(
                    @"^(PLACE [0-9]+,[0-9]+$)|^(PLACE [0-9]+,[0-9]+,(NORTH$|SOUTH$|EAST$|WEST$))|^LEFT$|^RIGHT$|^MOVE$|^REPORT$")
                : new Regex(@"^(PLACE [0-9]+,[0-9]+,(NORTH$|SOUTH$|EAST$|WEST$))");


            return rgx.IsMatch(command);
        }

        private ValidCommand ClassifyCommand(string command)
        {
            if (command.StartsWith("PLACE"))
            {
                return ValidCommand.Place;
            }
            else if (command == "LEFT")
            {
                return ValidCommand.Left;
            }
            else if (command == "RIGHT")
            {
                return ValidCommand.Right;
            }
            else if (command == "MOVE")
            {
                return ValidCommand.Move;
            }
            else
            {
                return ValidCommand.Report;
            }
        }

        public Robot ExecuteCommand(string command, Robot cRobot)
        {
            var type = ClassifyCommand(command);
            var newRobot = new Robot();
            switch (type)
            {
                case ValidCommand.Place:
                    var detail = command.Substring(6).Split(',');
                    var position = new Position(Convert.ToInt32(detail[0]), Convert.ToInt32(detail[1]));
                    var newDirection = detail.Length == 3
                        ? (Direction) Enum.Parse(typeof(Direction), detail[2])
                        : cRobot.Direction;
                    if (TableTop.IsInBoundary(position))
                    {
                        newRobot = new Robot
                        {
                            Direction = newDirection,
                            IsOnTable = true,
                            Position = position
                        };
                    }
                    else
                    {
                        newRobot = cRobot;
                    }

                    break;
                case ValidCommand.Right:
                    cRobot.UpdatedDirection(command);
                    newRobot = cRobot;
                    break;

                case ValidCommand.Left:
                    cRobot.UpdatedDirection(command);
                    newRobot = cRobot;
                    break;
                case ValidCommand.Move:
                    var newPosition = cRobot.NextPosition();
                    if (TableTop.IsInBoundary(newPosition))
                    {
                        cRobot.Position = newPosition;
                    }

                    newRobot = cRobot;

                    break;
                case ValidCommand.Report:
                    Console.WriteLine($"{cRobot.Position.X},{cRobot.Position.Y},{cRobot.Direction}");
                    newRobot = cRobot;
                    break;
            }

            return newRobot;
        }
    }

    enum ValidCommand
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }
}