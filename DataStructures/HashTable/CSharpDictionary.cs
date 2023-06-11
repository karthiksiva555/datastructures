using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.HashTable
{
    public class CSharpDictionary
    {
        public static char GetFirstNonRepeatingChar(string input)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var character in input)
            {
                if (dictionary.ContainsKey(character))
                    dictionary[character] = dictionary[character] + 1;
                else
                    dictionary.Add(character, 1);
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
