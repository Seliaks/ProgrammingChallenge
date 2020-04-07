using System;
using System.Collections.Generic;

namespace ProgramChallenge
{
    public class Tree<T>
    {
        private TreeNode<T> _head;
        private List<T> _traverseList;

        public Tree(TreeNode<T> head)
        {
            _head = head;
        }

        public Tree()
        {
        }

        public void AddNode(TreeNode<T> newNode)
        {
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                TreeNode<T> current = _head;
                bool sorted = false;
                do
                {
                    if (newNode.GetData().Compare(current) > 0)
                    {
                        if (current.GetRightChild() == null)
                        {
                            newNode.SetParent(current);
                            current.SetRightChild(newNode);
                            sorted = true;
                        }
                        else
                        {
                            current = current.GetRightChild();
                        }
                    }
                    else
                    {
                        if (current.GetLeftChild() == null)
                        {
                            newNode.SetParent(current);
                            current.SetLeftChild(newNode);
                            sorted = true;
                        }
                        else
                        {
                            current = current.GetLeftChild();
                        }
                    }
                } while (!sorted);
            }
        }
        
        public void AddNode(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>(data);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                TreeNode<T> current = _head;
                bool sorted = false;
                do
                {
                    if (newNode.GetData().Compare(current) > 0)
                    {
                        if (current.GetRightChild() == null)
                        {
                            newNode.SetParent(current);
                            current.SetRightChild(newNode);
                            sorted = true;
                        }
                        else
                        {
                            current = current.GetRightChild();
                        }
                    }
                    else
                    {
                        if (current.GetLeftChild() == null)
                        {
                            newNode.SetParent(current);
                            current.SetLeftChild(newNode);
                            sorted = true;
                        }
                        else
                        {
                            current = current.GetLeftChild();
                        }
                    }
                } while (!sorted);
            }
        }

        public List<T> SortedTree()
        {
            _traverseList = new List<T>();
            Traverse(_head);
            return _traverseList;
        }

        private void Traverse(TreeNode<T> node)
        {
            if (node == null) return;
            Traverse(node.GetLeftChild());
            _traverseList.Add(node.GetData().GetData<T>());
            Traverse(node.GetRightChild());
        }
    }
}