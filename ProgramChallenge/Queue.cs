using System;
namespace ProgramChallenge
{
    public sealed class Queue
    {
        private int _size = 0;
        private int _frontP = 0;
        private int _rearP = -1;
        private readonly int _maxSize;
        private readonly int[] _myQueue;

        public Queue(int maxSize)
        {
            this._maxSize = maxSize;
            _myQueue = new int[maxSize];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool IsFull()
        {
            return _size == _maxSize;
        }

        public void Enqueue(int newItem)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue full");
            }
            else
            {
                _rearP++;
                _myQueue[_rearP] = newItem;
                _size++;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue empty");
                return 0;
            }
            else
            {
                int output = _myQueue[_frontP];
                _frontP++;
                _size--;
                return output;
            }
        }
    }
}
