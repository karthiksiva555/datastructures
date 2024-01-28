
using Algorithms.Sorting;

Console.WriteLine("Hello, Welcome to Algorithms!");

var input = new []{ 10, 16, 3, 9, 5 };

// Selection Sort
//-------------------------------------------------------
SelectionSort.Sort(input);
PrintArray(input);

//-------------------------------------------------------


// Bubble Sort
//-------------------------------------------------------
// var unsorted = new []{ 10, 16, 3, 9, 5};
// BubbleSort.Sort(unsorted);
// PrintArray(unsorted);
//
// var alreadySorted = new[] { 1, 3, 4, 8, 10 };
// BubbleSort.Sort(alreadySorted); // takes 10 operations to complete sorting
// BubbleSort.SortBetter(alreadySorted); // takes 4 operations to complete sorting
// PrintArray(alreadySorted);
//-------------------------------------------------------

void PrintArray<T>(IEnumerable<T> array)
{
    Console.WriteLine("Printing the array...");
    foreach(var element in array)
        Console.WriteLine($"{element}");
}