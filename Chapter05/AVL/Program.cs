/* Exemplary file for Chapter 5 - Variants of Trees. */

using System;
using System.Collections.Generic;
using System.DataStructures;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            AvlTree<int> tree = new AvlTree<int>();
            for (int i = 1; i < 10; i++)
            {
                tree.Add(i);
            }

            Console.WriteLine("In-order: " + string.Join(", ", tree.GetInorderEnumerator()));
            Console.WriteLine("Post-order: " + string.Join(", ", tree.GetPostorderEnumerator()));
            Console.WriteLine("Breadth-first: " + string.Join(", ", tree.GetBreadthFirstEnumerator()));

            AvlTreeNode<int> node = tree.FindNode(8);
            Console.WriteLine($"Children of node {node.Value} (height = {node.Height}): {node.Left.Value} and {node.Right.Value}.");
        }
    }
}
