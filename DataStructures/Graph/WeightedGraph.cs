using System.Text;

namespace DataStructures.Graph;

public class WeightedGraph
{
    private class Node
    {
        public string Label { get; set; }

        public Node(string label)
        {
            Label = label;
        }

        public override string ToString() => Label;
    }

    private class Edge
    {
        private Node From { get; set; }

        private Node To { get; set; }

        private int Weight { get; set; }

        public Edge(Node from, Node to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString() => $"{From.Label} --{Weight}--> {To.Label}";
    }

    private readonly Dictionary<string, Node> _nodes;

    private readonly Dictionary<Node, List<Edge>> _adjacencyList;

    public WeightedGraph()
    {
        _nodes = new Dictionary<string, Node>();
        _adjacencyList = new Dictionary<Node, List<Edge>>();
    }

    public void AddNode(string label)
    {
        if (_nodes.ContainsKey(label))
            throw new InvalidOperationException($"The graph already contains the node {label}");

        var newNode = new Node(label);
        _nodes.Add(label, newNode);
        _adjacencyList.Add(newNode, new List<Edge>());
    }

    public void AddEdge(string from, string to, int weight)
    {
        if (!_nodes.ContainsKey(from))
            throw new ArgumentException($"The node with label {from} doesn't exists in the graph.", nameof(from));
        
        if (!_nodes.ContainsKey(to))
            throw new ArgumentException($"The node with label {to} doesn't exists in the graph.", nameof(to));

        var fromNode = _nodes[from];
        var toNode = _nodes[to];
        
        // check for edge already exists?
        
        _adjacencyList[fromNode].Add(new Edge(fromNode, toNode, weight));
        _adjacencyList[toNode].Add(new Edge(toNode, fromNode, weight));
    }
    
    public void Print()
    {
        Console.WriteLine("Printing the graph...");

        foreach (var (node, neighbours) in _adjacencyList)
        {
            var neighbourSb = new StringBuilder();
            foreach (var neighbour in neighbours)
                neighbourSb.Append(neighbour).Append(" ");
            if (string.IsNullOrEmpty(neighbourSb.ToString().Trim()))
                continue;
            Console.WriteLine($"The node {node.Label} is connected with [ {neighbourSb}]");
        }
    }
}