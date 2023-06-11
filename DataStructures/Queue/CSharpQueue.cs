using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Queue
{
    public class CSharpQueue
    {
        public static Queue<int> ReverseQueue(Queue<int> input)
        {
            if (input.Count == 0) 
                throw new InvalidOperationException();

            var stack = new Stack<int>();

            while (input.Count > 0)
                stack.Push(input.Dequeue());

            while (stack.Count > 0)
                input.Enqueue(stack.Pop());

            return input;
        }

        public static Queue<int> ReverseFirstKElements(Queue<int> input, int k)
        {
            // Method 1: needs extra queue; not space efficient
            //var stack = new Stack<int>();
            //var output = new Queue<int>();

            //while (k > 0)
            //{
            //    stack.Push(input.Dequeue());
            //    k--;
            //}

            //while (stack.Count > 0)
            //    output.Enqueue(stack.Pop());

            //while (input.Count > 0)
            //    output.Enqueue(input.Dequeue());

            //return output;

            // Method 2: re-use existing queue - mosh solution
            var stack = new Stack<int>();

            // stack will have the first k reversed elements
            for (int i = 0; i < k; i++)
                stack.Push(input.Dequeue());

            // add the reversed elements to the end of the queue 
            while (stack.Count > 0)
                input.Enqueue(stack.Pop());

            // remove the remaining elements and add them at the end
            for (int i = 0; i < input.Count - k; i++)
                input.Enqueue(input.Dequeue());

            return input;
        }
    }
}
