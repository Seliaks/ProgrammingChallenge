using System.CodeDom;

namespace ProgramChallenge
{
    public class List
    {
        private Node _head;
        private Node _end;
        private int _length = 0;

        public List()
        {
            _head = null;
            _end = _head;
        }
        
        public List(Node head)
        {
            _head = new Node(head);
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
                _head = new Node(data);
                _end = _head;
            }
            else
            {
                var newItem = new Node(_end, data);
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
            var newItem = new Node(current.GetParent(), data, current);
            current.SetParent(newItem);
            current.GetParent().SetChild(newItem);
            _length++;
        }

        public object Pop()
        {
            Node last = _end;
            _end = _end.GetParent();
            _end.SetChild(null);
            _length--;
            return last;
        }
    }
}