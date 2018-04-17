/* Exemplary file for Chapter 6 - Exploring Graphs. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = new string[]
            {
                "0011100000111110000011111",
                "0011100000111110000011111",
                "0011100000111110000011111",
                "0000000000011100000011111",
                "0000001110000000000011111",
                "0001001110011100000011111",
                "1111111111111110111111100",
                "1111111111111110111111101",
                "1111111111111110111111100",
                "0000000000000000111111110",
                "0000000000000000111111100",
                "0001111111001100000001101",
                "0001111111001100000001100",
                "0001100000000000111111110",
                "1111100000000000111111100",
                "1111100011001100100010001",
                "1111100011001100001000100"
            };
            bool[][] map = new bool[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                map[i] = lines[i]
                    .Select(c => int.Parse(c.ToString()) == 0)
                    .ToArray();
            }

            Graph<string> graph = new Graph<string>(false, true);
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j])
                    {
                        Node<string> from = graph.AddNode($"{i}-{j}");

                        if (i > 0 && map[i - 1][j])
                        {
                            Node<string> to = graph.Nodes.Find(n => n.Data == $"{i - 1}-{j}");
                            graph.AddEdge(from, to, 1);
                        }

                        if (j > 0 && map[i][j - 1])
                        {
                            Node<string> to = graph.Nodes.Find(n => n.Data == $"{i}-{j - 1}");
                            graph.AddEdge(from, to, 1);
                        }
                    }
                }
            }

            Node<string> source = graph.Nodes.Find(n => n.Data == "0-0");
            Node<string> target = graph.Nodes.Find(n => n.Data == "16-24");
            List<Edge<string>> path = graph.GetShortestPathDijkstra(source, target);

            Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < map.Length; row++)
            {
                for (int column = 0; column < map[row].Length; column++)
                {
                    ConsoleColor color = map[row][column] ? ConsoleColor.Green : ConsoleColor.Red;
                    if (path.Any(e => e.From.Data == $"{row}-{column}" || e.To.Data == $"{row}-{column}"))
                    {
                        color = ConsoleColor.White;
                    }

                    Console.ForegroundColor = color;
                    Console.Write("\u25cf ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
