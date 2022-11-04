using System;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver solver;
            int i = 0;
            Console.Write("Problem: ");
            //solver = new Solver(Console.ReadLine());
            string neshto = "syanislavs";
            Console.WriteLine(neshto.Substring(1, 8));
            solver = new Solver("(25/5+10*3-5)*((15+27)*(19-6)+15*(16-9))");
            solver.Otvarqshta();
            //while (i == 0)
            //{
            //    if (Console.ReadLine() == "q" || Console.ReadLine() == "exit")
            //    {
            //        i = 1;
            //    }
            //    else if (Console.ReadLine() == "s" || Console.ReadLine() == "solve")
            //    {
            //        Console.Write("Problem: ");
            //        solver = new Solver(Console.ReadLine());
            //    }
            //}
            Environment.Exit(0);
        }
        
    }
}
