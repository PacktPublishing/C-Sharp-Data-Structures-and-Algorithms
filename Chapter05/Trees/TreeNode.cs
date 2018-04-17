/* Exemplary file for Chapter 5 - Variants of Trees. */

using System.Collections.Generic;

namespace Trees
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }
    }
}
