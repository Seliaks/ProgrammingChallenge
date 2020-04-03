using System.Runtime.InteropServices;

namespace ProgramChallenge
{
    public class Stack
    {
        private int _size = 0;
        private int _top = 0;
        private readonly int _maxSize;
        private readonly object[] _myStack;
        private bool _full;

        public Stack(int maxSize)
        {
            this._maxSize = maxSize;
            this._myStack = new object[maxSize];
        }

        public void Add(object data)
        {
            if (!_full)
            {
                _myStack[_top] = data;
                _top++;
                _size++;
            }

            if (_size == _maxSize)
            {
                _full = true;
            }
        }

        public object Pop()
        {
            var data = _myStack[_top];
            _myStack[_top] = new object();
            _full = false;
            _size--;
            return data;
        }

        public bool IsFull()
        {
            return _full;
        }

        public bool IsEmpty()
        {
            return !_full;
        }
    }
}