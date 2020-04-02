using System;
using System.Threading;

namespace ProgramChallenge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                choice = Menu();
                switch (choice)
                {
                    case 1:
                        Queue myDataType = new Queue(5);
                        break;
                    
                    case 2:
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
    }
}
