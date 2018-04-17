/* Exemplary file for Chapter 3 - Stacks and Queues. */

using System;
using System.Collections.Generic;

namespace ReverseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> chars = new Stack<char>();
            foreach (char c in "LET'S REVERSE!")
            {
                chars.Push(c);
            }

            while (chars.Count > 0)
            {
                Console.Write(chars.Pop());
            }
            Console.WriteLine();
        }
    }
}
