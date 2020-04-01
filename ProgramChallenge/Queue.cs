using System;
namespace ProgramChallenge
{
    public class Queue
    {
        private int size = 0;
        private int frontP = 0;
        private int rearP = -1;
        private int maxSize;
        private int[] MyQueue;

        public Queue(int maxSize)
        {
            this.maxSize = maxSize;
            MyQueue = new int[maxSize];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public bool IsFull()
        {
            return size == maxSize;
        }

        public virtual void Enqueue(int newItem)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue full");
            }
            else
            {
                rearP++;
                MyQueue[rearP] = newItem;
                size++;
            }
        }

        public virtual int Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue empty");
                return 0;
            }
            else
            {
                int output = MyQueue[frontP];
                frontP++;
                size--;
                return output;
            }
        }
    }
}
