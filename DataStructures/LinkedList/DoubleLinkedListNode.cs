namespace DataStructures.LinkedList
{
    public class DoubleLinkedListNode : LinkedListNodeBase<DoubleLinkedListNode>
    {
        public DoubleLinkedListNode Previous { get; set; }

        public DoubleLinkedListNode(int value): base(value)
        {

        }
    }
}
