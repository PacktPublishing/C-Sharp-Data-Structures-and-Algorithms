/* Exemplary file for Chapter 4 - Dictionaries and Sets. */

using System;
using System.Collections;

namespace HashtablePhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable phoneBook = new Hashtable()
            {
                { "Marcin Jamro", "000-000-000" },
                { "John Smith", "111-111-111" }
            };

            phoneBook["Lily Smith"] = "333-333-333";
            
            try
            {
                phoneBook.Add("Mary Fox", "222-222-222");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists.");
            }

            Console.WriteLine("Phone numbers:");
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($" - {entry.Key}: {entry.Value}");
                }
            }

            Console.WriteLine();
            Console.Write("Search by name: ");
            string name = Console.ReadLine();
            if (phoneBook.Contains(name))
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Found phone number: {number}");
            }
            else
            {
                Console.WriteLine("The number does not exist.");
            }
        }
    }
}
