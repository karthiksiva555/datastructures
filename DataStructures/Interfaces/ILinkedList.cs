namespace DataStructures.Interfaces
{
    interface ILinkedList<T>
    {
        T First { get; set; }
        T Last { get; set; }
        void AddFirst(int value);
        void AddFirst(T node);
        void AddLast(int value);
        void AddLast(T node);
        void AddAfter(T node, int value);
        void AddAfter(T node, T newNode);
        void RemoveFirst();
        void RemoveLast();
        void RemoveAfter(T node);
        void TraverseList();
        bool Contains(int value);
        T Find(int value);
        T FindLast(int value);
    }
}
