using System;

public class RedBlackTree<T> where T : class, IComparable<T>
{
    private enum NodeColor { Red, Black }

    private class Node
    {
        public T Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public NodeColor Color { get; set; }

        public Node(T data)
        {
            Data = data;
            Color = NodeColor.Red; // New nodes are always red
        }
    }

    private Node root;

    public void Insert(T data)
    {
        Node newNode = new Node(data);
        root = InsertRec(root, newNode);

        FixInsert(newNode);
    }

    private Node InsertRec(Node root, Node newNode)
    {
        if (root == null)
        {
            return newNode;
        }

        if (newNode.Data.CompareTo(root.Data) < 0)
        {
            root.Left = InsertRec(root.Left, newNode);
            root.Left.Parent = root;
        }
        else if (newNode.Data.CompareTo(root.Data) > 0)
        {
            root.Right = InsertRec(root.Right, newNode);
            root.Right.Parent = root;
        }

        return root;
    }

    private void FixInsert(Node node)
    {
        while (node != root && node.Parent.Color == NodeColor.Red)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                Node uncle = node.Parent.Parent.Right;

                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    node.Parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        RotateLeft(node);
                    }

                    node.Parent.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    RotateRight(node.Parent.Parent);
                }
            }
            else
            {
                Node uncle = node.Parent.Parent.Left;

                if (uncle != null && uncle.Color == NodeColor.Red)
                {
                    node.Parent.Color = NodeColor.Black;
                    uncle.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RotateRight(node);
                    }

                    node.Parent.Color = NodeColor.Black;
                    node.Parent.Parent.Color = NodeColor.Red;
                    RotateLeft(node.Parent.Parent);
                }
            }
        }

        root.Color = NodeColor.Black;
    }

    private void RotateLeft(Node node)
    {
        Node temp = node.Right;
        node.Right = temp.Left;

        if (temp.Left != null)
        {
            temp.Left.Parent = node;
        }

        temp.Parent = node.Parent;

        if (node.Parent == null)
        {
            root = temp;
        }
        else if (node == node.Parent.Left)
        {
            node.Parent.Left = temp;
        }
        else
        {
            node.Parent.Right = temp;
        }

        temp.Left = node;
        node.Parent = temp;
    }

    private void RotateRight(Node node)
    {
        Node temp = node.Left;
        node.Left = temp.Right;

        if (temp.Right != null)
        {
            temp.Right.Parent = node;
        }

        temp.Parent = node.Parent;

        if (node.Parent == null)
        {
            root = temp;
        }
        else if (node == node.Parent.Right)
        {
            node.Parent.Right = temp;
        }
        else
        {
            node.Parent.Left = temp;
        }

        temp.Right = node;
        node.Parent = temp;
    }

    public T Find(T data)
    {
        Node node = FindRec(root, data);
        return node?.Data;
    }

    private Node FindRec(Node node, T data)
    {
        if (node == null || node.Data.CompareTo(data) == 0)
        {
            return node;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            return FindRec(node.Left, data);
        }
        else
        {
            return FindRec(node.Right, data);
        }
    }
}
