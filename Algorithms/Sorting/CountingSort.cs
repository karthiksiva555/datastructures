namespace Algorithms.Sorting;

public static class CountingSort
{
    public static void Sort(int[] input)
    {
        // get the max number in input => k
        var max = input.Max();

        // create an array with k size => count
        var counts = new int[max+1];
        
        // loop through input and increment values in count array
        foreach (var value in input)
            counts[value]++;

        var k = 0;
        // loop through count array and populate input array
        for (var i = 0; i < counts.Length; i++)
            for (var j = 0; j < counts[i]; j++)
                input[k++] = i;
    }
}