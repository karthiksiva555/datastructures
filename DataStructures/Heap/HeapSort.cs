namespace DataStructures.Heap;

public static class HeapSort
{
    public static int[] SortDescending(int[] unsorted)
    {
        Heap heap = new();
        var sorted = new int[unsorted.Length];
        
        foreach (var item in unsorted)
        {
            heap.Insert(item);
        }

        for (var i = 0; i < sorted.Length; i++)
        {
            sorted[i] = heap.RemoveRoot();
        }
        return sorted;
    }
    
    public static int[] SortAscending(int[] unsorted)
    {
        Heap heap = new();
        var sorted = new int[unsorted.Length];
        
        foreach (var item in unsorted)
        {
            heap.Insert(item);
        }

        for (var i = sorted.Length-1; i >= 0; i--)
        {
            sorted[i] = heap.RemoveRoot();
        }
        
        return sorted;
    }
}