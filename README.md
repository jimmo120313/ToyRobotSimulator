# ToyRobotSimulator

--------------------
This repo contain a Engine library that can read in commands of the following form:<br />
PLACE X,Y,DIRECTION <br />
MOVE <br />
LEFT <br />
RIGHT <br />
REPORT <br />

<b>A Console application(on .NET Core 3.1) has been created as the user interface to access the library.<br/>
You can run the solution by:<br/> </b>
1. Open the solution in Visual studio
2. Set ToyRobotSimulator as the startup project and press F5

## Description
- The library allows for a simulation of a toy robot moving on a 6 x 6 square tabletop.
- There are no obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.
-  PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
- (0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.
- The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed.
- The PLACE command should be discarded if it places the robot outside of the table surface.
- Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and orientation of the       .
- A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.
- The library should discard all invalid commands and parameters.









