namespace ProgramChallenge
{
    public class ListItem
    {
        private readonly ListItem _previous;
        private object _data;

        public ListItem(object data, ListItem previous)
        {
            this._data = data;
            _previous = previous;
        }

        public ListItem GetParent()
        {
            return _previous;
        }
    }
}