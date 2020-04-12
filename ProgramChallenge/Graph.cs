using System;
using System.Collections.Generic;
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

        public void RemoveNode()
        {
            int nodeNum = 1;
            foreach (var node in _nodes)
            {
                Console.WriteLine("{0}: {1}", nodeNum, node.GetData());
                nodeNum++;
            }
            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());
            GraphNode<T> removeNode = _nodes[choice - 1];

            foreach (var child in removeNode.GetChildren())
            {
                child.RemoveParent(removeNode);
            }

            foreach (var parent in removeNode.GetParents())
            {
                parent.RemoveChild(removeNode);
            }

            _nodes.Remove(removeNode);
        }

        private void AddConnection(GraphNode<T> start, GraphNode<T> end, int length)
        {
            foreach (var node in _nodes)
            {
                if (node.GetData() == start.GetData()) start = node;
                if (node.GetData() == end.GetData()) end = node;
            }
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

        public void AddUndirectedConnection()
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
            
            AddConnection(start, end, length);
            AddConnection(end, start, length);
        }

        public void RemoveConnection()
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
            
            start.RemoveChild(end);
            end.RemoveParent(start);
        }

        public void Sort()
        {
            _nodes.Sort();
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
                                }
                            }
                        }
                    }
                } 
                table.Display();
                Thread.Sleep(2000);
            }
            return table;
        }

        public Graph<T> Prim()
        {
            Graph<T> minimalSpanningTree = new Graph<T>(new List<GraphNode<T>> {new GraphNode<T>((T)_nodes[0].GetData())});
            int length = 0;

            List<GraphNode<T>> connectedNodes = new List<GraphNode<T>> {_nodes[0]};

            while (minimalSpanningTree._nodes.Count != _nodes.Count)
            {
                GraphNode<T>.Connection shortestConnection = new GraphNode<T>.Connection(connectedNodes[0], Int32.MaxValue);
                GraphNode<T> shortestConnectionNode = _nodes[0];
                foreach (var node in connectedNodes)
                {
                    foreach (var connection in node.GetChildConnections())
                    {
                        if (connection.GetLength() < shortestConnection.GetLength())
                        {
                            if (connectedNodes.Contains(connection.GetNode())) continue;
                            shortestConnectionNode = node;
                            shortestConnection = connection;
                        }
                    }
                }

                length += shortestConnection.GetLength();
                connectedNodes.Add(shortestConnection.GetNode());
                minimalSpanningTree.AddNode(new GraphNode<T>((T)shortestConnection.GetNode().GetData()));
                minimalSpanningTree.AddConnection(shortestConnectionNode, shortestConnection.GetNode(), shortestConnection.GetLength());
                minimalSpanningTree.AddConnection(shortestConnection.GetNode(), shortestConnectionNode, shortestConnection.GetLength());
            }

            foreach (var node in minimalSpanningTree._nodes)
            {
                Console.Write("{0}: ", (string)Convert.ChangeType(node.GetData(), typeof(string)));
                foreach (var child in node.GetChildren())
                {
                    Console.Write("{0}, {1}; ", (string)Convert.ChangeType(child.GetData(), typeof(string)), node.GetChildConnection(child).GetLength());
                }
                Console.WriteLine();
            }

            Console.WriteLine(length);

            return minimalSpanningTree;
        }

        public Graph<T> Kruskal() //Cannot distinguish between two unconnected MST's and a cycle - Use Dijkstra's with < Int32.MaxValue instead of line 280?
        {
            Graph<T> minimalSpanningTree = new Graph<T>(new List<GraphNode<T>>());
            int length = 0;

            List<GraphNode<T>> connectedNodes = new List<GraphNode<T>>();

            while (minimalSpanningTree._nodes.Count != _nodes.Count)
            {
                Console.WriteLine(minimalSpanningTree._nodes.Count);
                GraphNode<T>.Connection shortestConnection = new GraphNode<T>.Connection(_nodes[0], Int32.MaxValue);
                GraphNode<T> shortestConnectionNode = _nodes[0];
                foreach (var node in _nodes)
                {
                    foreach (var connection in node.GetChildConnections())
                    {
                        if (connection.GetLength() < shortestConnection.GetLength())
                        {
                            if (connectedNodes.Contains(connection.GetNode()) && connectedNodes.Contains(node)) continue;
                            shortestConnectionNode = node;
                            shortestConnection = connection;
                        }
                    }
                }

                length += shortestConnection.GetLength();
                if (!connectedNodes.Contains(shortestConnection.GetNode()))
                {
                    connectedNodes.Add(shortestConnection.GetNode());
                    minimalSpanningTree.AddNode(new GraphNode<T>((T)shortestConnection.GetNode().GetData()));
                }

                if (!connectedNodes.Contains(shortestConnectionNode))
                {
                    connectedNodes.Add(shortestConnectionNode);
                    minimalSpanningTree.AddNode(new GraphNode<T>((T)shortestConnectionNode.GetData()));
                }

                minimalSpanningTree.AddConnection(shortestConnectionNode, shortestConnection.GetNode(), shortestConnection.GetLength());
                minimalSpanningTree.AddConnection(shortestConnection.GetNode(), shortestConnectionNode, shortestConnection.GetLength());
            }

            foreach (var node in minimalSpanningTree._nodes)
            {
                Console.Write("{0}: ", (string)Convert.ChangeType(node.GetData(), typeof(string)));
                foreach (var child in node.GetChildren())
                {
                    Console.Write("{0}, {1}; ", (string)Convert.ChangeType(child.GetData(), typeof(string)), node.GetChildConnection(child).GetLength());
                }
                Console.WriteLine();
            }

            Console.WriteLine(length);

            return minimalSpanningTree;
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