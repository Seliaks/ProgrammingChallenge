using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Threading;

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

        public void AddNode(GraphNode<T> node)
        {
            _nodes.Add(node);
        }

        public void AddConnection(GraphNode<T> start, GraphNode<T> end, int length)
        {
            start.AddChild(end, length);
            end.AddParent(start, length);
        }

        public void AddConnection()
        {
            Console.Clear();
            int nodeNum = 1;
            foreach (var node in _nodes)
            {
                Console.WriteLine("{0}: {1}", nodeNum,node.GetData());
                nodeNum++;
            }

            Console.Write("Choice: ");
            GraphNode<T> start = _nodes[int.Parse(Console.ReadLine()) - 1];
            
            nodeNum = 1;
            foreach (var node in _nodes)
            {
                if (node != start)
                {
                    Console.WriteLine("{0}: {1}", nodeNum, node.GetData());
                }

                nodeNum++;
            }

            Console.Write("Choice: ");
            GraphNode<T> end = _nodes[int.Parse(Console.ReadLine()) - 1];

            Console.Write("Length: ");
            int length = int.Parse(Console.ReadLine());
            
            start.AddChild(end, length);
            end.AddParent(start, length);
        }

        public FloydTable Floyd()
        {
            FloydTable table = new FloydTable(_nodes);
            table.Display();
            foreach (var via in _nodes)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                foreach (var start in _nodes)
                {
                    if (via != start)
                    {
                        foreach (var end in _nodes)
                        {
                            if (end != start && end != via)
                            {
                                if (table.GetConnectionLength(start, via) +
                                    table.GetConnectionLength(via, end) <
                                    table.GetConnectionLength(start, end) && table.HasConnection(start, via) && table.HasConnection(via, end)) //Not using SetShortest() values from _table, only original connections.
                                {
                                    FloydTable.FloydData shortest = new FloydTable.FloydData(via,
                                        table.GetConnectionLength(start, via) +
                                        table.GetConnectionLength(via, end));
                                    
                                    table.SetShortest(shortest, start, end);
                                    table.Display();
                                    Thread.Sleep(250);
                                }
                            }
                        }
                    }
                }
            }
            return table;
        }

        public class FloydTable
        {
            private List<GraphNode<T>> _nodes;
            private FloydData[,] _floydDatas;

            public FloydTable(List<GraphNode<T>> nodes)
            {
                _nodes = nodes;
                _floydDatas = new FloydData[_nodes.Count, _nodes.Count];
                foreach (var node in _nodes)
                {
                    foreach (var child in _nodes)
                    {
                        _floydDatas[_nodes.FindIndex(x => x.Equals(node)),
                            _nodes.FindIndex(x => x.Equals(child))] = new FloydData(child,
                            node.GetChildConnection(child)
                                .GetLength());
                    }
                }
            }

            public bool HasConnection(GraphNode<T> start, GraphNode<T> end)
            {
                return _floydDatas[_nodes.FindIndex(x => x.Equals(start)),
                    _nodes.FindIndex(x => x.Equals(end))].GetLength() != Int32.MaxValue;
            }

            public int GetConnectionLength(GraphNode<T> start, GraphNode<T> end)
            {
                return _floydDatas[_nodes.FindIndex(x => x.Equals(start)),
                    _nodes.FindIndex(x => x.Equals(end))].GetLength();
            }

            public void SetShortest(FloydData path, GraphNode<T> start, GraphNode<T> end)
            {
                _floydDatas[_nodes.FindIndex(x => x.Equals(start)),
                    _nodes.FindIndex(x => x.Equals(end))] = path;
            }

            public void Display()
            {
                int longestName = 0;
                foreach (var node in _nodes)
                {
                    if (node.GetData().ToString().Length > longestName) longestName = node.GetData().ToString().Length;
                }

                int longest = 0;
                foreach (var floydData in _floydDatas)
                {
                    if (floydData.GetLength().ToString().Length > longest && floydData.GetLength() != Int32.MaxValue)
                        longest = floydData.GetLength().ToString().Length;
                }

                if (longestName > longest) longest = longestName;

                string buffer = new string(' ', longest + 1);
                //Column names (data)
                Console.Write(new string(' ', longestName + 1));
                foreach (var node in _nodes)
                { 
                    Console.Write("{0}{1}", node.GetData(), new string(' ', longest - node.GetData().ToString().Length + 1));
                }
                
                Console.Write(buffer);
                Console.Write(new string(' ', longestName + 1));
                //Column names (routes)
                foreach (var node in _nodes)
                { 
                    Console.Write("{0}{1}", node.GetData(), new string(' ', longestName - node.GetData().ToString().Length + 1));
                }

                Console.WriteLine();
                //Table data
                for (int i = 0; i < _nodes.Count; i++)
                {
                    //Row name (lengths)
                    Console.Write("{0}{1}", _nodes[i].GetData(), new string(' ', longestName - _nodes[i].GetData().ToString().Length + 1));
                    //Row data (lengths)
                    for (int j = 0; j < _nodes.Count; j++)
                    {
                        int length = _floydDatas[i, j].GetLength();
                        if (length == Int32.MaxValue) Console.Write("-{0}", new string(' ', longest));
                        else Console.Write("{0}{1}", length, new string(' ', longest - length.ToString().Length + 1));
                    }
                    Console.Write(buffer);
                    
                    //Row name (routes)
                    Console.Write("{0}{1}",_nodes[i].GetData(), new string(' ', longestName - _nodes[i].GetData().ToString().Length + 1));
                    //Row data (routes)
                    for (int j = 0; j < _nodes.Count; j++)
                    {
                        object node = _floydDatas[i, j].GetNode().GetData();
                        Console.Write("{0}{1}", node, new string(' ',longestName - node.ToString().Length + 1));
                    }

                    Console.WriteLine();
                }
            }

            public class FloydData
            {
                private GraphNode<T> _node;
                private int _length;

                public FloydData(GraphNode<T> nodeGoTo, int length)
                {
                    _node = nodeGoTo;
                    _length = length;
                }

                public int GetLength()
                {
                    return _length;
                }

                public GraphNode<T> GetNode()
                {
                    return _node;
                }
            }
        }
    }
}