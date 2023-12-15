namespace DataStructures.Heap;

public class CSharpMinHeap
{
    private readonly PriorityQueue<string, int> _priorityQueue;

    public CSharpMinHeap()
    {
        _priorityQueue = new PriorityQueue<string, int>();
    }

    public void Insert(string value, int priority)
    {
        _priorityQueue.Enqueue(value, priority);
    }

    public string Remove()
    {
        return _priorityQueue.Dequeue();
    }

    public string PeekMin() => _priorityQueue.Peek();
}