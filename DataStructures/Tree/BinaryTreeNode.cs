namespace DataStructures.Tree
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Value { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }
}
