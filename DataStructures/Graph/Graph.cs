using System.ComponentModel.Design;
using System.Text;
using DataStructures.Queue;

namespace DataStructures.Graph;

/// <summary>
/// This graph implementation is using arrays to represent adjacency list 
/// The array item contains linked list of neighbour nodes
/// </summary>
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

    public void TraverseDepthFirst(string startingNode)
    {
        if (!_nodes.ContainsKey(startingNode))
            return;
        
        var visited = new HashSet<Node>();
        TraverseDepthFirst(_nodes[startingNode] ,visited);
    }

    private void TraverseDepthFirst(Node node, ISet<Node> visited)
    {
        Console.WriteLine($"Node: {node.Label}");
        visited.Add(node);

        foreach (var neighbour in _adjacencyList[node])
        {
            if(!visited.Contains(neighbour))
                TraverseDepthFirst(neighbour, visited);
        }
    }

    public void TraverseDepthFirstIterative(string startingNode)
    {
        if (!_nodes.ContainsKey(startingNode))
            return;

        var visited = new HashSet<Node>();
        var stack = new Stack<Node>();
        
        stack.Push(_nodes[startingNode]);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if(visited.Contains(current))
                continue;
            
            Console.WriteLine(current.Label);
            visited.Add(current);

            foreach (var neighbour in _adjacencyList[current])
            {
                if(!visited.Contains(neighbour))
                    stack.Push(neighbour);
            }
        }
    }

    /// <summary>
    /// BFS is implemented iteratively using a queue, its uncommon to implement it using recursion
    /// Even if we want to implement it using recursion, its inefficient and still uses graph, queue as parameters to all calls
    /// </summary>
    /// <param name="startingNode"></param>
    public void TraverseBreadthFirst(string startingNode)
    {
        if (!_nodes.ContainsKey(startingNode))
            return;

        var visited = new HashSet<Node>();
        var queue = new Queue<Node>();
        queue.Enqueue(_nodes[startingNode]);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(visited.Contains(node))
                continue;

            Console.WriteLine($"Node: {node}");
            visited.Add(node);

            foreach (var neighbour in _adjacencyList[node])
            {
                if(!visited.Contains(neighbour))
                    queue.Enqueue(neighbour);
            }
        }
    }

    public void TraverseBreadthFirstRecursive(string startingNode)
    {
        if (!_nodes.ContainsKey(startingNode))
            return;

        var queue = new Queue<Node>();
        queue.Enqueue(_nodes[startingNode]);
        var visited = new HashSet<Node>();
        TraverseBreadthFirst(queue, visited);
    }

    private void TraverseBreadthFirst(Queue<Node> queue, ISet<Node> visited)
    {
        if (queue.Count <= 0)
            return;
        
        var node = queue.Dequeue();
        if (visited.Contains(node))
            return;

        Console.WriteLine($"Node: {node}");
        visited.Add(node);

        // foreach (var neighbour in _adjacencyList[node])
        // {
        //     if(!visited.Contains(neighbour))
        //         queue.Enqueue(neighbour);
        // }
        
        foreach (var neighbour in _adjacencyList[node].Where(neighbour => !visited.Contains(neighbour)))
        {
            queue.Enqueue(neighbour);
        }
        
        TraverseBreadthFirst(queue, visited);
    }

    public List<string> TopologicalSort()
    {
        var stack = new Stack<Node>();
        var visited = new HashSet<Node>();
        foreach(var node in _nodes.Values)
            TopologicalSort(node, visited, stack);
        
        return stack.Select(item => item.Label).ToList();
    }

    private void TopologicalSort(Node node, ISet<Node> visited, Stack<Node> stack)
    {
        if(visited.Contains(node))
            return;

        visited.Add(node);

        foreach(var neighbour in _adjacencyList[node])
            TopologicalSort(neighbour, visited, stack);
        
        stack.Push(node);
    }

    public bool HasCycle()
    {
        var all = new HashSet<Node>();
        var visiting = new HashSet<Node>();
        var visited = new HashSet<Node>();
        
        foreach (var node in _nodes.Values)
            all.Add(node);

        while (all.Count > 0)
        {
            var result = HasCycle(all.First(), all, visiting, visited);
            if (result)
                return true;
        }
        
        return false;
    }

    private bool HasCycle(Node node, ICollection<Node> all, ISet<Node> visiting, ISet<Node> visited)
    {
        if (visiting.Contains(node))
            return true;
        
        all.Remove(node);
        visiting.Add(node);

        foreach (var neighbour in _adjacencyList[node])
        {
            if(visited.Contains(neighbour))
                continue;
            
            if (HasCycle(neighbour, all, visiting, visited))
                return true;
        }

        visiting.Remove(node);
        visited.Add(node);

        return false;
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