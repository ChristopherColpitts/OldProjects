#include "Sorter.h"

double Sorter::bubbleSort(int numbers[], int arraySize)
{
	clock_t startTime = clock();
	
	int compareTo = arraySize;
	do
	{
		int counterPoint = 0;
		for (int i = 1; i < compareTo; i++)
		{
			if (numbers[i - 1] > numbers[i])
			{
				int holder = numbers[i];
				numbers[i] = numbers[i - 1];
				numbers[i - 1] = holder;
				counterPoint = i;
			}
		}
		compareTo = counterPoint;
	} while (compareTo != 0);

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;

	return elapsedTime;
}

double Sorter::selectionSort(int numbers[], int arraySize)
{
	clock_t startTime = clock();
	int pos_min, temp;

	for (int i = 0; i < arraySize; i++)
	{
		pos_min = i;

		for (int j = i + 1; j < arraySize; j++)
		{
			if (numbers[j] < numbers[pos_min])
				pos_min = j;
		}

		if (pos_min != i)
		{
			temp = numbers[i];
			numbers[i] = numbers[pos_min];
			numbers[pos_min] = temp;
		}
	}

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;

	return elapsedTime;
}

double Sorter::insertionSort(int numbers[], int arraySize)
{
	clock_t startTime = clock();

	for (int i = 1; i < arraySize; i++)
	{
		int valuePickedUp = numbers[i];
		int hole = i;

		while ((hole > 0)
			&& (valuePickedUp < numbers[hole - 1]))
		{
			numbers[hole] = numbers[hole - 1];
			hole = hole - 1;
		}

		numbers[hole] = valuePickedUp;
	}

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;

	return elapsedTime;

}

double Sorter::shellSort(int numbers[], int arraySize)
{

	clock_t startTime = clock();

	int j;
	for (int increment = arraySize / 2; increment > 0; increment /= 2)
	{
		for (int i = increment; i < arraySize; i++)
		{
			int temp = numbers[i];
			for (j = i; j >= increment; j -= increment)
			{
				if (temp < numbers[j - increment])
				{
					numbers[j] = numbers[j - increment];
				}
				else
				{
					break;
				}
			}
			numbers[j] = temp;
		}
	}

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;

	return elapsedTime;

}

int Sorter::min(int x, int y)
{
	if (x < y)
	{
		return x;
	}
	else
	{
		return y;
	}
}

void Sorter::mergeSortRec(int numbers[], int left, int right, int* tempIntArray)
{
	if (right == left + 1)
	{
		return;
	}
	else
	{
		int length = right - left;
		int middlePoint = length / 2;
		int posLeft = left;
		int posRight = left + middlePoint;

		mergeSortRec(numbers, left, left + middlePoint, tempIntArray);
		mergeSortRec(numbers, left + middlePoint, right, tempIntArray);

		for (int i = 0; i < length; i++)
		{
			if ((posLeft < left + middlePoint) &&
				((posRight == right)
					|| (min(numbers[posLeft], numbers[posRight]) == numbers[posLeft])))
			{
				tempIntArray[i] = numbers[posLeft];
				posLeft++;
			}
			else
			{
				tempIntArray[i] = numbers[posRight];
				posRight++;
			}
		}

		for (int i = left; i < right; i++)
		{
			numbers[i] = tempIntArray[i - left];
		}
	}
}

long double Sorter::mergeSort(int numbers[], int arraySize)
{
	clock_t startTime = clock();

	int* temp = new int[arraySize];

	mergeSortRec(numbers, 0, arraySize, temp);

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	long double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;
	return elapsedTime;
}

int Sorter::pivot(int numbers[], int left, int right, int pivotIndex)
{
	int pivotValue = numbers[pivotIndex];
	numbers[pivotIndex] = numbers[right];
	numbers[right] = pivotValue;
	int storeIndex = left;

	for (int i = left; i < right; i++)
	{
		if (numbers[i] <= pivotValue)
		{
			int valueHolder = numbers[i];
			numbers[i] = numbers[storeIndex];
			numbers[storeIndex] = valueHolder;
			storeIndex++;
		}
	}

	int valueHolder = numbers[storeIndex];
	numbers[storeIndex] = numbers[right];
	numbers[right] = valueHolder;
	return storeIndex;
}

void Sorter::quickSortRec(int numbers[], int left, int right)
{
	if (left < right)
	{
		int pivotIndex = right;

		int pivotNewIndex = pivot(numbers, left, right, pivotIndex);
		quickSortRec(numbers, left, pivotNewIndex - 1);
		quickSortRec(numbers, pivotNewIndex + 1, right);
	}
}

long double Sorter::quickSort(int numbers[], int arraySize)
{
	clock_t startTime = clock();

	quickSortRec(numbers, -1, (arraySize - 1));

	clock_t endTime = clock();
	clock_t clockTicksTaken = endTime - startTime;
	long double elapsedTime = (clockTicksTaken / (double)CLOCKS_PER_SEC) * 1000;
	return elapsedTime;
}


void Sorter::generateNumbers(int numbers1[], int numbers2[], int arraySize, int rangeMax) {

	srand(time(NULL));

	for (int i = 0; i < arraySize; i++)
	{
		int number = rand() % (rangeMax + 1);
		for (int j = 0; j < 1; j++)
		{
			numbers1[i] = number;
			numbers2[i] = number;
		}
	}
}

void Sorter::saveUnsortedFile(int numbers[], int arraySize, string outFileName)
{
	ofstream outStream(outFileName.c_str());
	if (outStream.fail())
	{
		cerr << "Couldn't open output stream." << endl;
	}
	else
	{
		for (int i = 0; i < arraySize; i++)
		{
			outStream << "Line " << (i + 1) << ":" << numbers[i];
			if (i < (arraySize - 1))
			{
				outStream << endl;
			}
		}

	}
	outStream.close();
}

void Sorter::saveToFile(int numbers[], int arraySize, string outFileName)
{
	ofstream outStream(outFileName.c_str());
	if (outStream.fail())
	{
		cerr << "Couldn't open output stream." << endl;
	}
	else
	{
		for (int i = 0; i < arraySize; i++)
		{
			outStream << "Line " << (i + 1) << ":" << numbers[i];
			if (i < (arraySize - 1))
			{
				outStream << endl;
			}
		}

	}
	outStream.close();
}

void Sorter::array2array(int numbers1[], int numbers2[], int arraySize)
{
	for (int i = 0; i < arraySize; i++)
	{
		if (i < (arraySize - 1))
		{
			numbers1[i] = numbers2[i];
		}
	}
}