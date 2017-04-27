#include <cstdlib>
#include <iostream>
#include <fstream>
#include <sstream>
#include <time.h>
#include <string>
#include <conio.h>
#include <iomanip>
#include "Sorter.h"
#include <limits>
#include <string>
#include <cstring>


using namespace std;

const int ARRAYSIZE = 100000;
const int RANGEMAX = 32767;

// Main method
int main() {

	Sorter sort;
	string input;
	double time;
	// Numbers array
	int numbers1[ARRAYSIZE];
	int numbers2[ARRAYSIZE];
	// Generate the random numbers
	sort.generateNumbers(numbers1, numbers2, ARRAYSIZE, RANGEMAX);
	// Save the random file
	sort.saveUnsortedFile(numbers1, ARRAYSIZE, "unsortedNumbers.txt");


	cout << "***** Welcome to Number Sorter *****" << endl;
	cout << endl;
	cout << "    Press bu for bubble sort" << endl;
	cout << "    Press se for slection sort" << endl;
	cout << "    Press in for insertion sort" << endl;
	cout << "    Press sh for shell sort" << endl;
	cout << "    Press me for merge sort" << endl;
	cout << "    Press qu for quick sort" << endl;
	cout << "    Type end to terminate program" << endl;
	cout << endl;
	

	cin >> input;

	while (input != "end")
	{

		if (input == "bu")
		{
			//sort with bubble - save to file
			cout << "Sorting numbers please wait" << endl;
			time = sort.bubbleSort(numbers1, ARRAYSIZE);
			cout << "Time to sort: " << time << "ms" << endl;
			cout << "Bubble sort completed - press y to save" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "bubbleSortSorted.txt");
				cout << "File saved to bubbleSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}

			sort.array2array(numbers1, numbers2, ARRAYSIZE);					
			cin >> input;
		}
		else if (input == "se")
		{
			//sort with selection - save to file
			cout << "Sorting numbers please wait" << endl;
			time = sort.selectionSort(numbers1, ARRAYSIZE);
			cout << "Time to sort: " << time << "ms" << endl;
			cout << "Selection sort completed - press y to save" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "selectionSortSorted.txt");
				cout << "File saved to selectionSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}

			sort.array2array(numbers1, numbers2, ARRAYSIZE);		
			cin >> input;
		}
		else if (input == "in")
		{
			//sort with selection - save to file
			cout << "Sorting numbers please wait" << endl;
			time = sort.insertionSort(numbers1, ARRAYSIZE);
			cout << "Time to sort: " << time << "ms" << endl;
			cout << "Insertion sort completed - press y to save" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "insertionSortSorted.txt");
				cout << "File saved to insertionSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}
			sort.array2array(numbers1, numbers2, ARRAYSIZE);
			cin >> input;
		}
		else if (input == "sh")
		{
			//sort with selection - save to file
			cout << "Sorting numbers please wait" << endl;
			time = sort.shellSort(numbers1, ARRAYSIZE);
			cout << "Shell sort completed - press y to save" << endl;
			cout << "Time to sort: " << time << "ms" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "shellSortSorted.txt");
				cout << "File saved to shellSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}

			sort.array2array(numbers1, numbers2, ARRAYSIZE);
			cin >> input;
		}
		else if (input == "qu")
		{
			cout << "Sorting numbers please wait" << endl;
			time = sort.quickSort(numbers1, ARRAYSIZE);
			cout << "Time to sort: " << time << "ms" << endl;
			cout << "Quick sort completed - press y to save" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "quickSortSorted.txt");
				cout << "File saved to quickSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}

			sort.array2array(numbers1, numbers2, ARRAYSIZE);
			cin >> input;
		}
		else if (input == "me")
		{
			cout << "Sorting numbers please wait" << endl;
			time = sort.mergeSort(numbers1, ARRAYSIZE);
			cout << "Time to sort: " << time << "ms" << endl;
			cout << "Merge sort completed - press y to save" << endl;
			cin >> input;
			if (input == "y")
			{
				cout << "Saving" << endl;
				sort.saveToFile(numbers1, ARRAYSIZE, "mergeSortSorted.txt");
				cout << "File saved to mergeSortSorted.txt";
				cout << "Enter another command" << endl;
				cin >> input;
			}

			sort.array2array(numbers1, numbers2, ARRAYSIZE);
			cin >> input;
		}	
	}

	//system("PAUSE");
	return 0;
}




