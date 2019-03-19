using System.Collections.Generic;
using System.Linq;

namespace PetakUmpetAntahBerantah{
    public static class Solver {
        /*
            Kelas static solver yang memiliki method:
            - setDatangPergiY : menetapkan nilai kedatangan, kepergian, dan posisi y untuk setiap node
            - setAllX : menetapkan posisi X untuk setiap node
            - solve : menyelesaikan satu query
            - solveFile : menyelesaikan semua query dari file dengan memanggil method solve
        */
        public static void setDatangPergiY(Graph G){
            //Nilai jarak y antar node
            const int offsety = 10;
            //Inisialisasi variabel lokal
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
            //Penelusuran graf secara DFS untuk menentukan posisi Y, waktu kedatangan (pertama kali proses node tersebut)
            //dan kepergian (ketika node tersebut dan seluruh anaknya selesai diproses).
            //Implementasi DFS dengan menggunakan stack untuk 
            //menghindari error stack overflow karena rekursi dalam
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
            //Nilai jarak x antar node
            const int offsetx = 10;
            //Inisialisasi variabel lokal
            Queue<int> nodes = new Queue<int>();
            int x = 0;
            int level = 0;
            int n = G.getNodeCount();
            bool[] visited = new bool[n+1];
            for (int i = 0; i <= n; i++)
                visited[i] = false;
            //Penelusuran graf untuk penentuan posisi X
            //Untuk node yang terhubung dengan istana
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
            //Untuk node yang tidak terhubung dengan istana
            x = 10;
            for (int i=0; i<=n; i++){
                if (!visited[i]){
                    x+= offsetx;
                    G.getNode(i).setX(x);
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
            // Penentuan apakah terdapat jalan menuju posisi Jose dari posisi Ferdiant
            // Jika nilai i = 0 (mendekati istana), maka permasalahan disederhanakan menjadi "Apakah node b merupakan anak dari node a"
            // Node b merupakan anak dari node a jika waktu datang b setelah waktu datang a,
            // dan waktu pergi a setelah waktu pergi b
            if ((g.getNode(a).getDatang() < g.getNode(b).getDatang()) && (g.getNode(a).getPergi() > g.getNode(b).getPergi())){
                // Penentuan jalan menuju posisi Jose dilakukan dengan mengikuti waktu datang secara menurun
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

        public static List<int>[] solveFile(Graph G, string filename){
            string[] lines = System.IO.File.ReadAllLines(filename);
            int n = int.Parse(lines[0]);
            List<int>[] ret = new List<int>[n];
            int i;
            for (i = 0; i < n; i++){
                ret[i] = new List<int>();
            }
            i = 0;
            // Pemanggilan solve untuk setiap baris query
            foreach (string line in lines.Skip(1).ToArray()){
                string[] iab = line.Split(' ');
                ret[i++] = solve(G, int.Parse(iab[0]),int.Parse(iab[1]),int.Parse(iab[2]));
            }
            return ret;
        }
    }
}