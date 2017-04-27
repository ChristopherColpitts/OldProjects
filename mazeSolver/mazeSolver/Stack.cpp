#pragma once

#include <cstring>
#include <iostream>
#include "Position.cpp"

using namespace std;

class Stack
{

public:

	// Default constructor
	Stack()
	{
		size = 0;
		array = new Position[size];
	}

	void Pop()
	{
		size--;

		Position *newArray = new Position[size];
		memcpy(newArray, array, size * sizeof(Position));

		delete[] array;
		array = newArray;
	}

	void Push(Position item)
	{
		size++;

		Position * newArray = new Position[size];
		memcpy(newArray, array, size * sizeof(Position));

		delete[] array;
		array = newArray;
		array[size - 1] = Position(item);
	}

	Position GetTop()
	{
		return array[size - 1];
	}

	int GetSize() {
		return size;
	}

private:
	int size;
	Position * array;
};