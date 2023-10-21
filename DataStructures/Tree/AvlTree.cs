namespace DataStructures.Tree;

public class AvlTree
{
    private AvlTreeNode? Root { get; set; }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    private static AvlTreeNode Insert(AvlTreeNode? node, int value)
    {
        if (node == null)
            return new AvlTreeNode(value);

        if (node.Value > value)
            node.Left = Insert(node.Left, value);
        else
            node.Right = Insert(node.Right, value);

        SetHeight(node);
        
        node = Balance(node);
        
        return node;
    }

    private static AvlTreeNode Balance(AvlTreeNode? node)
    {
        if (IsLeftHeavy(node))
        {
            if (GetBalanceFactor(node?.Left) < 0)
                node.Left = LeftRotate(node?.Left); // Console.WriteLine($"LeftRotate on {node.Left?.Value}");    

            return RightRotate(node);
            //Console.WriteLine($"RightRotate on {node.Value}");
        }
        else if (IsRightHeavy(node))
        {
            if (GetBalanceFactor(node.Right) > 0)
                node.Right = RightRotate(node.Right); //Console.WriteLine($"RightRotate on {node.Right?.Value}");

            return LeftRotate(node);
            //Console.WriteLine($"LeftRotate on {node.Value}");
        }
        
        return node;
    }

    private static AvlTreeNode LeftRotate(AvlTreeNode? node)
    {
        var newNode = node.Right;
        node.Right = newNode.Left;
        newNode.Left = node;

        SetHeight(node);
        SetHeight(newNode);
        
        return newNode;
    }

    private static AvlTreeNode RightRotate(AvlTreeNode? node)
    {
        var newNode = node.Left;
        node.Left = newNode.Right;
        newNode.Right = node;

        SetHeight(node);
        SetHeight(newNode);

        return newNode;
    }

    private static bool IsLeftHeavy(AvlTreeNode? node)
    {
        var balanceFactor = GetBalanceFactor(node);
        return balanceFactor > 1;
    }
    
    private static bool IsRightHeavy(AvlTreeNode? node)
    {
        var balanceFactor = GetBalanceFactor(node);
        return balanceFactor < -1;
    }
    
    private static void SetHeight(AvlTreeNode node) => node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
    
    private static int Height(AvlTreeNode? node) => node?.Height ?? -1;
    
    private static int GetBalanceFactor(AvlTreeNode? node) => node == null ? 0: Height(node.Left) - Height(node.Right);
}