/* Exemplary file for Chapter 6 - Exploring Graphs. */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>(false, true);

            Node<string> nodeB1 = graph.AddNode("B1");
            Node<string> nodeB2 = graph.AddNode("B2");
            Node<string> nodeB3 = graph.AddNode("B3");
            Node<string> nodeB4 = graph.AddNode("B4");
            Node<string> nodeB5 = graph.AddNode("B5");
            Node<string> nodeB6 = graph.AddNode("B6");
            Node<string> nodeR1 = graph.AddNode("R1");
            Node<string> nodeR2 = graph.AddNode("R2");
            Node<string> nodeR3 = graph.AddNode("R3");
            Node<string> nodeR4 = graph.AddNode("R4");
            Node<string> nodeR5 = graph.AddNode("R5");
            Node<string> nodeR6 = graph.AddNode("R6");

            graph.AddEdge(nodeB1, nodeB2, 2);
            graph.AddEdge(nodeB1, nodeB3, 20);
            graph.AddEdge(nodeB1, nodeB4, 30);
            graph.AddEdge(nodeB2, nodeB3, 30);
            graph.AddEdge(nodeB2, nodeB4, 20);
            graph.AddEdge(nodeB3, nodeB4, 2);
            graph.AddEdge(nodeB2, nodeR2, 25);
            graph.AddEdge(nodeB4, nodeR4, 25);
            graph.AddEdge(nodeR1, nodeR2, 1);
            graph.AddEdge(nodeR2, nodeR3, 1);
            graph.AddEdge(nodeR3, nodeR4, 1);
            graph.AddEdge(nodeR1, nodeR5, 75);
            graph.AddEdge(nodeR3, nodeR6, 100);
            graph.AddEdge(nodeR5, nodeR6, 3);
            graph.AddEdge(nodeR6, nodeB5, 3);
            graph.AddEdge(nodeB5, nodeB6, 6);
            graph.AddEdge(nodeR6, nodeB6, 10);

            Console.WriteLine("Minimum Spanning Tree - Kruskal's Algorithm:");
            List<Edge<string>> mstKruskal = graph.MinimumSpanningTreeKruskal();
            mstKruskal.ForEach(e => Console.WriteLine(e));
            Console.WriteLine("Total cost: " + mstKruskal.Sum(e => e.Weight));

            Console.WriteLine("\nMinimum Spanning Tree - Prim's Algorithm:");
            List<Edge<string>> mstPrim = graph.MinimumSpanningTreePrim();
            mstPrim.ForEach(e => Console.WriteLine(e));
            Console.WriteLine("Total cost: " + mstPrim.Sum(e => e.Weight));
        }
    }
}
