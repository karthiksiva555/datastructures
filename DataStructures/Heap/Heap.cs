
namespace DataStructures.Heap;

public class Heap
{
    private readonly int[] _heap = new int[20];

    private int _count;

    public void Insert(int val)
    {
        if (IsFull())
            throw new InvalidOperationException("Heap is full.");
        
        _heap[_count] = val;
        BubbleUp();
        _count++;
    }

    public void RemoveRoot()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap is empty");

        _heap[0] = _heap[_count - 1];
        _heap[_count - 1] = 0; // To remove the item from the array
        _count--;

        BubbleDown();
    }

    public bool IsFull() => _heap.Length-1 == _count;

    public bool IsEmpty() => _count == 0;
    
    public void PrintHeap()
    {
        Console.WriteLine("Printing the Heap");

        for (var i = 0; i < _count; i++)
        {
            Console.WriteLine(_heap[i]);
        }
    }
   
    private void BubbleUp()
    {
        var parent = (_count - 1) / 2;
        var index = _count;
        
        while (parent>=0 && _heap[parent] < _heap[index])
        {
            Swap(parent, index);
            index = parent;
            parent = (index - 1) / 2;
        }
    }

    private void BubbleDown()
    {
        var parent = 0;

        while (!IsValidParent(parent))
        {
            var largerChildIndex = GetLargerChildIndex(parent);
            Swap(parent, largerChildIndex);
            parent = largerChildIndex;
        }
    }

    private bool IsValidParent(int index)
    {
        if (!HasLeftChild(index))
            return true;

        var isValid = _heap[index] >= GetLeftChild(index);
        
        if (HasRightChild(index))
            isValid = isValid && _heap[index] >= GetRightChild(index);

        return isValid;
    } 
        
    
    private int GetLargerChildIndex(int index)
    {
        if (!HasLeftChild(index))
            return index;

        if (!HasRightChild(index))
            return GetLeftIndex(index);
            
        return GetRightChild(index) < GetLeftChild(index) ? GetLeftIndex(index) : GetRightIndex(index);
    }

    private bool HasLeftChild(int index) => GetLeftIndex(index) < _count;
    
    private bool HasRightChild(int index) => GetRightIndex(index) < _count;
    
    private static int GetLeftIndex(int index) => index * 2 + 1;
    
    private static int GetRightIndex(int index) => index * 2 + 2;
    
    private int GetLeftChild(int index) => _heap[GetLeftIndex(index)];
    
    private int GetRightChild(int index) => _heap[GetRightIndex(index)];
    
    private void Swap(int first, int second) => (_heap[second], _heap[first]) = (_heap[first], _heap[second]);
}