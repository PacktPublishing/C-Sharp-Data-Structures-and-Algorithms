/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System.Collections.Generic;

namespace CircularLinkedList
{
    public static class CircularLinkedListExtensions
    {
        public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
        {
            if (node != null && node.List != null)
            {
                return node.Next ?? node.List.First;
            }
            return null;
        }

        public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
        {
            if (node != null && node.List != null)
            {
                return node.Previous ?? node.List.Last;
            }
            return null;
        }
    }
}
