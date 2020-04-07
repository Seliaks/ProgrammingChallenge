using System;
using System.Collections.Generic;

namespace ProgramChallenge
{
    public class TreeNode<T>
    {
        private TreeNode<T> _parent;
        private TreeNode<T> _rightChild;
        private TreeNode<T> _leftChild;
        private readonly Data _data;
        
        public TreeNode(TreeNode<T> parent, T data)
        {
            _parent = parent;
            if (typeof(T) == typeof(string))
            {
                _data = new Data(Convert.ToString(data));
            }
            else if (typeof(T) == typeof(int))
            {
                _data = new Data(Convert.ToInt32(data));
            }
            else if (typeof(T) == typeof(char))
            {
                _data = new Data(Convert.ToChar(data));
            }
        }

        public TreeNode(T data)
        {
            if (typeof(T) == typeof(string))
            {
                _data = new Data(Convert.ToString(data));
            }
            else if (typeof(T) == typeof(int))
            {
                _data = new Data(Convert.ToInt32(data));
            }
            else if (typeof(T) == typeof(char))
            {
                _data = new Data(Convert.ToChar(data));
            }
        }

        public void SetParent(TreeNode<T> parent)
        {
            _parent = parent;
        }

        public void SetRightChild(TreeNode<T> rightChild)
        {
            _rightChild = rightChild;
        }

        public void SetLeftChild(TreeNode<T> leftChild)
        {
            _leftChild = leftChild;
        }

        public TreeNode<T> GetParent()
        {
            return _parent;
        }

        public TreeNode<T> GetRightChild()
        {
            return _rightChild;
        }

        public TreeNode<T> GetLeftChild()
        {
            return _leftChild;
        }
        
        public Data GetData()
        {
            return _data;
        }

        public class Data
        {
            private readonly string _string;
            private readonly int _int;
            private readonly char _char;

            public Data(string s)
            {
                _string = s;
            }

            public Data(int i)
            {
                _int = i;
            }

            public Data(char c)
            {
                _char = c;
            }

            public T1 GetData<T1>()
            {
                if (_string != null) return (T1) Convert.ChangeType(_string, typeof(T));
                if (_char != 0) return (T1) Convert.ChangeType(_char, typeof(T));
                return (T1) Convert.ChangeType(_int, typeof(T));
            }

            public int Compare(TreeNode<T> x)
            {
                if (String.Compare(_string, x._data._string, StringComparison.OrdinalIgnoreCase) != 0) return String.Compare(_string, x._data._string, StringComparison.OrdinalIgnoreCase);
                if (String.Compare(_string, x._data._string, StringComparison.Ordinal) != 0) return String.Compare(_string, x._data._string, StringComparison.Ordinal);
                if (_int.CompareTo(x._data._int) != 0) return _int.CompareTo(x._data._int);
                return _char.CompareTo(x._data._char) != 0 ? _char.CompareTo(x._data._char) : 0;
            }
        }
    }
}