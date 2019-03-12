using System;
using System.Linq;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{ 
    public class Graph{
        private List<int>[] adjList;
        private int n;
        public Graph(int _n){
            //Ctor _n simpul tanpa sisi
            //Inisialisasi sebanyak n+1 anggota, elemen ke-0 tidak digunakan
            //adjList[v] berisi List simpul w yang tersambung dengan v
            n = _n;
            adjList = new List<int>[n+1];
            for (int i = 0; i <= n; i++){
                adjList[i] = new List<int>();
            }
        }
        public Graph(string filename){
            //Ctor dengan membaca file external
            string[] lines = System.IO.File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
            adjList = new List<int>[n+1];
            for (int i = 0; i <= n; i++){
                adjList[i] = new List<int>();
            }
            foreach (string line in lines.Skip(1).ToArray()){
                string[] vw = line.Split(' ');
                addEdge(int.Parse(vw[0]),int.Parse(vw[1]));
            }
            for (int i = 0; i <= n; i++){
                adjList[i].Sort();
            }
        }
        public void addEdge(int v, int w){
            //Prekondisi : v dan w ada pada graph
            adjList[v].Add(w);
            adjList[w].Add(v);
        }
        public void removeEdge(int v, int w){
            //Prekondisi : v dan w ada pada graph
            adjList[v].Remove(w);
            adjList[w].Remove(v);
        }
        public int getNodeCount(){
            return n;
        }
        public List<int> getAdjNodes(int v){
            //Prekondisi : v ada pada graph
            return adjList[v];
        }
    }
}