using System;

// ST10067040
public class AVLTree<T> where T : IComparable<T>
{
    private class Node
    {
        public T Data;
        public Node Left;
        public Node Right;
        public int Height;

        public Node(T data)
        {
            Data = data;
            Height = 1;
        }
    }

    private Node root;

    public void Insert(T value)
    {
        root = Insert(root, value);
    }

    public T Search(T value)
    {
        Node result = Search(root, value);
        return result != null ? result.Data : default(T); // Returns default value if not found
    }

    private Node Search(Node node, T value)
    {
        if (node == null || node.Data.CompareTo(value) == 0)
        {
            return node;
        }

        if (value.CompareTo(node.Data) < 0)
        {
            return Search(node.Left, value);
        }
        else
        {
            return Search(node.Right, value);
        }
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value.CompareTo(node.Data) < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = Insert(node.Right, value);
        }
        else
        {
            // Duplicate values are not allowed in this AVL Tree
            return node;
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        // Balance the node
        return Balance(node);
    }

    private int GetHeight(Node node)
    {
        return node == null ? 0 : node.Height;
    }

    private Node Balance(Node node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
            }
            return RotateRight(node);
        }

        if (balanceFactor < -1)
        {
            if (GetBalanceFactor(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
            }
            return RotateLeft(node);
        }

        return node;
    }

    private int GetBalanceFactor(Node node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    private Node RotateLeft(Node y)
    {
        Node x = y.Right;
        Node T2 = x.Left;

        x.Left = y;
        y.Right = T2;

        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x;
    }

    private Node RotateRight(Node x)
    {
        Node y = x.Left;
        Node T2 = y.Right;

        y.Right = x;
        x.Left = T2;

        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y;
    }
}
