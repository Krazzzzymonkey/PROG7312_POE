using System.Collections.Generic;

// ST10067040
public class BasicTree<T>
{
    public class Node
    {
        public T Data { get; set; }
        public List<Node> Children { get; set; }

        public Node(T data)
        {
            Data = data;
            Children = new List<Node>();
        }
    }

    public Node Root { get; private set; }

    public BasicTree(T rootData)
    {
        Root = new Node(rootData);
    }
}
