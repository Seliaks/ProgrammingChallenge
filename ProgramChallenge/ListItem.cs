namespace ProgramChallenge
{
    public class ListItem
    {
        private ListItem _previous;
        private readonly object _data;
        private ListItem _next;

        public ListItem(object data, ListItem previous)
        {
            this._data = data;
            _previous = previous;
        }

        public ListItem(object data, ListItem previous, ListItem next)
        {
            _previous = previous;
            _data = data;
            _next = next;
        }

        public ListItem(object data)
        {
            _data = data;
            _previous = null;
        }

        public ListItem GetPrevious()
        {
            return _previous;
        }

        public ListItem GetNext()
        {
            return _next;
        }

        public object GetData()
        {
            return _data;
        }

        public void SetNext(ListItem next)
        {
            this._next = next;
        }

        public void SetPrevious(ListItem previous)
        {
            this._previous = previous;
        }
    }
}