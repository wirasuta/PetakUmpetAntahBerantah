using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    public static class Solver {
        private static bool[] visited;
        private static int time;

        public static void setDatangPergi(Graph G){
            time = 0;
            int n = G.getNodeCount();
            visited = new bool[n+1];
            for (int i = 0; i <= n; i++)
                visited[i] = false;
            dfs(G, 1);
        }

        public static void dfs(Graph G, int current){
            if (!visited[current]){
                time++;
                G.setDatang(current, time);
                visited[current] = true;
                List<int> connectedVert = G.getAdjNodes(current);
                foreach (int vert in connectedVert)
                    dfs(G, vert);
                time++;
                G.setPergi(current, time);
            }
        }

        public static bool solve(Graph g, int i, int a, int b){
            if (i == 0){
                a = a + b;
                b = a - b;
                a = a - b;
            }
            return ((g.getDatang(a) > g.getDatang(b)) && (g.getPergi(a) < g.getPergi(b)));
        }
    }
}