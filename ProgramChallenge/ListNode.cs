namespace ProgramChallenge
{
    public class ListNode
    {
        private ListNode _parent;
        private readonly object _data;
        private ListNode _child;

        public ListNode(ListNode parent, object data)
        {
            _parent = parent;
            _data = data;
        }

        public ListNode(ListNode parent, object data, ListNode child)
        {
            _parent = parent;
            _data = data;
            _child = child;
        }

        public ListNode(object data)
        {
            _data = data;
        }

        public void SetParent(ListNode parent)
        {
            _parent = parent;
        }

        public void SetChild(ListNode child)
        {
            _child = child;
        }

        public ListNode GetParent()
        {
            return _parent;
        }

        public object GetData()
        {
            return _data;
        }

        public ListNode GetChild()
        {
            return _child;
        }
    }
}