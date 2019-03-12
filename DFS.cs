using System.Collections.Generic;

namespace PetakUmpetAntahBerantah{
    public static class DFS{
        public static bool Search(Graph G, int prev, int current, int target){
            List<int> connectedVert = G.getAdjNodes(current);
            bool found = false;
            connectedVert.Remove(prev);
            foreach (int vert in connectedVert){
                if (vert == target){
                    found = true;
                    break;
                }else{
                    found = Search(G,current,vert,target);
                    if (found){
                        break;
                    }
                }
            }
            return found;
        }
    }
}