using System;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    class Program{
        public static void printPath(List<int> path){
            if (path.Count > 0){
                path.ForEach(v => {
                    Console.Write("{0} ",v);
                });
                Console.WriteLine();
            }else{
                Console.WriteLine("No Path Found");
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 0){
                Console.WriteLine("Usage : dotnet run <filename>");
                System.Environment.Exit(-1);
            }else{
                Console.WriteLine("Input File : {0}",args[0]);
            }
            Graph G1 = new Graph(args[0]);
            Solver.setDatangPergiY(G1);
            Solver.setAllX(G1);

            G1.print();
            List<int> path = new List<int>();
            Console.WriteLine("1 6 1 : ");
            path = Solver.solve(G1, 1, 6, 1);
            printPath(path);
            Console.WriteLine("1 4 1 : ");
            path = Solver.solve(G1, 1, 4, 1);
            printPath(path);
        }
    }
}
