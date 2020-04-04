namespace ProgramChallenge
{
    public class Node
    {
        protected Node Parent;
        protected readonly object Data;
        protected Node Child;

        public Node(Node parent, object data)
        {
            Parent = parent;
            Data = data;
        }

        public Node(Node parent, object data, Node child)
        {
            Parent = parent;
            Data = data;
            Child = child;
        }

        public Node(object data)
        {
            Data = data;
        }

        public void SetParent(Node parent)
        {
            Parent = parent;
        }

        public void SetChild(Node child)
        {
            Child = child;
        }

        public Node GetParent()
        {
            return Parent;
        }

        public object GetData()
        {
            return Data;
        }

        public Node GetChild()
        {
            return Child;
        }
    }
}