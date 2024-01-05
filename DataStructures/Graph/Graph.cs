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

        public override string ToString() => Label;

    }

    private readonly Dictionary<Node, List<Node>> _adjacencyList;

    private readonly Dictionary<string, Node> _nodes;

    public Graph()
    {
        _adjacencyList = new Dictionary<Node, List<Node>>();
        _nodes = new Dictionary<string, Node>();
    }

    public void AddNode(string label)
    {
        // Node already exists
        if (_nodes.ContainsKey(label))
            return;
        
        var newNode = new Node(label);
        _nodes.Add(label, newNode);
        _adjacencyList.Add(newNode, new List<Node>());
    }

    public void RemoveNode(string label)
    {
        // Node doesn't exists
        if (!_nodes.TryGetValue(label, out var node))
            return;

        // remove from adjacency list neighbours
        foreach (var neighbours in _adjacencyList.Values)
            neighbours.Remove(node);
        
        // remove from adjacency list node
        _adjacencyList.Remove(node);

        // remove from nodes
        _nodes.Remove(label);
    }

    public void AddEdge(string from, string to)
    {
        if (!_nodes.TryGetValue(from, out var fromNode))
            throw new ArgumentException($"The node {from} does not exists", nameof(from));
        
        if (!_nodes.TryGetValue(to, out var toNode))
            throw new ArgumentException($"The node {to} does not exists", nameof(to));
        
        // Add the edge if it doesn't exists already.
        if(!_adjacencyList[fromNode].Contains(toNode))
            _adjacencyList[fromNode].Add(toNode);
    }

    public void RemoveEdge(string from, string to)
    {
        // If either of the nodes doesn't exist, return.
        if (!_nodes.TryGetValue(from, out var fromNode) || !_nodes.TryGetValue(to, out var toNode))
            return;
        
        _adjacencyList[fromNode].Remove(toNode);
    }

    public void Print()
    {
        Console.WriteLine("Printing the graph...");

        foreach (var (node, neighbours) in _adjacencyList)
        {
            var neighbourSb = new StringBuilder();
            foreach (var neighbour in neighbours)
                neighbourSb.Append(neighbour.ToString()+ ' ');
            Console.WriteLine($"The node {node.Label} is connected with [ {neighbourSb} ]");
        }
    }
}