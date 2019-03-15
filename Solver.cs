using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    public static class Solver {
        public static void setDatangPergiY(Graph G){
            const int offsety = 10;

            Stack<int> dfs = new Stack<int>();
            int time = 0;
            int level = 0;
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
                Graph.Node node = G.getNode(top);
                if (!visited[top]){
                    visited[top] = true;
                    time++;
                    level++;
                    node.setY(level*offsety);
                    node.setDatang(time);
                }
                if (done[top]){
                    dfs.Pop();
                    time++;
                    level--;
                    node.setPergi(time);
                } else {
                    List<int> connectedVert = node.getNeighbours();
                    foreach (int vert in connectedVert)
                        if (!visited[vert])
                            dfs.Push(vert);
                }
                done[top] = true;
            }
        }

        public static void setAllX(Graph G){
            const int offsetx = 10;

            Queue<int> nodes = new Queue<int>();
            int x = 0;
            int level = 0;
            int n = G.getNodeCount();
            bool[] visited = new bool[n+1];
            for (int i = 0; i <= n; i++)
                visited[i] = false;
            nodes.Enqueue(1);
            while(!(nodes.Count == 0)){
                int top = nodes.Dequeue();
                Graph.Node node = G.getNode(top);
                if (level != node.getY()){
                    level = node.getY();
                    x = 0;
                }
                x += offsetx;
                visited[top] = true;
                node.setX(x);
                List<int> connectedVert = node.getNeighbours();
                foreach (int vert in connectedVert){
                    if(!visited[vert])
                        nodes.Enqueue(vert);
                }
            }
        }

        public static List<int> solve(Graph g, int i, int a, int b){
            // 1. 0 X Y : Ferdiant mulai bergerak dari Y menuju istana raja (berhenti ketika sampai di istana raja) dan
            //            Jose bersembunyi di alamat X
            // 2. 1 X Y : Ferdiant mulai bergerak dari Y menjauhi istana raja dan Jose bersembunyi di alamat X
            if (i == 1){
                // Swap a, b
                a = a + b;
                b = a - b;
                a = a - b;
            }
            int posFerdiant = b;
            int timeFerdiant = g.getNode(posFerdiant).getDatang();
            int timeJose = g.getNode(a).getDatang();
            List<int> path = new List<int>();
            if ((g.getNode(a).getDatang() < g.getNode(b).getDatang()) && (g.getNode(a).getPergi() > g.getNode(b).getPergi())){
                while (timeFerdiant != timeJose){
                    path.Add(posFerdiant);
                    List<int> connectedVert = g.getNode(posFerdiant).getNeighbours();
                    foreach (int vert in connectedVert){
                        if (g.getNode(vert).getDatang()<timeFerdiant){
                            posFerdiant = vert;
                            timeFerdiant = g.getNode(posFerdiant).getDatang();
                            break;
                        }
                    }
                }
                path.Add(a);
            }
            if (i == 1)
                path.Reverse();
            return path;
        }
    }
}