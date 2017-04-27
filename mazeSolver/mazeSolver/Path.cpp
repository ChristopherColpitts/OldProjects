#include "Path.h"

void Path::MazePath(Maze *maze) {

	
	stack.Push(Position(maze->getStartPoint()[0], maze->getStartPoint()[1]));//Enterence of maze
	maze->setAt(stack.GetTop().getX(), stack.GetTop().getY());

	
	while (stack.GetTop().getY() != maze->getYLength() - 2) {//while the maze has not been completed

		// if move can be made - write
		if (checkMove(stack.GetTop().getX(), stack.GetTop().getY(), maze))
		{

			makeMove(stack.GetTop().getX(), stack.GetTop().getY(), maze);
			
			maze->setAt(stack.GetTop().getX(), stack.GetTop().getY());//write position in maze
		}		
		else if (stack.GetTop().getX() == maze->getStartPoint()[0] && stack.GetTop().getY() == maze->getStartPoint()[1])
		{
			cout << "Maze has no exit";//no exit from maze
		}
		else
		{
			stack.Pop();
		}
	}

	// Create the solved maze
	maze->SolvedMaze(&stack);
}

bool Path::checkMove(int x, int y, Maze * maze)
{
		if (x > 0 && maze->getAt(x - 1, y) == ' ')
		{
			return true;
		}
		else if (x < maze->getXLength() && maze->getAt(x + 1, y) == ' ')
		{
			return true;
		}
		else if (y > 0 && maze->getAt(x, y - 1) == ' ')
		{
			return true;
		}
		else if (y < maze->getYLength() && maze->getAt(x, y + 1) == ' ')
		{
			return true;
		}

	return false;
}

void Path::makeMove(int x, int y, Maze * maze)
{
	if (x > 0 && maze->getAt(x - 1, y) == ' ')
	{
		stack.Push(Position(x - 1, y));
	}
	else if (x < maze->getXLength() && maze->getAt(x + 1, y) == ' ')
	{
		stack.Push(Position(x + 1, y));
	}
	else if (y > 0 && maze->getAt(x, y - 1) == ' ')
	{
		stack.Push(Position(x, y - 1));
	}
	else if (y < maze->getYLength() && maze->getAt(x, y + 1) == ' ')
	{
		stack.Push(Position(x, y + 1));
	}
	else
	{
		cout << "no move";
	}
}