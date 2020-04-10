using System;
using System.Collections.Generic;

namespace ProgramChallenge
{
    public class GraphNode<T>
    {
        private List<Connection> _parents;
        private readonly T _data;
        private List<Connection> _children;

        public GraphNode(List<Connection> parents, T data)
        {
            _parents = parents;
            _data = data;
            _children = new List<Connection>();
        }

        public GraphNode(List<Connection> parents, T data, List<Connection> children)
        {
            _parents = parents;
            _data = data;
            _children = children;
        }

        public GraphNode(T data)
        {
            _data = data;
            _parents = new List<Connection>();
            _children = new List<Connection>();
        }

        public void AddParent(GraphNode<T> parent, int length)
        {
            _parents.Add(new Connection(parent, length));
        }

        public void SetParents(List<Connection> parents)
        {
            _parents = parents;
        }


        public void AddChild(GraphNode<T> child, int length)
        {
            _children.Add(new Connection(child, length));
        }
        
        public void SetChildren(List<Connection> children)
        {
            _children = children;
        }

        public List<Connection> GetParentConnections()
        {
            return _parents;
        }

        public List<GraphNode<T>> GetParents()
        {
            List<GraphNode<T>> parents = new List<GraphNode<T>>();
            foreach (var connection in _parents)
            {
                parents.Add(connection.GetNode());
            }

            return parents;
        }

        public object GetData()
        {
            return _data;
        }

        public Connection GetChildConnection(GraphNode<T> child)
        {
            Connection noConnection = new Connection(child, Int32.MaxValue);
            Connection connection = _children.Find(x => x.GetNode().Equals(child));
            if (connection == null) return noConnection;
            return connection;
            
        }

        public bool HasConnection(GraphNode<T> child)
        {
            return GetChildConnection(child).GetLength() != Int32.MaxValue;
        }

        public List<Connection> GetChildConnections()
        {
            return _children;
        }
        
        public List<GraphNode<T>> GetChildren()
        {
            List<GraphNode<T>> children = new List<GraphNode<T>>();
            foreach (var connection in _children)
            {
                children.Add(connection.GetNode());
            }

            return children;
        }

        public class Connection
        {
            private GraphNode<T> _node;
            private int _length;

            public Connection(GraphNode<T> node, int length)
            {
                _node = node;
                _length = length;
            }

            public GraphNode<T> GetNode()
            {
                return _node;
            }

            public int GetLength()
            {
                return _length;
            }
        }
    }
}