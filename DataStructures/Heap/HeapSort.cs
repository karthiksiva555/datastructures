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

    public static void Heapify(int[] input)
    {
        for(var i=0; i<input.Length; i++)
        {
            Heapify(input, i);
        }
    }

    private static void Heapify(int[] input, int index)
    {
        var largestIndex = index;

        if (LeftIndex(index) < input.Length && LeftChild(input, index) > input[largestIndex])
            largestIndex = LeftIndex(index);

        if (RightIndex(index) < input.Length && RightChild(input, index) > input[largestIndex])
            largestIndex = RightIndex(index);

        if (largestIndex == index)
            return;
        
        Swap(input, index, largestIndex);
        Heapify(input, largestIndex);
    }

    public static void PrintArray(int[] input)
    {
        Console.WriteLine("Printing the array");
        
        foreach(var item in input)
            Console.WriteLine(item);
    }

    private static int LeftIndex(int index) => index * 2 + 1;
    
    private static int RightIndex(int index) => index * 2 + 2;
    
    private static int LeftChild(IReadOnlyList<int> input, int index) => input[LeftIndex(index)];
    
    private static int RightChild(IReadOnlyList<int> input, int index) => input[RightIndex(index)];

    private static void Swap(IList<int> input, int first, int second)
    {
        (input[second], input[first]) = (input[first], input[second]);
    }

}