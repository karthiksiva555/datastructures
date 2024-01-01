using System.Text;

namespace DataStructures.Graph;

public class Graph
{
    private class Node
    {
        public Node(string label)
        {
            Label = label;
        }

        public string Label { get; set; }
        
        public Node? Next { get; set; } 
    }

    private const int ListLength = 10;

    private readonly Node?[] _adjacencyList;

    private readonly Dictionary<string, int> _nodeIndices;

    private int _count;

    public Graph()
    {
        _adjacencyList = new Node[ListLength];
        _nodeIndices = new Dictionary<string, int>();
    }

    public void AddNode(string label)
    {
        if (_count >= ListLength)
            throw new ArgumentOutOfRangeException(nameof(_count), "The Adjacency list is full"); // This should not be the case, we should always resize the array so that we don't restrict the number of nodes in a graph
        
        _adjacencyList[_count] = new Node(label);
        _nodeIndices.Add(label, _count);
        _count++;
    }

    public void RemoveNode(string label)
    {
        var index = GetNodeIndex(label);
        _adjacencyList[index] = null;
        _nodeIndices.Remove(label);

        for (var i = 0; i < _count; i++)
        {
            if(i == index)
                continue;
            
            var node = _adjacencyList[i];
            RemoveNeighbour(node, label);
        }
    }

    private static void RemoveNeighbour(Node? node, string label)
    {
        while (node is { })
        {
            if (node.Next is { } && node.Next.Label.Equals(label))
            {
                node.Next = node.Next.Next;
                break;
            }
            node = node.Next;
        }
    }

    public void AddEdge(string from, string to)
    {
        var fromIndex = GetNodeIndex(from);

        var node = _adjacencyList[fromIndex];
        if (node == null)
        {
            _adjacencyList[fromIndex] = new Node(to);
            return;
        }
        
        while (node.Next != null)
        {
            if (node.Label.Equals(to))
                throw new InvalidOperationException($"The edge between {from} and {to} already exists.");
            
            node = node.Next;
        }

        node.Next = new Node(to);
    }

    public void RemoveEdge(string from, string to)
    {
        var fromIndex = GetNodeIndex(from);
        var node = _adjacencyList[fromIndex];
        var toNodeFound = false;
        
        while (node != null)
        {
            if (node.Next != null && node.Next.Label.Equals(to))
            {
                node.Next = node.Next.Next;
                toNodeFound = true;
                break;
            }
            node = node.Next;
        }
        
        if(!toNodeFound)
            throw new InvalidOperationException($"No edge found between {from} and {to}");
    }

    public void Print()
    {
        Console.WriteLine("Printing the Graph...");

        foreach (var i in _nodeIndices.Values)
        {
            var node = _adjacencyList[i];
            var message = new StringBuilder($"The node {node?.Label} is connected with: ");
            node = node?.Next;
            
            while (node is { })
            {
                message.Append(node.Label).Append(" ");
                node = node.Next;
            }

            Console.WriteLine(message);
        }
    }

    private int GetNodeIndex(string label)
    {
        if (!_nodeIndices.ContainsKey(label))
            throw new ArgumentOutOfRangeException(nameof(label), $"The graph doesn't contain the node {label}");

        return _nodeIndices[label];
    }
}