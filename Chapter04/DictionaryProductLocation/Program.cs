/* Exemplary file for Chapter 4 - Dictionaries and Sets. */

using System;
using System.Collections.Generic;

namespace DictionaryProductLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> products = new Dictionary<string, string>
            {
                { "5900000000000", "A1" },
                { "5901111111111", "B5" },
                { "5902222222222", "C9" }
            };

            products["5903333333333"] = "D7";

            try
            {
                products.Add("5904444444444", "A3");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists.");
            }

            Console.WriteLine("All products:");
            if (products.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (KeyValuePair<string, string> product in products)
                {
                    Console.WriteLine($" - {product.Key}: {product.Value}");
                }
            }

            Console.WriteLine();
            Console.Write("Search by barcode: ");
            string barcode = Console.ReadLine();
            if (products.TryGetValue(barcode, out string location))
            {
                Console.WriteLine($"The product is in the area {location}.");
            }
            else
            {
                Console.WriteLine("The product does not exist.");
            }
        }
    }
}
