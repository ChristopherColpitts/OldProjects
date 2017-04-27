#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include "Maze.h"

Maze::Maze(const int* startPoint, const string& path) :rows(0), rowLength(0), startPoint(startPoint)
{
	ifstream inStream;
	char temp[1000];
	inStream.open(path);

	while (!inStream.eof())
	{
		inStream.getline(temp, 1000);
		rows++;//total rows in maze
	}
	
	rowLength = strlen(temp) + 1;//row length
	
	inStream.clear(); inStream.seekg(0, ios::beg);//beginning of file - clear

	maze = new char*[rows];//maze size
	solvedMaze = new char*[rows];
	for (int i = 0; i < rows; i++)
	{
		maze[i] = new char[rowLength];
		solvedMaze[i] = new char[rowLength];
	}

	// Write the file
	int x = 0;
	while (!inStream.eof())
	{
		inStream.getline(temp, 1024);
		strcpy(solvedMaze[x], temp);
		strcpy(maze[x], temp);
		x++;
	}
	// Close instream
	inStream.close();
}

void Maze::setAt(int x, int y)
{
	maze[x][y] = '"#"';
}

char Maze::getAt(int x, int y)
{
	return maze[x][y];
}


int Maze::getXLength()
{
	return rows;
}

int Maze::getYLength()
{
	return rowLength;
}

const int* Maze::getStartPoint()
{
	return startPoint;
}

char Maze::getSolvedMazeAt(int x, int y)
{
	return solvedMaze[x][y];
}

void Maze::SolvedMaze(Stack * stack)
{
	int coordinates = stack->GetSize();

	for (int i = 0; i < coordinates; i++)
	{
		solvedMaze[stack->GetTop().getX()][stack->GetTop().getY()] = '#';
		stack->Pop();
	}
}

void Maze::save(const char* inputfile, const char* outputfile)
{
	ofstream outStream;
	outStream.open(outputfile);
	outStream << inputfile << "\n\n";

	for (int x = 0; x < rows; x++)
	{
		outStream << solvedMaze[x] << endl;
	}

	outStream.close();
}

void Maze::printSolvedMaze(Maze *maze)//output final maze
{
	for (int x = 0; x < maze->getXLength(); x++)
	{
		for (int y = 0; y < maze->getYLength(); y++)
		{
			cout << maze->getSolvedMazeAt(x, y);
		}
		cout << endl;
	}
}
