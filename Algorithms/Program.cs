using Algorithms;
using Algorithms.Search;
using Algorithms.Sorting;

Console.WriteLine("Hello, Welcome to Algorithms!");

// String Manipulation
//-------------------------------------------------------
const string input = "siva karthik";

// Most Repeated Characters
//-------------------------------------------------------
// var mostRepeated = StringManipulation.MostRepeatedChar("new");
// Console.WriteLine($"Most repeated character is: {mostRepeated}");

var mostRepeated = StringManipulation.MostRepeatedCharNoDictionary("hello howareyoudoing");
Console.WriteLine($"Most repeated character is: {mostRepeated}");


// Remove Duplicates
//-------------------------------------------------------
// var result = StringManipulation.RemoveDuplicateChars("Hellooo!!!!");
// Console.WriteLine($"{result}");

// Rotated Strings
//-------------------------------------------------------
// var result = StringManipulation.RotatedString("ABCD", "BCDA");
// Console.WriteLine($"The strings are rotated: {result}");

// Console.WriteLine($"The strings are rotated: {StringManipulation.RotatedStringSimpler("newton", "nnewto")}");

// Reverse sentence
//-------------------------------------------------------
// const string sentence = "Python is a great programming language";
// Console.WriteLine($"{StringManipulation.ReverseSentence(sentence)}");

// Reverse string
//-------------------------------------------------------
// var reverse = StringManipulation.ReverseStringWithStack(input);
// Console.WriteLine($"The reverse of string {input}: {reverse}");
//
// reverse = StringManipulation.ReverseStringWithoutStack(input);
// Console.WriteLine($"The reverse of string {input}: {reverse}");
//
// reverse = StringManipulation.ReverseStringInPlace(input);
// Console.WriteLine($"The reverse of string {input}: {reverse}");

// Vowel Count
//-------------------------------------------------------

// var vowelCount = StringManipulation.VowelCount(input);
// Console.WriteLine($"Number of vowels in {input}: {vowelCount}");

// Searching Algorithms

// Exponential Search Search
//-------------------------------------------------------
// var sorted = new[] { 2, 5, 7, 8, 11, 15, 19 };
// const int target = 15;
// var result = ExponentialSearch.Search(sorted, target);
// PrintResult(result, target);
//-------------------------------------------------------

// Jump Search
//-------------------------------------------------------
// var sorted = new[] { 2, 5, 7, 8, 11, 15, 19 };
// const int target = 19;
// var result = JumpSearch.Search(sorted, target);
// PrintResult(result, target);
//-------------------------------------------------------

// Ternary Search
//-------------------------------------------------------
// var sorted = new[] { 2, 5, 7, 8, 11, 15, 19 };
// const int target = 19;
// var result = TernarySearch.Search(sorted, target);
// PrintResult(result, target);
//-------------------------------------------------------

// Binary Search
//-------------------------------------------------------
// var sorted = new[] { 2, 5, 7, 8, 11, 15, 19 };
// const int target = 19;
// var result = BinarySearch.Search(sorted, target);
// PrintResult(result, target);
//-------------------------------------------------------

// Linear Search
//-------------------------------------------------------
// var input = new []{ 10, 16, 3, 9, 5 };
// const int searchFor = 25; // 3 or 25;
// var result = LinearSearch.Search(input, searchFor);
// PrintResult(result, searchFor);
//-------------------------------------------------------

void PrintResult(int searchResult, int search)
{
    var message = searchResult == -1
        ? $"Value {search} doesn't exist in input array"
        : $"Value {search} is found at index {searchResult}";
    Console.WriteLine(message);
}

// Sorting Algorithms

// var input = new []{ 10, 16, 3, 9, 5 };
// var input = new []{ 6, 2, 5, 4, 3, 7 }; bucket count = 3

// Bucket Sort
//-------------------------------------------------------
// BucketSort.Sort(input, 5); // Bucket count is important here: max/bucketCount < bucketCount
// PrintArray(input);
//-------------------------------------------------------


// Counting Sort
//-------------------------------------------------------
// CountingSort.Sort(input);
// PrintArray(input);
//-------------------------------------------------------

// Quick Sort
//-------------------------------------------------------
// QuickSort.Sort(input);
// PrintArray(input);
//-------------------------------------------------------

// Merge Sort
//-------------------------------------------------------
// MergeSort.Sort(input);
// PrintArray(input);
//-------------------------------------------------------


// Insertion Sort
//-------------------------------------------------------
// InsertionSort.Sort(input);
// PrintArray(input);

//-------------------------------------------------------


// Selection Sort
//-------------------------------------------------------
// SelectionSort.Sort(input);
// PrintArray(input);

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