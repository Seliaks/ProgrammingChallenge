using System;
using System.Threading;

namespace ProgramChallenge
{
    static class MainClass
    {
        static object _myDataType = new object();
        
        public static void Main(string[] args)
        {
            Vector test = new Vector((1 / Math.Pow(3, 0.5)), 1);
            Console.WriteLine(test.Angle());
            
            int choice = 0;
            do
            {
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
                }
            } while (choice != 9);
            Thread.Sleep(1000);

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

        static void Queue()
        {
            _myDataType = new Queue(5);
        }

        static void List()
        {
            _myDataType = new List();
        }

        static void Stack()
        {
            _myDataType = new Stack(5);
        }
    }
}
