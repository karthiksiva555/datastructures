namespace Algorithms.Search;

public static class TernarySearch
{
    public static int Search(int[] sorted, int target)
    {
        //return SearchIterative(sorted, target);
        return SearchRecursive(sorted, target, 0, sorted.Length - 1);
    }

    private static int SearchIterative(int[] sorted, int target)
    {
        var left = 0;
        var right = sorted.Length - 1;

        while (left <= right)
        {
            // Because its ternary search => divides array to three parts
            var partitionSize = (right - left) / 3; 
            var middle1 = left + partitionSize;
            var middle2 = right - partitionSize;

            if (sorted[middle1] == target)
                return middle1;
            
            if (sorted[middle2] == target)
                return middle2;

            if (target < sorted[middle1])
                right = middle1 - 1;

            if (sorted[middle1] < target && target < sorted[middle2])
            {
                left = middle1 + 1;
                right = middle2 - 1;
            }

            if (sorted[middle2] < target)
                left = middle2 + 1;
        }

        return -1;
    }

    private static int SearchRecursive(int[] sorted, int target, int left, int right)
    {
        if (left > right)
            return -1;
        
        var partitionSize = (right - left) / 3;
        var middle1 = left + partitionSize;
        var middle2 = right - partitionSize;

        if (sorted[middle1] == target)
            return middle1;
        if (sorted[middle2] == target)
            return middle2;

        if (target < sorted[middle1])
            return SearchRecursive(sorted, target, left, middle1 - 1);
        if (sorted[middle1] < target && target < sorted[middle2])
            return SearchRecursive(sorted, target, middle1 + 1, middle2 - 1);
        
        // target between middle2 and right
        return SearchRecursive(sorted, target, middle2 + 1, right);
    }
}