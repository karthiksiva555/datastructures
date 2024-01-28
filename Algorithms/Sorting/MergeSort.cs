namespace Algorithms.Sorting;

public static class MergeSort
{
    public static void Sort(int[] input)
    {
        if (input.Length < 2)
            return;
        
        var middle = input.Length / 2;
        var leftArray = CreateSubArray(input, 0, middle - 1);
        var rightArray = CreateSubArray(input, middle, input.Length - 1);

        Sort(leftArray);
        Sort(rightArray);

        Merge(leftArray, rightArray, input);
    }

    private static void Merge(int[] leftArray, int[] rightArray, int[] result)
    {
        var leftIndex = 0;
        var rightIndex = 0;
        var currentIndex = 0;

        // Fill the input array till both indexes are not out of bounds
        while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
        {
            result[currentIndex++] = leftArray[leftIndex] < rightArray[rightIndex]
                ? leftArray[leftIndex++]
                : rightArray[rightIndex++]; 
        }

        // if the left subarray has more elements than right
        while (leftIndex < leftArray.Length)
            result[currentIndex++] = leftArray[leftIndex++];

        // if the right subarray has more elements than left
        while (rightIndex < rightArray.Length)
            result[currentIndex++] = rightArray[rightIndex++];
    }
    
    static int[] CreateSubArray(int[] array, int startIndex, int endIndex)
    {
        var length = endIndex - startIndex + 1;
        var subArray = new int[length];
        Array.Copy(array, startIndex, subArray, 0, length);
        return subArray;
    }
}