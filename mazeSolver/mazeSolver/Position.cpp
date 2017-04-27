#pragma once
class Position
{

public:
	Position()
	{
		this->x = 0;
		this->y = 0;
	}

	Position(int x, int y)
	{
		this->x = x;
		this->y = y;
	}

	Position(const Position& other)
	{
		this->x = other.x;
		this->y = other.y;
	}

	int getX()
	{
		return x;
	}

	int getY()
	{
		return y;
	}

private:
	int x, y;

};