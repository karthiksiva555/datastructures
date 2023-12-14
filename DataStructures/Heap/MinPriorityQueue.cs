namespace DataStructures.Heap;

public class MinPriorityQueue
{
    private readonly MinHeap _heap;

    public MinPriorityQueue()
    {
        _heap = new MinHeap();
    }

    public void Add(string value, int priority)
    {
        _heap.Insert(priority, value);
    }

    public string Remove()
    {
        var removedNode = _heap.Remove();
        return removedNode.Value;
    }

    public bool IsEmpty() => _heap.IsEmpty();

    public void PrintQueue() => _heap.PrintHeap();
}