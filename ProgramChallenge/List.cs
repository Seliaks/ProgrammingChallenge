namespace ProgramChallenge
{
    public class List
    {
        private ListNode _head;
        private ListNode _end;
        private int _length = 0;

        public List()
        {
            _head = null;
            _end = _head;
        }
        
        public List(ListNode head)
        {
            _head = new ListNode(head);
            _end = _head;
            _length++;
        }

        public object GetItem(int position)
        {
            var current = _head;
            for (var i = 0; i < position; i++)
            {
                current = current.GetChild();
            }

            return current.GetData();
        }

        public void Add(object data)
        {
            if (_head == null)
            {
                _head = new ListNode(data);
                _end = _head;
            }
            else
            {
                var newItem = new ListNode(_end, data);
                _end.SetChild(newItem);
                _end = newItem;
            }
            _length++;
        }

        public void Insert(object data, int position)
        {
            var current = _head;
            for (var i = 0; i < position; i++)
            {
                current = current.GetChild();
            }
            var newItem = new ListNode(current.GetParent(), data, current);
            current.SetParent(newItem);
            current.GetParent().SetChild(newItem);
            _length++;
        }

        public object Pop()
        {
            ListNode last = _end;
            _end = _end.GetParent();
            _end.SetChild(null);
            _length--;
            return last;
        }
    }
}