using System;
using System.Linq;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{ 
    public class Graph{
        /* 
            Kelas Graph terdiri dari atribut:
                - nodes : array yang berisi objek dari kelas Node, 
                          elemen ke-i melambangkan node ke-i
                - n : jumlah node
        */
        private Node[] nodes;
        private int n;

        public class Node{
            /*
                Kelas Node terdiri dari atribut:
                - neighbour : list of integer yang berisi nomor-nomor node yang terhubung
                - datang & pergi : waktu kedatangan dan kepergian dari node untuk penentuan
                                   apakah ferdiant dapat menemukan jose dan langkahnya jika
                                   dapat menemukan
                - x & y : posisi untuk penggambaran node pada GUI
            */
            private List<int> neighbour;
            private int datang;
            private int pergi;
            private int x;
            private int y;

            //Constructor
            public Node(){
                neighbour = new List<int>();
                datang = 0;
                pergi = 0;
                x = 10;
                y = 10;
            }
            //Menambah tetangga dengan cara menambahkan nomor nodenya pada list neighbour
            public void addNeighbour(int w){
                neighbour.Add(w);
            }
            //Getter dan setter
            public void setX(int _x){
                x = _x;
            }
            public void setY(int _y){
                y = _y;
            }
            public int getX(){
                return x;
            }
            public int getY(){
                return y;
            }
            public void setDatang(int t){
                datang = t;
            }
            public void setPergi(int t){
                pergi = t;
            }
            public int getDatang(){
                return datang;
            }
            public int getPergi(){
                return pergi;
            }
            public List<int> getNeighbours(){
                return neighbour;
            }
        }

        //Constructor
        public Graph(int _n){
            //Inisialisasi sebanyak n+1 anggota, elemen ke-0 tidak digunakan
            //nodes[v] berisi objek Node ke-v
            n = _n;
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
            }
        }
        public Graph(string filename){
            //Constructor dengan membaca file external
            string[] lines = System.IO.File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
            }
            //Menambahkan sisi
            foreach (string line in lines.Skip(1).ToArray()){
                string[] vw = line.Split(' ');
                addEdge(int.Parse(vw[0]),int.Parse(vw[1]));
            }
        }
        //Method untuk menambahkan sisi dengan saling menambahkan tetangga pada v dan w
        //Prekondisi : v dan w ada pada graph dan sisi (v,w) belum ada pada graph
        public void addEdge(int v, int w){
            nodes[v].addNeighbour(w);
            nodes[w].addNeighbour(v);
        }
        //Getter dan setter
        public int getNodeCount(){
            return n;
        }
        public Node getNode(int v){
            return nodes[v];
        }
        public int getNodeIdByDatang(int t)
        {
            for (int i = 1; i<=n; i++)
            {
                if (nodes[i].getDatang() == t)
                {
                    return i;
                }
            }
            return 0;
        }
        public int getNodeIdByPergi(int t)
        {
            for (int i = 1; i <= n; i++)
            {
                if (nodes[i].getPergi() == t)
                {
                    return i;
                }
            }
            return 0;
        }
        //Mencetak graph
        public void print(){
            for (int i = 1; i <= getNodeCount(); i++){
                List<int> adj = getNode(i).getNeighbours();
                Console.Write("{0} (X {1}, Y {2}) -> ",i,getNode(i).getX(),getNode(i).getY());
                foreach (int item in adj){
                    Console.Write("{0} ",item);
                }
                Console.WriteLine();
            }
        }
    }
}