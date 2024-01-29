namespace Algorithms.Sorting;

public static class BucketSort
{
    public static void Sort(int[] input, int bucketCount)
    {
        // create buckets array
        var buckets = CreateBuckets(input, bucketCount);

        var k = 0; // counter for input array to store result
        // loop through each bucket and sort
        foreach (var bucket in buckets)
        {
            // Sort the bucket
            bucket.Sort(); 
            
            // Copy the bucket values to result/input array
            foreach (var value in bucket)
                input[k++] = value;
        }
    }

    private static List<List<int>> CreateBuckets(IEnumerable<int> input, int bucketCount)
    {
        var buckets = new List<List<int>>();

        // create buckets
        for (var i = 0; i < bucketCount; i++)
            buckets.Add(new List<int>());
        
        // populate buckets with input array values
        foreach (var value in input)
        {
            var bucketIndex = value / bucketCount;
            buckets[bucketIndex].Add(value);
        }

        return buckets;
    }
}