/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SimpleLists01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            do
            {
                Console.Write("Enter the number: ");
                string numberString = Console.ReadLine();
                if (!double.TryParse(numberString, NumberStyles.Float, new NumberFormatInfo(), out double number))
                {
                    break;
                }

                numbers.Add(number);
                Console.WriteLine($"The average value: {numbers.Average()}");
            }
            while (true);
        }
    }
}
