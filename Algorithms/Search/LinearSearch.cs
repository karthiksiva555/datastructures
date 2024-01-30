namespace Algorithms.Search;

public static class LinearSearch
{
    // Returns index of the item if found in the array, -1 otherwise
    public static int Search(int[] input, int val)
    {
        for(var i=0; i< input.Length; i++)
            if (input[i] == val)
                return i;
        return -1;
    }
}