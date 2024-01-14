using System.Reflection.Metadata;
using System.Runtime.InteropServices.JavaScript;
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
        public Node From { get; set; }

        public Node To { get; set; }

        public int Weight { get; set; }

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
        var fromNode = GetNodeFromLabel(from);
        var toNode = GetNodeFromLabel(to);
        
        // check for edge already exists?
        fromNode.AddEdge(toNode, weight);
        toNode.AddEdge(fromNode, weight);
    }

    public WeightedGraph GetMinimumSpanningTree()
    {
        var tree = new WeightedGraph();
        var queue = new PriorityQueue<Edge, int>();
        var startNode = _nodes.Values.First();
        tree.AddNode(startNode.Label);
        
        // Insert all the edges of the starting node in the priority queue
        foreach(var edge in startNode.GetEdges())
            queue.Enqueue(edge, edge.Weight);

        while (queue.Count > 0)
        {
            var minEdge = queue.Dequeue();

            if (tree._nodes.ContainsKey(minEdge.To.Label))
                continue;
            
            tree.AddNode(minEdge.To.Label);
            tree.AddEdge(minEdge.From.Label, minEdge.To.Label, minEdge.Weight);

            foreach (var edge in minEdge.To.GetEdges())
            {
                if(!tree._nodes.ContainsKey(edge.To.Label))
                    queue.Enqueue(edge, edge.Weight);
            }
        }

        return tree;
    }
    
    public Path GetShortestPath(string from, string to)
    {
        var fromNode = GetNodeFromLabel(from);
        var toNode = GetNodeFromLabel(to);

        HashSet<Node> visited = new();
        Dictionary<Node, int> distances = new();
        Dictionary<Node, Node> previousNodes = new();
        PriorityQueue<Node, int> queue = new();

        foreach (var node in _nodes.Values)
            distances[node] = int.MaxValue;

        distances[fromNode] = 0;

        queue.Enqueue(fromNode, 0);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            visited.Add(currentNode);
            
            foreach (var edge in currentNode.GetEdges())
            {
                if (visited.Contains(edge.To))
                    continue;
                
                var newDistance = distances[currentNode] + edge.Weight;

                // shorter distance is found.
                if (newDistance < distances[edge.To])
                {
                    distances[edge.To] = newDistance;
                    previousNodes[edge.To] = currentNode;
                    queue.Enqueue(edge.To, edge.Weight);
                }
            }
        }

        return BuildPath(previousNodes, distances, toNode);
    }

    private static Path BuildPath(IReadOnlyDictionary<Node, Node> previousNodes, IReadOnlyDictionary<Node, int> distances, Node toNode)
    {
        Stack<Node> stack = new();
        stack.Push(toNode);
        var current = toNode;
        while (previousNodes.ContainsKey(current))
        {
            stack.Push(previousNodes[current]);
            current = previousNodes[current];
        }

        var path = new Path();
        
        while (stack.Count > 0)
            path.Add(stack.Pop().Label);
        
        path.SetDistance(distances[toNode]);
        
        return path;
    }

    private Node GetNodeFromLabel(string label)
    {
        if (!_nodes.ContainsKey(label))
            throw new ArgumentException($"The node with label {label} doesn't exists in the graph.", nameof(label));

        return _nodes[label];
    }

    public bool HasCycle()
    {
        // when node has 5 edges, only A, B, C are connected and D and E are connected to each other but not connected to A, B, C
        // the foreach loop will run 5 times, one for each node
        // Let's say we started with node A, since we are doing DFS, recursion will also visit B and C. So no need to take B or C as starting nodes
        // Keeping visited outside the loop helps in skipping the nodes that are already visited.
        HashSet<Node> visited = new();
        
        foreach (var node in _nodes.Values)
        {
            if (!visited.Contains(node) && HasCycle(node, null, visited))
                return true;
        }

        return false;
    }

    private bool HasCycle(Node node, Node? previous, ISet<Node> visited)
    {
        visited.Add(node);
        
        foreach (var edge in node.GetEdges())
        {
            if(edge.To == previous)
                continue;
            
            if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited))
                return true;
        }
        
        return false;
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