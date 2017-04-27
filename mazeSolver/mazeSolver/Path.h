#pragma once

#ifndef PATH_H //if not defined
#define PATH_H

#include "Stack.cpp"
#include "Position.cpp"
#include "Maze.h"

using namespace std;

class Path
{

public:
	void MazePath(Maze *maze);
	bool checkMove(int x, int y, Maze * maze);
	void makeMove(int x, int y, Maze * maze);

private:
	Stack stack;
};

#endif