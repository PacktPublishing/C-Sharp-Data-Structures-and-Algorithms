/* Exemplary file for Chapter 5 - Variants of Trees. */

using System;
using System.Collections.Generic;

namespace Quiz
{
    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null, null };

        public BinaryTreeNode<T> Left
        {
            get { return (BinaryTreeNode<T>)Children[0] ?? null; }
            set { Children[0] = value; }
        }

        public BinaryTreeNode<T> Right
        {
            get { return (BinaryTreeNode<T>)Children[1] ?? null; }
            set { Children[1] = value; }
        }
    }
}
