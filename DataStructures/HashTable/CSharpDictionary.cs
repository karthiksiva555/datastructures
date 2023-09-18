namespace DataStructures.HashTable
{
    // Keys doesn't have to match; if values are equal, two key value pairs are equal
    public class ValueEqualsComparer : IEqualityComparer<KeyValuePair<int?, string>>
    {
        public bool Equals(KeyValuePair<int?, string> x, KeyValuePair<int?, string> y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode(KeyValuePair<int?, string> obj)
        {
            return HashCode.Combine(obj.Key, obj.Value);
        }
    }

    public static class CSharpDictionary
    {
        public static void DictionaryOperations()
        {
            InterfaceDictionaryOperations();

            // With Dictionary; Can add directly with key,value; ContainsValue is available
            var students = new Dictionary<int?, string>();
            
            students.Add(1, "Siva");
            students.Add(2, "Karthik");
            //students.Add(2, "Duplicate"); // System.ArgumentException: An item with the same key has already been added. Key: 2
            // students.Add(new KeyValuePair<int?,string>(3, "Test")); // Can't be done
            
            students.Add(3, null); // Null value allowed
            students.Add(4, "Rolex");
            PrintDictionary(students);
            
            // students.Add(null, null); // Runtime Exception: System.ArgumentNullException: Value cannot be null. (Parameter 'key')
            //PrintDictionary(students);
            
            Console.WriteLine($"Printing employee with key (number) 2: {students[2]}");
            // Console.WriteLine($"Printing employee with key (number) 20: {students[20]}"); //  System.Collections.Generic.KeyNotFoundException: The given key '20' was not present in the dictionary.
            //students.Add(20, "Temp");
            if(students.TryGetValue(20, out var key20))
            {
                Console.WriteLine($"Printing employee with key (number) 20: {key20}");
            }
            
            Console.WriteLine($"Key 5 Exists? : {students.ContainsKey(5)}");
            
            Console.WriteLine($"Value Jack Exists? : {students.ContainsValue("Jack")}");
            
            
            var karthikExists = students.Contains(new KeyValuePair<int?, string>(200, "Karthik"), new ValueEqualsComparer());
            Console.WriteLine($"Is there an item with value equals to Karthik? (using IEqualityComparer): {karthikExists}");

            students.Remove(3);
            students.Remove(4, out var deleted);
            Console.WriteLine($"Deleted value: {deleted}");
        }

        private static void InterfaceDictionaryOperations()
        {
            // With IDictionary => Can only work with KeyValuePairs; ContainsValue doesn't exist in the interface
            
            IDictionary<int?, string> employees = new Dictionary<int?, string>();
            employees.Add(new KeyValuePair<int?, string>(1, "Siva"));
            employees.Add(new KeyValuePair<int?, string>(2, "Karthik"));
            // employees.Add(new KeyValuePair<int, string>(2, "Nancy")); //  System.ArgumentException: An item with the same key has already been added. Key: 2
            employees.Add(new KeyValuePair<int?, string>(3, null));
            //employees.Add(new KeyValuePair<int?, string>(null, null)); // System.ArgumentNullException: Value cannot be null. (Parameter 'key')
            var kvPair = new KeyValuePair<int?, string>(4, "Rolex");
            employees.Add(kvPair);
            PrintIDictionary(employees);
            
            Console.WriteLine($"Printing employee with key (number) 4: {employees[4]}");
            
            Console.WriteLine($"Key 5 Exists? : {employees.ContainsKey(5)}");
            
            employees.Remove(3);
            PrintIDictionary(employees);

            employees.Remove(kvPair);
            PrintIDictionary(employees);
            
            employees.Add(new KeyValuePair<int?, string>(6, "Panther"));
            employees.Remove(6, out var deleted);
            Console.WriteLine($"Deleted value from dictionry: {deleted}");
        }

        private static void PrintIDictionary(IDictionary<int?, string> dict)
        {
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
            
            foreach (var item in dict)
            {
                Console.WriteLine($"Key :{item.Key}, Value :{item.Value}");                
            }
        }
        
        private static void PrintDictionary(Dictionary<int?, string> dict)
        {
            Console.WriteLine("Printing all keys....");
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
            
            Console.WriteLine("Printing all values....");
            foreach (var value in dict.Values)
            {
                Console.WriteLine(value);
            }
            
            foreach (var item in dict)
            {
                Console.WriteLine($"Key :{item.Key}, Value :{item.Value}");                
            }
        }
        
        public static char GetFirstNonRepeatingChar(string input)
        {
            var dictionary = new Dictionary<char, int>();
            
            foreach (var character in input)
            {
                // if (dictionary.ContainsKey(character))
                //     dictionary[character] += 1;
                // else
                //     dictionary.Add(character, 1);

                var count = dictionary.ContainsKey(character) ? dictionary[character] : 0;
                dictionary[character] = count + 1;
            }

            var result = dictionary.Where(kvp => kvp.Value == 1).Select(kp => kp.Key).FirstOrDefault();

            return result;
        }

        // O(2n) => O(n)
        public static int GetMostFrequentNumber(int[] numbers)
        {
            var dictionary = new Dictionary<int, int>();

            // O(n)
            foreach(var num in numbers)
            {
                if (dictionary.ContainsKey(num))
                    dictionary[num]++;
                else
                    dictionary.Add(num, 1);
            }

            var maxKeyValue = new KeyValuePair<int, int>(); 

            // O(n)
            foreach(var kvp in dictionary)
            {
                if (kvp.Value > maxKeyValue.Value)
                    maxKeyValue = kvp;
            }
            
            return maxKeyValue.Key;
        }

        // O(n^2)
        public static int GetNumberOfPairsWithKDiff(int[] numbers, int k)
        {
            var count = 0;

            foreach(var numi in numbers)
            {
                foreach(var numj in numbers)
                {
                    if (numj != numi && numi - numj == k)
                        count++;
                }
            }
            return count;
        }

        // O(n)
        public static int GetNumberOfPairsWithKDiffBetter(int[] numbers, int k)
        {
            var newSet = new HashSet<int>();
            foreach (var num in numbers)
                newSet.Add(num);

            var count = 0;

            var processedSet = new HashSet<int>();

            foreach (var num in numbers)
            {
                if (processedSet.Contains(num)) continue;

                if (newSet.Contains(num + k))
                    count++;

                if (newSet.Contains(num - k))
                    count++;

                processedSet.Add(num);

                newSet.Remove(num);
            }

            return count;
        }
        
        // NSK O(n) 
        public static int GetNumberOfPairsWithKDiffBetterNsk(int[] numbers, int k)
        {
            var newSet = new HashSet<int>();
            foreach (var num in numbers)
                newSet.Add(num);

            return newSet.Count(num => newSet.Contains(num + k));
        }

        // NSK Solution: O(2n) => O(n)
        public static string GetIndicesOfPairWithKDiff(int[] numbers, int k)
        {
            var dictionary = new Dictionary<int, int>();

            for(var i=0; i< numbers.Length; i++)
            {
                dictionary.Add(numbers[i], i);
            }

            for (var i= 0; i < numbers.Length; i++)
            {
                if (dictionary.ContainsKey(k - numbers[i]))
                    return $"({i}, {dictionary[k - numbers[i]]})";

                dictionary.Remove(numbers[i]);
            }

            return null;
        }

        // Mosh Solution - O(n) - one loop is enough
        public static string GetIndicesOfPairWithKDiffBetter(int[] numbers, int k)
        {
            var dictionary = new Dictionary<int, int>();

            for (var i = 0; i < numbers.Length; i++)
            {
                if (dictionary.ContainsKey(k - numbers[i]))
                    return $"({dictionary[k - numbers[i]]}, {i})";

                dictionary.Add(numbers[i], i);
            }

            return null;
        }
    }
}
