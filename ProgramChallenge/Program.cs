using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProgramChallenge
{
    static class MainClass
    {
        public static void Main(string[] args)
        {  
            Thread.Sleep(2000);
            int choice = 0;
            do
            {
                Console.Clear();
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        Queue();
                        break;
                    
                    case 2:
                        List();
                        break;
                    
                    case 3:
                        Stack();
                        break;
                    
                    case 4:
                        HashTable();
                        break;
                    
                    case 5:
                        Dictionary();
                        break;
                    
                    case 6:
                        Graph<string>();
                        break;

                    case 7:
                        Console.Clear();
                        int typeChoice = TreeTypeMenu();
                        switch (typeChoice)
                        {
                            case 2:
                                Tree<int>();
                                break;
                            
                            case 3:
                                Tree<char>();
                                break;
                            
                            default:
                                Tree<string>();
                                break;
                        }
                        break;
                    
                    case 8:
                        Vector();
                        break;
                }
            } while (choice != 9);
            //Thread.Sleep(1000);

        }

        private static int Menu()
        {
            Console.Write(@"1: Queue
2: List
3: Stack
4: Hash Table
5: Dictionary
6: Graphs
7: Trees
8: Vectors
9: Quit
Enter choice: ");
            return int.Parse(Console.ReadLine());
        }

        private static void Queue()
        {
            Queue myQueue = new Queue(5);
        }

        private static void List()
        {
            List myList = new List();
        }

        private static void Stack()
        {
            Stack myStack = new Stack(5);
        }

        private static void HashTable()
        {
            HashTable myHashTable = new HashTable();
        }

        private static void Dictionary()
        {
            Dictionary myDictionary = new Dictionary();
        }

        private static void Graph<T>()
        {
            Graph<T> myGraph = new Graph<T>();
        }

        private static void Tree<T>()
        {
            Tree<T> myTree = new Tree<T>();
            int choice;
            do
            {
                Console.Clear();
                choice = TreeMenu();
                switch (choice)
                {
                    case 1:
                        Console.Write("Value: ");
                        myTree.AddNode((T) Convert.ChangeType(Console.ReadLine(), typeof(T)));
                        break;

                    case 2:
                        foreach (var data in myTree.SortedTree())
                        {
                            Console.WriteLine(data);
                        }

                        Console.ReadKey(true);
                        break;
                    
                    case 3:
                        break;
                    
                    default:
                        Console.WriteLine("Not a valid choice");
                        Thread.Sleep(500);
                        break;

                }
            } while (choice != 3);

            Console.ReadKey(true);
        }

        private static void Vector()
        {
            Vector myVector = new Vector(1, Math.Pow(3, -0.5));
            Console.WriteLine(myVector.Angle());
            Console.ReadKey(true);
        }

        private static int TreeMenu()
        {
            Console.Write(@"1: Add a value
2: Output all values
3: Quit
Choice: ");
            return int.Parse(Console.ReadLine());
        }

        private static int TreeTypeMenu()
        {
            Console.Write(@"1: String
2: Int
3: Char
Choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
