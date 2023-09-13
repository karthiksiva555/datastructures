namespace DataStructures.LinkedList;

public class CSharpLinkedList
{
    private LinkedList<int> _linkedList;

    public CSharpLinkedList()
    {
        _linkedList = new LinkedList<int>();
    }

    public void Operations()
    {
        _linkedList.AddFirst(3);
        _linkedList.AddFirst(2);
        
       PrintLinkedList();

        _linkedList.AddLast(4);
        _linkedList.AddLast(5);
        
        PrintLinkedList();

        LinkedListNode<int> newNode = new LinkedListNode<int>(10);
        _linkedList.AddAfter(_linkedList.First, newNode);
        
        PrintLinkedList();
        
        Console.WriteLine(_linkedList.Count);
    }

    private void PrintLinkedList()
    {
        Console.WriteLine("The Linked List:");
        foreach (var node in _linkedList)
        {
            Console.WriteLine(node);
        }
    }
}