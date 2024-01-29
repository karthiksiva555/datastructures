using System.Security.Cryptography;

namespace Algorithms.Sorting;

public static class QuickSort
{
    public static void Sort(int[] input)
    {
        Sort(input, 0, input.Length-1);
    }

    private static void Sort(int[] input, int left, int right)
    {
        // Base case
        if (left >= right)
            return;

        var pivot = input[right];
        var boundary = left - 1;

        for (var i = left; i <= right; i++)
        {
            if (input[i] > pivot)
                continue;

            boundary++;
            (input[boundary], input[i]) = (input[i], input[boundary]);
        }

        Sort(input, left, boundary - 1);
        Sort(input, boundary + 1, right);
    }

}