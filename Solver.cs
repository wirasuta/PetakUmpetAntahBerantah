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
                    G.setDatang(top, time);
                }
                if (done[top]){
                    dfs.Pop();
                    time++;
                    G.setPergi(top, time);
                } else {
                    List<int> connectedVert = G.getAdjNodes(top);
                    foreach (int vert in connectedVert)
                        if (!visited[vert])
                            dfs.Push(vert);
                }
                done[top] = true;
            }
        }

        public static bool solve(Graph g, int i, int a, int b){
            if (i == 0){
                // Swap a, b
                a = a + b;
                b = a - b;
                a = a - b;
            }
            return ((g.getDatang(a) > g.getDatang(b)) && (g.getPergi(a) < g.getPergi(b)));
        }
    }
}