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

        public Graph(int _n){
            //Ctor _n simpul tanpa sisi
            //Inisialisasi sebanyak n+1 anggota, elemen ke-0 tidak digunakan
            //adjList[v] berisi List simpul w yang tersambung dengan v
            n = _n;
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
                nodes[i].setX(10);
                nodes[i].setY(10);
            }
        }
        public Graph(string filename){
            //Ctor dengan membaca file external
            string[] lines = System.IO.File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
            nodes = new Node[n+1];
            for (int i = 0; i <= n; i++){
                nodes[i] = new Node();
                nodes[i].setX(10);
                nodes[i].setY(10);
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
        public void print(){
            for (int i = 1; i <= getNodeCount(); i++){
                List<int> adj = getNode(i).getNeighbours();
                Console.Write("{0} X: {1} Y: {2} -> ",i,getNode(i).getX(),getNode(i).getY());
                foreach (int item in adj){
                    Console.Write("{0} ",item);
                }
                Console.WriteLine();
            }
        }
    }
}