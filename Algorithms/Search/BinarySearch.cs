namespace Algorithms.Search;

public static class BinarySearch
{
    public static int Search(int[] sorted, int target)
    {
        return SearchRecursive(sorted, target, 0, sorted.Length - 1);
        //return SearchIterative(sorted, target);
    }

    private static int SearchRecursive(int[] sorted, int target, int left, int right)
    {
        if (left > right)
            return -1;
        
        var middle = (left + right) / 2;

        if (sorted[middle] == target)
            return middle;

        if (sorted[middle] > target)
            return SearchRecursive(sorted, target, left, middle - 1);

        return SearchRecursive(sorted, target, middle + 1, right);
    }
    
    private static int SearchIterative(IReadOnlyList<int> sorted, int target)
    {
        int left = 0, right = sorted.Count -1;

        while (left <= right)
        {
            var middle = (left + right) / 2;
            if (sorted[middle] == target)
                return middle;
            if (sorted[middle] > target)
                right = middle - 1;
            else
                left = middle + 1;
        }

        return -1;
    }
}