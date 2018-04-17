/* Exemplary file for Chapter 5 - Variants of Trees. */

using DIBRIS.Hippie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>() { 50, 33, 78, -23, 90, 41 };
            MultiHeap<int> heap = HeapFactory.NewBinaryHeap<int>();
            unsorted.ForEach(i => heap.Add(i));
            Console.WriteLine("Unsorted: " + string.Join(", ", unsorted));

            List<int> sorted = new List<int>(heap.Count);
            while (heap.Count > 0)
            {
                sorted.Add(heap.RemoveMin());
            }
            Console.WriteLine("Sorted: " + string.Join(", ", sorted));
        }
    }
}
