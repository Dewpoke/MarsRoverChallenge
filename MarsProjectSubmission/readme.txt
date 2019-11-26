Mars Rover Technical Challenge attempt by Alexi
Project source: https://code.google.com/archive/p/marsrovertechchallenge/

TO RUN:
Open the MarsProject folder and run MarsProject.exe

TO CHANGE THE INPUT:
Open input.txt (held in the same location as MarsProject.exe) in any text editor, and input values.
The first line consists of the x-length and y-length of the grid, and every pair of lines thereafter hold the starting positions and directions of rovers and their movement commands.
Blank and invalid lines will give errors.

The format for grid size is 'Xlength yLength'. Eg.
5 6
(This grid has a width of 5 and height of 6)

The format for rover positions/instructions is the first line holds the x-coordinate, y-coordinate, and cardinal direction. The second line holds a string of turn left(L), turn right(R), and move forward(M) commands. Eg.
2 1 N
RRMMLM
(This will spawn a rover at (2, 1) and has it facing north. The commands will turn the rover right twice, move it forward twice, then turn it left once, then move it forward once)

READING THE OUTPUT:
In the same folder as input.txt, output.txt exists. Run the program with the desired inputs and the corresponding output will be placed in output.txt. If the program encounters an error or problem it will be posted in output.txt.
The output gives the end position and direction of each rover. Each different line represents each rovers end position/direction. For two rovers the output might be:
5 1 E
2 3 S

ERRORS:
If the input does not follow the format given the output will give an error. Additional characters added to the grid input/rover position and direction input are ignored. Cardinal direction (ie. north, south) can be upper case or lower case.
The output will also give an error if one rover moves into the space of another rover or if a rover falls off the given grid.