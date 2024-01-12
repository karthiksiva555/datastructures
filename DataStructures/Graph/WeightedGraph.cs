using System.Text;

namespace DataStructures.Graph;

public class WeightedGraph
{
    private class Node
    {
        public string Label { get; set; }

        private readonly List<Edge> _edges;

        public Node(string label)
        {
            Label = label;
            _edges = new List<Edge>();
        }

        public override string ToString() => Label;

        public void AddEdge(Node toNode, int weight)
        {
            _edges.Add(new Edge(this, toNode, weight));
        }

        public List<Edge> GetEdges() => _edges;
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

    public WeightedGraph()
    {
        _nodes = new Dictionary<string, Node>();
    }

    public void AddNode(string label)
    {
        if (_nodes.ContainsKey(label))
            throw new InvalidOperationException($"The graph already contains the node {label}");

        _nodes.Add(label, new Node(label));
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
        fromNode.AddEdge(toNode, weight);
        toNode.AddEdge(fromNode, weight);
    }
    
    public void Print()
    {
        Console.WriteLine("Printing the graph...");

        foreach (var node in _nodes.Values)
        {
            var neighbourSb = new StringBuilder();
            foreach (var neighbour in node.GetEdges())
                neighbourSb.Append(neighbour).Append(" ");
            
            if (string.IsNullOrEmpty(neighbourSb.ToString().Trim()))
                continue;
            Console.WriteLine($"The node {node.Label} is connected with [ {neighbourSb}]");
        }
    }
}