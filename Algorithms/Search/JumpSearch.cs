namespace Algorithms.Search;

public static class JumpSearch
{
    public static int Search(int[] sorted, int target)
    {
        var blockSize = Convert.ToInt32(Math.Sqrt(sorted.Length));
        var start = 0;
        var next = blockSize;

        while (start < sorted.Length)
        {
            if (sorted[next - 1] > target)
                return LinearSearch(sorted, start, next, target);

            start = next;
            next += blockSize;

            if (next >= sorted.Length)
                return LinearSearch(sorted, start, sorted.Length, target);
        }
        
        return -1;
    }

    public static int SearchByMosh(int[] sorted, int target)
    {
        var blockSize = (int)Math.Sqrt(sorted.Length);
        var start = 0;
        var next = blockSize;
        
        // Loop till we get the block or gets out of bounds
        while (start < sorted.Length && sorted[next - 1] < target)
        {
            start = next;
            next += blockSize;

            if (next > sorted.Length)
                next = sorted.Length;
        }

        return LinearSearch(sorted, start, next, target);
    }

    private static int LinearSearch(int[] input, int start, int end, int target)
    {
        for (var i = start; i < end; i++)
        {
            if (input[i] == target)
                return i;
        }

        return -1;
    } 
}