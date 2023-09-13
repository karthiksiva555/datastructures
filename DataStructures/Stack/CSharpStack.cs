using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Stack
{
    public static class CSharpStack
    {
        private static List<char> _leftBrackets = new List<char> { '{', '(', '[', '<' };
        
        private static List<char> _rightBrackets = new List<char> { '}', ')', ']', '>' };

        public static string ReverseString(string? input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "the value for the input parameter cannot be null");
            }
            
            var newStack = new Stack<char>();
            
            // because we are mutating the string in a loop
            var result = new StringBuilder();
       
            foreach (var character in input)
                newStack.Push(character);

            while (newStack.Count > 0)
                result.Append(newStack.Pop());
            
            return result.ToString();
        }

        /// <summary>
        /// 48 - 57 => numbers 1 to 9
        /// 65 - 90 => Capital letters A to Z
        /// 97 - 122 => Small letters a to z
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool IsAlphanumeric(char c) 
            => c >= 48 && c <= 57 || c >= 65 && c <= 90 || c >= 97 && c <= 122;

        private static bool IsOperator(char c)
            => c is '+' or '-' or '*' or '%';
        public static bool IsExpressionBalanced(string? expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression),
                    "The value to the parameter expression cannot be null");
            }
            
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

        public static bool IsExpressionBalancedNoDict(string? expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression),
                    "The value to the parameter expression cannot be null");
            }
            
            var stack = new Stack<char>();

            foreach (var ch in expression)
            {
                if (IsLeftBracket(ch))
                {
                    stack.Push(ch);
                }

                if (!IsRightBracket(ch)) continue;
                
                if (stack.Count == 0) return false; // expression has a closed bracket without opening bracket 

                var top = stack.Pop();
                if (!BracketsMatch(top, ch)) return false;
            }

            return stack.Count == 0;
        }

        private static bool IsLeftBracket(char ch)
        {
            return _leftBrackets.Contains(ch);
        }
        
        private static bool IsRightBracket(char ch)
        {
            return _rightBrackets.Contains(ch);
        }

        private static bool BracketsMatch(char left, char right)
        {
            return _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
        }
    }
}
