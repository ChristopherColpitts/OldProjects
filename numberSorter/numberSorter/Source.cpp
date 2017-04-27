
//const int ARRAYSIZE = 100000;
//const int RANGEMAX = 32767;
//
//
//// Bubble sort
//void bubbleSort(int numbers[], int arraySize)
//{
//	int compareTo = arraySize;
//
//	do
//	{
//		int counterPoint = 0;
//		for (int i = 1; i < compareTo; i++)
//		{
//			// Check if the number behind is greater than number ahead
//			if (numbers[i - 1] > numbers[i])
//			{
//				int holder = numbers[i];
//				numbers[i] = numbers[i - 1];
//				numbers[i - 1] = holder;
//				counterPoint = i;
//			}
//		}
//		compareTo = counterPoint;
//	} while (compareTo != 0);
//}
//
//
//
//// Selection sort
//void selectionSort(int numbers[], int arraySize)
//{
//	// Start the timer
//	clock_t startTime = clock();
//
//	int pos_min, temp;
//
//	// Do the selection sort
//	for (int i = 0; i < arraySize; i++)
//	{
//		// Set to the current index
//		pos_min = i;
//
//		for (int j = i + 1; j < arraySize; j++)
//		{
//
//			// Find the minimum
//			if (numbers[j] < numbers[pos_min])
//				pos_min = j;
//		}
//
//		// Swap
//		if (pos_min != i)
//		{
//			temp = numbers[i];
//			numbers[i] = numbers[pos_min];
//			numbers[pos_min] = temp;
//		}
//	}
//}
//
//
//// Insertion sort
//void insertionSort(int numbers[], int arraySize)
//{
//	// Do the insertion sort
//	for (int i = 1; i < arraySize; i++)
//	{
//		int valuePickedUp = numbers[i];
//		int hole = i;
//
//		while ((hole > 0)
//			&& (valuePickedUp < numbers[hole - 1]))
//		{
//			// Shift the larger number further into the array
//			numbers[hole] = numbers[hole - 1];
//			// Move the hole
//			hole = hole - 1;
//		}
//
//		// Insert the number
//		numbers[hole] = valuePickedUp;
//	}
//}
//
//// Shell sort
//void shellSort(int numbers[], int arraySize)
//{
//	int j;
//	// Do the shell sort
//	for (int increment = arraySize / 2; increment > 0; increment /= 2)
//	{
//		for (int i = increment; i < arraySize; i++)
//		{
//			int temp = numbers[i];
//			for (j = i; j >= increment; j -= increment)
//			{
//				if (temp < numbers[j - increment])
//				{
//					numbers[j] = numbers[j - increment];
//				}
//				else
//				{
//					break;
//				}
//			}
//			numbers[j] = temp;
//		}
//	}
//}
//
//// Min used by merge sort
//int min(int x, int y)
//{
//	if (x < y)
//	{
//		return x;
//	}
//	else
//	{
//		return y;
//	}
//}
//
//
//// Generate NUMSORTS (6) sets of ARRAYSIZE (10000) numbers and store them into a 2-D array - [10000][7]
//void generateNumbers(int numbers1[], int numbers2[], int arraySize, int rangeMax) {
//
//	// Initalize random seed
//	srand(time(NULL));
//
//	for (int i = 0; i < arraySize; i++)
//	{
//		// Random between 0 and 32767
//		int number = rand() % (rangeMax + 1);
//		for (int j = 0; j < 1; j++)
//		{
//			numbers1[i] = number;
//			numbers2[i] = number;
//		}
//	}
//}
//
//// Save the default unsorted file
//void saveUnsortedFile(int numbers[], int arraySize, string outFileName)
//{
//	// Open the stream
//	ofstream outStream(outFileName.c_str());
//	if (outStream.fail())
//	{
//		cerr << "Couldn't open output stream." << endl;
//	}
//	else
//	{
//		// Write the lines to the file
//		for (int i = 0; i < arraySize; i++)
//		{
//			outStream << "Line " << (i + 1) << ":" << numbers[i];
//			if (i < (arraySize - 1))
//			{
//				outStream << endl;
//			}
//		}
//
//	}
//	// Close the stream
//	outStream.close();
//}
//
//
//// Save the sorted files with Time included at thet top
//void saveToFile(int numbers[], int arraySize, string outFileName)
//{
//	// Open the stream
//	ofstream outStream(outFileName.c_str());
//	if (outStream.fail())
//	{
//		cerr << "Couldn't open output stream." << endl;
//	}
//	else
//	{
//		for (int i = 0; i < arraySize; i++)
//		{
//			outStream << "Line " << (i + 1) << ":" << numbers[i];
//			if (i < (arraySize - 1))
//			{
//				outStream << endl;
//			}
//		}
//
//	}
//	// Close the stream
//	outStream.close();
//}
//
//void array2array(int numbers1[], int numbers2[], int arraySize)
//{
//	for (int i = 0; i < arraySize; i++)
//	{
//		if (i < (arraySize - 1))
//		{
//			numbers1[i] = numbers2[i];
//		}
//	}
//}