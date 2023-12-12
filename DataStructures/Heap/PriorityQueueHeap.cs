namespace DataStructures.Heap;

public class PriorityQueueHeap
{
    private readonly Heap _heap = new();

    public void Enqueue(int val)
    {
        _heap.Insert(val);
    }

    public int Dequeue()
    {
        return _heap.RemoveRoot();
    }

    public bool IsFull() => _heap.IsFull();

    public bool IsEmpty() => _heap.IsEmpty();

    public void PrintQueue() => _heap.PrintHeap();
}