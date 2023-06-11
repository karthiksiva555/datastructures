using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public static class CSharpStack
    {
        public static string ReverseString(string input)
        {
            var newStack = new Stack<char>();
            
            // because we are mutating the string in a loop
            var result = new StringBuilder();

            foreach (var character in input)
                newStack.Push(character);

            while (newStack.Count > 0)
                result.Append(newStack.Pop());
            
            return result.ToString();
        }

        private static bool IsAlphanumeric(char c) 
            => c >= 48 && c <= 57 || c >= 65 && c <= 90 || c >= 97 && c <= 122;

        private static bool IsOperator(char c)
            => c == '+' || c == '-' || c == '*' || c == '%';
        public static bool IsExpressionBalanced(string expression)
        {
            var stack = new Stack<char>();
            var bracketDictionary = new Dictionary<char, char>
            {
                { '>', '<' },
                { ']', '[' },
                { ')', '(' },
                { '}', '{' }
            };

            foreach (var c in expression)
            {
                //if (IsAlphanumeric(c)) continue;

                if (bracketDictionary.ContainsKey(c))
                {
                    if (stack.Count == 0) return false;

                    var popped = stack.Pop();
                    if (!bracketDictionary[c].Equals(popped))
                        return false;
                }
                // Contains value takes O(n) - it is better to check c == '<' || c== '(' => O(1)
                else if(bracketDictionary.ContainsValue(c))
                    stack.Push(c);
            }

            return stack.Count==0;
        }
    }
}
