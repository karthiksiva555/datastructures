namespace DataStructures.Heap;

public static class HeapSort
{
    public static void SortDescending(int[] input)
    {
        Heap heap = new();
        // var sorted = new int[input.Length];
        
        foreach (var item in input)
        {
            heap.Insert(item);
        }

        for (var i = 0; i < input.Length; i++)
        {
            input[i] = heap.RemoveRoot();
        }
    }
    
    public static void SortAscending(int[] input)
    {
        Heap heap = new();
        // var sorted = new int[input.Length]; // not required; heap sort is in-place algorithm so we can use the input array itself
        
        foreach (var item in input)
        {
            heap.Insert(item);
        }

        for (var i = input.Length-1; i >= 0; i--)
        {
            input[i] = heap.RemoveRoot();
        }
    }
    
}