using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace ProgramChallenge
{
    public class Graph<T>
    {
        private readonly List<GraphNode<T>> _nodes;

        public Graph(List<GraphNode<T>> nodes)
        {
            _nodes = nodes;
        }

        public Graph()
        {
            _nodes = new List<GraphNode<T>>();
        }

        public void AddNode(GraphNode<T> node, List<GraphNode<T>.Connection> parents, List<GraphNode<T>.Connection> children)
        {
            _nodes.Add(node);
            foreach (var connection in parents)
            {
                connection.GetNode().AddChild(node, connection.GetLength());
            }

            foreach (var connection in children)
            {
                connection.GetNode().AddParent(node, connection.GetLength());
            }
        }

        public void AddConnection(GraphNode<T> start, GraphNode<T> end, int length)
        {
            start.AddChild(end, length);
            end.AddParent(start, length);
        }

        public FloydTable Floyd()
        {
            FloydTable table = new FloydTable(_nodes);
            return table;
        }

        public class FloydTable
        {
            private List<GraphNode<T>> _nodes;
            private string[,] _table;
            private FloydData[,] _floydDatas;

            public FloydTable(List<GraphNode<T>> nodes)
            {
                _nodes = nodes;
                _floydDatas = new FloydData[_nodes.Count, _nodes.Count];
                foreach (var node in _nodes)
                {
                    foreach (var child in node.GetChildren())
                    {
                        _floydDatas[_nodes.FindIndex(x => x.Equals(child)), _nodes.FindIndex(x => x.Equals(node))] = new FloydData(child, node.GetChildConnection(child).GetLength());
                    }
                }
            }

            public void SetShortest(FloydData path, int start, int end)
            {
                
            }

            public class FloydData
            {
                private GraphNode<T> _node;
                private int _length;

                public FloydData(GraphNode<T> nodeGoTo, int length)
                {
                    this._node = nodeGoTo;
                    this._length = length;
                }
            }
        }
    }
}