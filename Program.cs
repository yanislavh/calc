using System;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver solver;
            int i = 0;
            while(i == 0)
            {
                if (Console.ReadLine() == "q" || Console.ReadLine() == "exit")
                {
                    i = 1;
                }
                else if (Console.ReadLine() == "s" || Console.ReadLine() == "solve")
                {
                    Console.Write("Problem: ");
                    solver = new Solver(Console.ReadLine());
                }
            }
            Environment.Exit(0);
        }
        
    }
}
