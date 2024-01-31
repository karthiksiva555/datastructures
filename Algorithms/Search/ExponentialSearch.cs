namespace Algorithms.Search;

public static class ExponentialSearch
{
    public static int Search(int[] sorted, int target)
    {
        var boundary = 1;

        while (boundary < sorted.Length && sorted[boundary] < target)
            boundary *= 2;

        var left = boundary / 2;
        var right = Math.Min(boundary, sorted.Length - 1);

        return BinarySearch(sorted, left, right, target);
    }

    private static int BinarySearch(int[] sorted, int start, int end, int target)
    {
        if (start > end)
            return -1;
        
        var middle = (start + end) / 2;
        if (sorted[middle] == target)
            return middle;

        if (sorted[middle] > target)
            return BinarySearch(sorted, start, middle - 1, target);

        return BinarySearch(sorted, middle + 1, end, target);
    }
}