using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    public static class Solver {
        public static void setDatangPergi(Graph G){
            Stack<int> dfs = new Stack<int>();
            int time = 0;
            int n = G.getNodeCount();
            bool[] visited = new bool[n+1];
            bool[] done = new bool[n+1];
            for (int i = 0; i <= n; i++){
                visited[i] = false;
                done[i] = false;
            }
            dfs.Push(1);
            while (!(dfs.Count == 0)){
                int top = dfs.Peek();
                if (!visited[top]){
                    visited[top] = true;
                    time++;
                    G.getNode(top).setDatang(time);
                }
                if (done[top]){
                    dfs.Pop();
                    time++;
                    G.getNode(top).setPergi(time);
                } else {
                    List<int> connectedVert = G.getNode(top).getNeighbours();
                    foreach (int vert in connectedVert)
                        if (!visited[vert])
                            dfs.Push(vert);
                }
                done[top] = true;
            }
        }

        public static List<int> solve(Graph g, int i, int a, int b){
            // 1. 0 X Y : Ferdiant mulai bergerak dari Y menuju istana raja (berhenti ketika sampai di istana raja) dan
            //            Jose bersembunyi di alamat X
            // 2. 1 X Y : Ferdiant mulai bergerak dari Y menjauhi istana raja dan Jose bersembunyi di alamat X
            if (i == 0){
                // Swap a, b
                a = a + b;
                b = a - b;
                a = a - b;
            }
            List<int> path = new List<int>();
            if ((g.getNode(a).getDatang() > g.getNode(b).getDatang()) && (g.getNode(a).getPergi() < g.getNode(b).getPergi())){
                int posFerdiant = b;
                int timeFerdiant = g.getNode(posFerdiant).getDatang();
                int timeJose = g.getNode(a).getDatang();
                while (timeFerdiant != timeJose){
                    path.Add(posFerdiant);
                    List<int> connectedVert = g.getNode(posFerdiant).getNeighbours();
                    foreach (int vert in connectedVert){
                        if ((i == 0 && g.getNode(vert).getDatang()<timeFerdiant) || (i == 1 && g.getNode(vert).getDatang()>timeFerdiant)){
                            posFerdiant = vert;
                            timeFerdiant = g.getNode(posFerdiant).getDatang();
                            break;
                        }
                    }
                }
                path.Add(a);
            }
            return path;
        }
    }
}