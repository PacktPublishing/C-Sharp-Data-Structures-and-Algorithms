/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System;
using System.Globalization;
using System.Linq;

namespace JaggedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int transportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;
            TransportEnum[][] transport = new TransportEnum[12][];

            for (int month = 1; month <= 12; month++)
            {
                int daysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);
                transport[month - 1] = new TransportEnum[daysCount];
                for (int day = 1; day <= daysCount; day++)
                {
                    int randomType = random.Next(transportTypesCount);
                    transport[month - 1][day - 1] = (TransportEnum)randomType;
                }
            }

            string[] monthNames = GetMonthNames();
            int monthNamesPart = monthNames.Max(n => n.Length) + 2;
            for (int month = 1; month <= transport.Length; month++)
            {
                Console.Write($"{monthNames[month - 1]}:".PadRight(monthNamesPart));
                for (int day = 1; day <= transport[month - 1].Length; day++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = transport[month - 1][day - 1].GetColor();
                    Console.Write(transport[month - 1][day - 1].GetChar());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static string[] GetMonthNames()
        {
            string[] names = new string[12];
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                names[month - 1] = name;
            }
            return names;
        }
    }
}
