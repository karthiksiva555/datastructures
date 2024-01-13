namespace DataStructures.Graph;

public class Path
{
    public Path()
    {
        Nodes = new List<string>();
    }

    private int Distance { get; set; }

    private List<string> Nodes { get; }
    
    public void Add(string label)
    {
        Nodes.Add(label);
    }

    public void SetDistance(int distance)
    {
        Distance = distance;
    }

    public override string ToString() => $"Path: [{string.Join("->",Nodes)}] and Distance: {Distance}";
}