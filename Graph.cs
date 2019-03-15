using System;
using System.Linq;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{ 
    public class Graph{
        private Node[] nodes;
        private int n;
        public class Node{
            private List<int> neighbour;
            private int datang;
            private int pergi;
            private int x;
            private int y;
            public Node(){
                neighbour = new List<int>();
                datang = 0;
                pergi = 0;
                x = 0;
                y = 0;
            }
            public void addNeighbour(int w){
                neighbour.Add(w);
            }
            public void setX(int _x){
                x = _x;
            }
            public void setY(int _y){
                y = _y;
            }
            public int getX(int _x){
                return x;
            }
            public int getY(int _y){
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

        public Graph(int _n){
            //Ctor _n simpul tanpa sisi
            //Inisialisasi sebanyak n+1 anggota, elemen ke-0 tidak digunakan
            //adjList[v] berisi List simpul w yang tersambung dengan v
            n = _n;
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
            }
        }
        public Graph(string filename){
            //Ctor dengan membaca file external
            string[] lines = System.IO.File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
            }
            foreach (string line in lines.Skip(1).ToArray()){
                string[] vw = line.Split(' ');
                addEdge(int.Parse(vw[0]),int.Parse(vw[1]));
            }
        }
        public void addEdge(int v, int w){
            //Prekondisi : v dan w ada pada graph
            nodes[v].addNeighbour(w);
            nodes[w].addNeighbour(v);
        }
        //getter setter
        //Prekondisi : v ada pada graph
        public void setDatang(int v, int t){
            nodes[v].setDatang(t);
        }
        public void setPergi(int v, int t){
            nodes[v].setPergi(t);
        }
        public int getDatang(int v){
            return nodes[v].getDatang();
        }
        public int getPergi(int v){
            return nodes[v].getPergi();
        }
        public int getNodeCount(){
            return n;
        }
        public List<int> getAdjNodes(int v){
            return nodes[v].getNeighbours();
        }

        public Node getNode(int v){
            return nodes[v];
        }
        public void print(){
            for (int i = 1; i <= getNodeCount(); i++){
                List<int> adj = getAdjNodes(i);
                Console.Write("{0} Datang: {1} Pergi: {2} -> ",i,getDatang(i),getPergi(i));
                foreach (int item in adj){
                    Console.Write("{0} ",item);
                }
                Console.WriteLine();
            }
        }
    }
}