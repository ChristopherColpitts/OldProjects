//*************REFERENCES TO HAL FOR STACK SOURCE CODE
//
//******************************************************
#define _CRT_SECURE_NO_WARNINGS

#include <conio.h>
#include <regex>
#include "Maze.h"
#include "Path.h"

using namespace std;

inline bool fileExists(const string& name);

int main()
{

	string mazeName;
	string solvedMaze;
	regex file("([a-z]|[A-Z]):\\\\(([a-z]|[A-Z]|[0-9]|[ ]|[_])+(\\\\))*([a-z]|[A-Z]|[0-9]|[ ]|[_])+\\.txt");//Regular expression																											// Bool for completing maze
	bool created = false;
	const static int startPoint[2] = { 1, 0 };

	cout << "Enter maze to solve" << endl;
	cin >> mazeName;
	cout << "Enter maze to save" << endl;
	cin >> solvedMaze;

	while (!regex_match(mazeName, file) && !regex_match(solvedMaze, file) && !fileExists(mazeName))
	{
		cout << "invalid files" << endl;
		cout << "Enter maze to solve" << endl;
		cin >> mazeName;
		cout << "Enter maze to save" << endl;
		cin >> solvedMaze;
	}

	// Create maze objects
	Maze maze(startPoint, mazeName);
	Maze *mazePointer = &maze;

	// Get path through maze
	Path path;

	// Try and solve maze
	try
	{
		path.MazePath(mazePointer);
		created = true;
	}
	// Failed
	catch (std::exception &e)
	{
		cout << e.what() << endl;
		return 1;
	}

	if (created)
	{
		maze.printSolvedMaze(mazePointer);
		cout << "Maze finished" << endl;
		cout << "Enter 's' to save the solved maze, or any other key to exit the program" << endl;
		char input;
		cin >> input;

		if (input == 's')
		{
			try
			{
				char* result = strcpy((char*)malloc(mazeName.length() + 1), mazeName.c_str());
				char* result2 = strcpy((char*)malloc(solvedMaze.length() + 1), solvedMaze.c_str());
				maze.save(result, result2);

			}
			catch (exception &e)
			{
				cout << e.what() << endl;
				return 1;
			}
			cout << endl << "The maze has been saved to: " << solvedMaze << endl;
			system("PAUSE");
		}
		else 
		{
			cout << "The program will now close" << endl;
		}

		return 0;
	}
}


// File exists method
inline bool fileExists(const string& name) {
	struct stat buffer;
	return (stat(name.c_str(), &buffer) == 0);
}