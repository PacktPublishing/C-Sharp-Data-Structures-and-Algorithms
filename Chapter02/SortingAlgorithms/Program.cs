/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHeader("SELECTION SORT", false);
            SelectionTest();

            WriteHeader("INSERTION SORT");
            InsertionTest();

            WriteHeader("BUBBLE SORT");
            BubbleTest();

            WriteHeader("QUICKSORT");
            QuicksortTest();
        }

        static void SelectionTest()
        {
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            SelectionSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            float[] floatValues = { -11.2f, 12.56f, -42.59f, 0.0f, 1.1f, 90.9f, 68.68f, 6.1f, -9.8f };
            SelectionSort.Sort(floatValues);
            Console.WriteLine(string.Join(" | ", floatValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            SelectionSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void InsertionTest()
        {
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            InsertionSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            float[] floatValues = { -11.2f, 12.56f, -42.59f, 0.0f, 1.1f, 90.9f, 68.68f, 6.1f, -9.8f };
            InsertionSort.Sort(floatValues);
            Console.WriteLine(string.Join(" | ", floatValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            InsertionSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void BubbleTest()
        {
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            BubbleSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            float[] floatValues = { -11.2f, 12.56f, -42.59f, 0.0f, 1.1f, 90.9f, 68.68f, 6.1f, -9.8f };
            BubbleSort.Sort(floatValues);
            Console.WriteLine(string.Join(" | ", floatValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            BubbleSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void QuicksortTest()
        {
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            QuickSort.Sort(integerValues);
            Console.WriteLine(string.Join(" | ", integerValues));

            float[] floatValues = { -11.2f, 12.56f, -42.59f, 0.0f, 1.1f, 90.9f, 68.68f, 6.1f, -9.8f };
            QuickSort.Sort(floatValues);
            Console.WriteLine(string.Join(" | ", floatValues));

            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };
            QuickSort.Sort(stringValues);
            Console.WriteLine(string.Join(" | ", stringValues));
        }

        static void WriteHeader(string header, bool addLine = true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine((addLine ? Environment.NewLine : string.Empty) + header);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
