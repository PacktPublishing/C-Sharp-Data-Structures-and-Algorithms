/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System;
using System.Globalization;

namespace SingleDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[12];

            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months[month - 1] = name;
            }

            foreach (string month in months)
            {
                Console.WriteLine($"-> {month}");
            }
        }
    }
}
