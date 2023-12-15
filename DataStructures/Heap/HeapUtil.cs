namespace DataStructures.Heap;

public static class HeapUtil
{
    public static bool IsMaxHeap(int[] input)
    {
        if (input.Length == 0)
            throw new ArgumentNullException(nameof(input), "input array is empty");
        
        return IsMaxHeap(input, 0);
    }

    private static bool IsMaxHeap(int[] input, int index)
    {
        if (index >= input.Length)
            return true;
        
        var leftResult = true;
        if (LeftIndex(index) < input.Length)
            leftResult = input[index] >= LeftChild(input, index) && IsMaxHeap(input, LeftIndex(index));

        if (!leftResult)
            return false;
        
        var rightResult = true;
        if(RightIndex(index) < input.Length)
            rightResult= input[index] >= RightChild(input, index) && IsMaxHeap(input, RightIndex(index));

        return leftResult && rightResult;
    }
    
    public static int FindKthLargest(int[] input, int k)
    {
        if (k < 1 || k >= input.Length)
            throw new ArgumentOutOfRangeException(nameof(k), "The argument is outside the range");
        
        var heap = new Heap();
        
        foreach (var item in input)
            heap.Insert(item); 
        
        var kthLargest = 0;
        while (k-- > 0)
            kthLargest = heap.RemoveRoot();
        
        return kthLargest;
    }
    
    public static void Heapify(int[] input)
    {
        var lastParentIndex = (input.Length / 2) - 1;
        
        // we can start at 0 and go down till last parent, but
        // Starting at the last parent and going upwards reduces the number of recursions
        for(var i=lastParentIndex; i>= 0; i--)
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