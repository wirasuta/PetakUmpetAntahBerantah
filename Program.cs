using System;
using System.Collections.Generic;

namespace Stima{
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
            for (int i = 1; i <= G1.getNodeCount(); i++){
                List<int> adj = G1.getAdjNodes(i);
                Console.Write("{0} -> ",i);
                foreach (int item in adj){
                    Console.Write("{0} ",item);
                }
                Console.WriteLine();
            }
        }
    }
}
