using System.Text;

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
}