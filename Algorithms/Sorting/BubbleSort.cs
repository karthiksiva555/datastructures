namespace Algorithms.Sorting;

public static class BubbleSort
{
    // for each iteration n, the nth biggest item is found
    public static void Sort(int[] array)
    {
        var numberOfOperations = 0;
        for(var i=0;i<array.Length; i++)
            for (var j = 1; j < array.Length - i; j++)
            {
                numberOfOperations++;
                if (array[j] < array[j-1])
                    (array[j-1], array[j]) = (array[j], array[j-1]);
            }

        Console.WriteLine($"Number of operations for sorting without optimization: {numberOfOperations}");
    }
    
    // if no swap is done in one iteration, it means the array is sorted already
    // Start with isSorted = true for each iteration of i; set it to false when there is a swap operation
    // At the end of the iteration, check if there is no swap => array is already sorted.
    public static void SortBetter(int[] array)
    {
        var numberOfOperations = 0;
        for (var i = array.Length - 1; i >= 0; i--)
        {
            var isSorted = true;
            for (var j = 0; j < i; j++)
            {
                numberOfOperations++; 
                if (array[j] > array[j + 1])
                {
                    (array[j+1], array[j]) = (array[j], array[j+1]);
                    isSorted = false;
                }
            }

            if (isSorted)
            {
                Console.WriteLine($"Number of operations for sorting with optimization: {numberOfOperations}");
                return;
            }
        }
        Console.WriteLine($"Number of operations for sorting with optimization: {numberOfOperations}");
    }
}