using System.Collections.Generic;
using System;

// ST10067040
public class BinarySearchTree<T> where T : IComparable<T>
{
    private TreeNode<T> root;

    public void Insert(T value)
    {
        root = InsertRecursive(root, value);
    }

    private TreeNode<T> InsertRecursive(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            return new TreeNode<T>(value);
        }

        if (value.CompareTo(node.Value) < 0)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }

    public int Count()
    {
        return CountNodes(root);
    }

    private int CountNodes(TreeNode<T> node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }

    public List<T> InOrderTraversal()
    {
        var result = new List<T>();
        InOrderTraversalRecursive(root, result);
        return result;
    }

    private void InOrderTraversalRecursive(TreeNode<T> node, List<T> result)
    {
        if (node == null) return;

        InOrderTraversalRecursive(node.Left, result);
        result.Add(node.Value);
        InOrderTraversalRecursive(node.Right, result);
    }
}

public class TreeNode<T>
{
    public T Value;
    public TreeNode<T> Left;
    public TreeNode<T> Right;

    public TreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
