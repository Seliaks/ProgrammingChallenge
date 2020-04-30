using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ProgramChallenge
{
    public class HashTable<T>
    {
        private HashData<T>[] _table;
        private Func<T, int> _hashFunction;
        private int _skip;

        public HashTable(int size, Func<T, int> hashFunction, int skip)
        {
            if (size % skip == 0)
                throw new WarningException(
                    "Warning: Skip value is a multiple of the size of the hash table, this could cause a value not to be assigned when there is still a free space in the hash table.");
            _hashFunction = hashFunction;
            _skip = skip;
            _table = new HashData<T>[size];
        }

        public HashTable(int size, int skip)
        {
            if (size % skip == 0)
                throw new WarningException(
                    "Warning: Skip value is a multiple of the size of the hash table, this could cause a value not to be assigned when there is still a free space in the hash table.");
            _hashFunction = DefaultHash;
            _skip = skip;
            _table = new HashData<T>[size];
            for (int i = 0; i < _table.Length; i++)
            {
                _table[i] = new HashData<T>();
            }
        }

        public HashTable(int size, Func<T, int> hashFunction)
        {
            _table = new HashData<T>[size];
            _hashFunction = hashFunction;
            _skip = 1;
        }

        public void SetHashFunction(Func<T, int> hashFunction)
        {
            _hashFunction = hashFunction;
        }

        public void AddData(T data)
        {
            int pointer = _hashFunction(data);
            while (_table[pointer].Skip())
            {
                pointer += _skip;
                pointer %= _table.Length;
            }
            _table[pointer] = new HashData<T>(data);

        }

        private int DefaultHash(T data)
        {
            int total = 0;
            string hashCode = Convert.ToString(data.GetHashCode());
            foreach (int digit in hashCode)
            {
                total += digit;
            }

            total %= _table.Length;
            return total;
        }

        public void Display()
        {
            foreach (var data in _table)
            {
                Console.WriteLine((string)Convert.ChangeType(data.GetData(), typeof(string)));
            }
        }
    }
}