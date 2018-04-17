/* Exemplary file for Chapter 2 - Arrays and Lists. */

using System.Collections;
using System.Collections.Generic;

namespace CircularLinkedList
{
    public class CircularLinkedList<T> : LinkedList<T>
    {
        public new IEnumerator GetEnumerator()
        {
            return new CircularLinkedListEnumerator<T>(this);
        }
    }
}
