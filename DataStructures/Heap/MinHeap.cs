namespace DataStructures.Heap;

public struct Node
{
    public int Key;
    public string Value;

    public Node(int key, string value)
    {
        Key = key;
        Value = value;
    }
}

public class MinHeap
{
    private int _count = 0;
    private readonly Node[] _heap = new Node[10];
    
    public void Insert(int key, string value)
    {
        if (IsFull())
            throw new InvalidOperationException("Heap is full");

        _heap[_count] = new Node(key, value);
        BubbleUp(_count++);
    }

    public Node Remove()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Heap is empty");

        var removed = _heap[0];
        _heap[0] = _heap[--_count];
        _heap[_count] = new Node();
        BubbleDown(0);

        return removed;
    }

    public void PrintHeap()
    {
        for(var i=0; i< _count; i++)
            Console.WriteLine($"Key:{_heap[i].Key}, Value: {_heap[i].Value}");
    }
 
    private void BubbleDown(int index)
    {
        if (index >= _count)
            return;

        var smallerIndex = index;
        
        var leftIndex = index * 2 + 1;
        if (leftIndex < _count && _heap[leftIndex].Key <= _heap[smallerIndex].Key)
            smallerIndex = leftIndex;

        var rightIndex = index * 2 + 2;
        if (rightIndex < _count && _heap[rightIndex].Key <= _heap[smallerIndex].Key)
            smallerIndex = rightIndex;

        if (index == smallerIndex)
            return;
        
        (_heap[smallerIndex], _heap[index]) = (_heap[index], _heap[smallerIndex]);
        BubbleDown(smallerIndex);
    }
    
    private void BubbleUp(int index)
    {
        if (index <= 0)
            return;
        var parentIndex = (index - 1) / 2;
        if (_heap[index].Key >= _heap[parentIndex].Key) 
            return;
        
        (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);
        BubbleUp(parentIndex);
    }

    public bool IsFull() => _count == _heap.Length;

    public bool IsEmpty() => _count == 0;

}