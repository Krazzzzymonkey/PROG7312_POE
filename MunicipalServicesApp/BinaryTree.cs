// ST10067040
public class BinaryTree<T>
{
    public class Node
    {
        public T Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public Node Root { get; private set; }

    public void AddRoot(T data)
    {
        Root = new Node(data);
    }
}
