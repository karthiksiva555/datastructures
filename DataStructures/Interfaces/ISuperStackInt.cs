namespace DataStructures.Interfaces
{
    interface ISuperStackInt
    {
        int Count { get; }

        bool IsEmpty { get; }

        int Peek();
        
        int Pop();
        
        void Push(int value);

        void DeleteStack();
    }
}
