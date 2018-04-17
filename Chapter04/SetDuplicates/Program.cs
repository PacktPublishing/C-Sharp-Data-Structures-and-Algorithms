/* Exemplary file for Chapter 4 - Dictionaries and Sets. */

using System;
using System.Collections.Generic;

namespace SetDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "Marcin",
                "Mary",
                "James",
                "Albert",
                "Lily",
                "Emily",
                "marcin",
                "James",
                "Jane"
            };
            SortedSet<string> sorted = new SortedSet<string>(
                names,
                Comparer<string>.Create((a, b) => a.ToLower().CompareTo(b.ToLower())));
            foreach (string name in sorted)
            {
                Console.WriteLine(name);
            }
        }
    }
}
