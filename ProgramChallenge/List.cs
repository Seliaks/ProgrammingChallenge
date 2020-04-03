using System.CodeDom;

namespace ProgramChallenge
{
    public class List
    {
        private ListItem _head;
        private ListItem _end;
        private int _length = 0;

        public List()
        {
            _head = null;
            _end = _head;
        }
        
        public List(ListItem head)
        {
            _head = new ListItem(head);
            _end = _head;
            _length++;
        }

        public object GetItem(int position)
        {
            var current = _head;
            for (var i = 0; i < position; i++)
            {
                current = current.GetNext();
            }

            return current.GetData();
        }

        public void Add(object data)
        {
            if (_head == null)
            {
                _head = new ListItem(data);
                _end = _head;
            }
            else
            {
                var newItem = new ListItem(data, _end);
                _end.SetNext(newItem);
                _end = newItem;
            }
            _length++;
        }

        public void Insert(object data, int position)
        {
            var current = _head;
            for (var i = 0; i < position; i++)
            {
                current = current.GetNext();
            }
            var newItem = new ListItem(data, current.GetPrevious(), current);
            current.SetPrevious(newItem);
            current.GetPrevious().SetNext(newItem);
            _length++;
        }

        public object Pop()
        {
            ListItem last = _end;
            _end = _end.GetPrevious();
            _end.SetNext(null);
            _length--;
            return last;
        }
    }
}