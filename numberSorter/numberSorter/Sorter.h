#pragma once

#ifndef SORTER_H //if not defined
#define SORTER_H

#include <cstdlib>
#include <iostream>
#include <fstream>
#include <time.h>
#include <string>
#include <conio.h>
#include <iomanip>

using namespace std;

class Sorter
{

public:
	
double bubbleSort(int numbers[], int arraySize);
double selectionSort(int numbers[], int arraySize);
double insertionSort(int numbers[], int arraySize);
double shellSort(int numbers[], int arraySize);
void generateNumbers(int numbers1[], int numbers2[], int arraySize, int rangeMax);
void saveUnsortedFile(int numbers[], int arraySize, string outFileName);
void saveToFile(int numbers[], int arraySize, string outFileName);
void array2array(int numbers1[], int numbers2[], int arraySize);
int min(int x, int y);
void mergeSortRec(int numbers[], int left, int right, int* tempIntArray);
long double mergeSort(int numbers[], int arraySize);
int pivot(int numbers[], int left, int right, int pivotIndex);
void quickSortRec(int numbers[], int left, int right);
long double quickSort(int numbers[], int arraySize);

		
};

#endif