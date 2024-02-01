using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms;

public static class StringManipulation
{
    public static int VowelCount(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;
        
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        var vowelCount = 0;
        
        foreach(var ch in input.ToLower())
            if (vowels.Contains(ch))
                vowelCount++;
        
        return vowelCount;
    }

    /// <summary>
    /// This method uses stack to reverse the input string
    /// extra memory => stack and stringBuilder
    /// Space complexity: O(n) + O(n)
    /// </summary>
    /// <param name="input">string to be reversed</param>
    /// <returns>reversed string</returns>
    public static string ReverseStringWithStack(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var stringBuilder = new StringBuilder();
        
        var stack = new Stack<char>();
        foreach(var ch in input)
            stack.Push(ch);
        
        while (stack.Count > 0)
            stringBuilder.Append(stack.Pop());

        return stringBuilder.ToString();
    }
    
    /// <summary>
    /// No extra space is needed for stack but this method still takes O(n) because of the string builder
    /// </summary>
    /// <param name="input">input string to be reversed</param>
    /// <returns>reversed string</returns>
    public static string ReverseStringWithoutStack(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var stringBuilder = new StringBuilder();

        for (var i = input.Length - 1; i >= 0; i--)
            stringBuilder.Append(input[i]);
        
        return stringBuilder.ToString();
    }

    public static string ReverseStringInPlace(string input)
    {
        var start = 0;
        var end = input.Length - 1;
        var inputArray = input.ToCharArray();
        while (start < end)
        {
            (inputArray[end], inputArray[start]) = (inputArray[start], inputArray[end]);
            start++;
            end--;
        }

        return new string(inputArray);
    }

    /// <summary>
    /// This method reverses the string array by swapping first and last, second and second from last etc...
    /// </summary>
    /// <param name="input">the sentence to be reversed</param>
    /// <returns>reversed sentence</returns>
    public static string ReverseSentence(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var stringArray = input.Trim().Split(' ');
        
        var start = 0;
        var end = stringArray.Length - 1;
        
        while (start <= end)
        {
            (stringArray[end], stringArray[start]) = (stringArray[start], stringArray[end]);
            start++;
            end--;
        }

        return string.Join(' ', stringArray);
    }

    /// <summary>
    /// Using C#'s Reverse method on Array
    /// </summary>
    /// <param name="input">the sentence to be reversed</param>
    /// <returns>reversed sentence</returns>
    public static string ReverseSentenceUsingCSharp(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var stringArray = input.Trim().Split(' ');
        Array.Reverse(stringArray);
        
        return string.Join(' ', stringArray);
    }

    public static bool RotatedString(string input, string compared)
    {
        // If two strings are null, are they considered equal? => No
        // if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(compared))
        //     return true;

        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(compared) || input.Length != compared.Length)
            return false;

        var j = compared.IndexOf(input[0]);
        
        foreach (var ch in input)
        {
            if (ch != compared[j])
                return false;
            
            j = (j + 1) % compared.Length;
        }

        return true;
    }

    public static bool RotatedStringSimpler(string input, string compared)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(compared) || input.Length != compared.Length)
            return false;
        
        // Concatenate input with itself. Eg: input = ABCD => concatenated = ABCDABCD
        // check if compared is inside the concatenated string. Eg: compared = BCDA
        // this allocates extra memory. Let's say input has a million chars, we need 2 million chars
        var concatenated = input + input;

        return concatenated.Contains(compared);
    }

    public static string RemoveDuplicateChars(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        
        var set = new HashSet<char>();
        var result = new StringBuilder();

        foreach (var ch in input)
        {
            if(set.Contains(ch))
                continue;
            result.Append(ch);
            set.Add(ch);
        }

        return result.ToString();
    }

    public static char MostRepeatedChar(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "The parameter input is null or empty");
        
        var dictionary = new Dictionary<char, int>();
        var mostRepeated = input[0];
        var maxCount = 1;
        
        foreach (var ch in input)
        {
            if (!dictionary.TryAdd(ch, 1))
                dictionary[ch]++;

            if (dictionary[ch] <= maxCount) 
                continue;
            mostRepeated = ch;
            maxCount = dictionary[ch];
        }

        return mostRepeated;
    }

    public static char MostRepeatedCharNoDictionary(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "The parameter input is null or empty");

        const int asciiCharCount = 256;

        var asciiArray = new int[asciiCharCount];

        // ch is sent as index for asciiArray => C# will convert the character to its ASCII number
        foreach (var ch in input)
            asciiArray[ch]++;

        var maxCount = 0;
        var maxChar = ' ';
        for (var i = 0; i < asciiArray.Length; i++)
        {
            if(asciiArray[i] <= maxCount)
                continue;
            maxCount = asciiArray[i];
            maxChar = (char)i; // converting the index to its character representation
        }

        return maxChar;
    }

    public static string CapitalizeFirstChar(string input)
    {
        if (string.IsNullOrEmpty(input.Trim()))
            return string.Empty;
        
        var processedInput = Regex.Replace(input, @"\s+", " ");
        var words = processedInput.Split(' ');
        for (var i = 0; i < words.Length; i++)
            words[i] = words[i][..1].ToUpper() + words[i][1..].ToLower();

        return string.Join(' ', words);
    }

    // This uses a dictionary to keep the count of characters
    public static bool Anagrams(string input, string compared)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(compared) || input.Length != compared.Length)
            return false;
        
        var map = new Dictionary<char, int>();
        foreach(var ch in input)
            if (!map.TryAdd(ch, 1))
                map[ch]++;

        foreach (var ch in compared)
        {
            if (!map.ContainsKey(ch))
                return false;
            map[ch]--;
        }

        return map.All(m => m.Value == 0);
    }
    
    // Time complexity : O(n log n) because of the sort method used
    public static bool AnagramsSort(string input, string compared)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(compared) || input.Length != compared.Length)
            return false;
        
        var inputArray = input.ToCharArray();
        Array.Sort(inputArray);

        var comparedArray = compared.ToCharArray();
        Array.Sort(comparedArray);

        // return string.Join(' ', inputArray) == string.Join(' ', comparedArray);
        return inputArray.SequenceEqual(comparedArray);
    }

    // This method uses an array to store the char count instead of a dictionary
    public static bool AnagramsWithoutDictionary(string input, string compared)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(compared) || input.Length != compared.Length)
            return false;

        const int alphabets = 26;
        var frequencies = new int[alphabets];

        foreach (var ch in input.ToLower())
            frequencies[ch - 'a']++;

        foreach (var ch in compared.ToLower())
        {
            var index = ch - 'a';
            // the current character didn't exist in input string
            if (frequencies[index] == 0)
                return false;
            frequencies[index]--;
        }

        return frequencies.All(f => f == 0);
    }
}