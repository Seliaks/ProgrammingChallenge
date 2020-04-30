namespace ProgramChallenge
{
    public class HashData<T>
    {
        private bool _empty;
        private bool _skip;
        private T _data;

        public HashData(T data)
        {
            _data = data;
            _skip = true;
            _empty = false;
        }

        public HashData()
        {
            _skip = false;
            _empty = true;
        }

        public void SetData(T data)
        {
            _data = data;
            _empty = false;
            if (!_skip) _skip = true;
        }

        public T GetData()
        {
            return _data;
        }

        public bool Available()
        {
            return _empty;
        }

        public bool Skip()
        {
            return _skip;
        }
    }
}