using System;
using System.Threading;

namespace ProgramChallenge
{
    static class MainClass
    {
        public static void Main(string[] args)
        {
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
                        break;
                    
                    case 7:
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
                        //Tree<string>();
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

        private static void Tree<T>()
        {
            Tree<T> myTree = new Tree<T>();
            int choice;
            do
            {
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

                        break;

                }
            } while (choice != 3);

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
