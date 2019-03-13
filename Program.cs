using System;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    class Program{
        static void Main(string[] args)
        {
            if (args.Length == 0){
                Console.WriteLine("Usage : dotnet run <filename>");
                System.Environment.Exit(-1);
            }else{
                Console.WriteLine("Input File : {0}",args[0]);
            }
            Graph G1 = new Graph(args[0]);
            Solver.setDatangPergi(G1);
            G1.print();
            Console.WriteLine("1 6 5 : {0}",Solver.solve(G1, 1, 6, 5));
            Console.WriteLine("0 6 5 : {0}",Solver.solve(G1, 0, 6, 5));
            Console.WriteLine("1 9 1 : {0}",Solver.solve(G1, 1, 9, 1));
        }
    }
}
