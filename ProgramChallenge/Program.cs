using System;

namespace ProgramChallenge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Menu();
        }

        public static int Menu()
        {
            Console.Write(@"1: Queue
2: List
3: Stack
4: Hash Table
5: Dictionary2983woIE
6: Graphs
7: Trees
8: Vectors
9: Quit
Enter choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
