namespace DataStructures.Tree;

public class AvlTreeNode
{
    public int Value { get; set; }

    public int Height { get; set; }

    public AvlTreeNode? Left { get; set; }

    public AvlTreeNode? Right { get; set; }

    public AvlTreeNode(int value)
    {
        Value = value;
        Height = 0;
    }

    public override string ToString()
    {
        return $"Node : {Value}";
    }
}