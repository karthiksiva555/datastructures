namespace Algorithms.Sorting;

public static class SelectionSort
{
    public static void Sort(int[] input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            var smallIndex = i;
            for (var j = i + 1; j < input.Length; j++)
            {
                if (input[smallIndex] > input[j])
                    smallIndex = j;
            }

            (input[i], input[smallIndex]) = (input[smallIndex], input[i]);
        }
    }
}