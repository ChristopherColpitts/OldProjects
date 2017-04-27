#pragma once

#ifndef MAZE_H //if not defined
#define MAZE_H

#include <fstream>
#include "Stack.cpp"

using namespace std;

class Maze
{

public:
	Maze(const int* startPoint, const string& path);
	char getAt(int x, int y);
	void setAt(int x, int y);
	int getXLength();
	int getYLength();
	const int *getStartPoint();
	void SolvedMaze(Stack *stack);
	char getSolvedMazeAt(int x, int y);
	void save(const char* inputfile, const char* outputfile);
	void printSolvedMaze(Maze *maze);

private:
	int rows, rowLength;
	const int *startPoint;
	char **maze, **solvedMaze;

};

#endif