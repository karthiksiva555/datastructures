using System.Collections;

namespace DataStructures.HashTable;

public class CSharpHashTable
{
    public static void HashTableOperations()
    {
        // Non-generic version of Dictionary; slow because of boxing/unboxing
        var hashTable = new Hashtable();
            
        hashTable.Add("one", "Student 1");
        hashTable[10] = "Student 2";
        hashTable["two"] = 2;
        hashTable[10] = "New Value"; // this will override the previous value with key 10; no exception like in Dictionaries
            
        Console.WriteLine($"Item with key two: {hashTable["two"]}");

        Console.WriteLine("Printing all hashtable elements:");
        foreach (var item in hashTable)
        {
            Console.WriteLine(item); // Prints item in [key, Value] format
        }
    }

    public static void HashFunctionOperations()
    {
        const int id = 234;
        Console.WriteLine($"Hashcode of number {id} is : {id.GetHashCode()}");

        const long num = 3456456343;
        Console.WriteLine($"Hashcode of number {num} is : {num.GetHashCode()}");

        const string key = "123456-A";
        Console.WriteLine($"Hashcode of string {key} is : {key.GetHashCode()}");
        Console.WriteLine($"Hashcode of string {key} using custom Hash function is {Hash(key)}");
    }

    /// <summary>
    /// Imagine the array size is 100 and key is a string, this is a sample hash function
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private static int Hash(string key)
    {
        var hash = 0;

        foreach (var ch in key)
        {
            hash += ch;
        }
        Console.WriteLine($"The hash of the key {key} is :{hash}");
        return hash % 100;
    }
}