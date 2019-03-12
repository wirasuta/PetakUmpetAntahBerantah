using System;
using System.Linq;
using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{ 
    public class Graph{
        private List<int>[] adjList;
        private int[] datang;
        private int[] pergi;
        private int n;
        public Graph(int _n){
            //Ctor _n simpul tanpa sisi
            //Inisialisasi sebanyak n+1 anggota, elemen ke-0 tidak digunakan
            //adjList[v] berisi List simpul w yang tersambung dengan v
            n = _n;
            datang = new int[n+1];
            pergi = new int[n+1];
            adjList = new List<int>[n+1];
            for (int i = 0; i <= n; i++){
                adjList[i] = new List<int>();
                pergi[i] = 0;
                datang[i] = 0;
            }
        }
        public Graph(string filename){
            //Ctor dengan membaca file external
            string[] lines = System.IO.File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
            datang = new int[n+1];
            pergi = new int[n+1];
            adjList = new List<int>[n+1];
            for (int i = 0; i <= n; i++){
                adjList[i] = new List<int>();
                pergi[i] = 0;
                datang[i] = 0;
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
        //getter setter
        //Prekondisi : v ada pada graph
        public void setDatang(int v, int t){
            datang[v] = t;
        }
        public void setPergi(int v, int t){
            pergi[v] = t;
        }
        public int getDatang(int v){
            return datang[v];
        }
        public int getPergi(int v){
            return pergi[v];
        }
        public int getNodeCount(){
            return n;
        }
        public List<int> getAdjNodes(int v){
            return adjList[v];
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