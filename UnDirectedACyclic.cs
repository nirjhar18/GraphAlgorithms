using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    /*Like directed graphs, we can use DFS to detect cycle in an undirected graph in O(V+E) time.
     * We do a DFS traversal of the given graph. For every visited vertex ‘v’, if there is an adjacent ‘u’ 
     * such that u is already visited and u is not parent of v, then there is a cycle in graph. If we don’t
     * find such an adjacent for any vertex, we say that there is no cycle. The assumption of this approach 
     * is that there are no parallel edges between any two vertices.
     * 
     * 
     * Example:
     * 
     *    1----0----------3
     *    |    /          |
     *    |   /           |
     *     2              4
     * 
     * 
     
         
         
         
   */
    class UnDirectedACyclic : GraphsWithAdjacentList
    {
        public bool CheckIfCycleExists(List<int>[] adj)
        {
            List<int>[] adjutil = adj;
            bool[] visited = new bool[adj.Length - 1];
            bool[] recStack = new bool[adj.Length - 1];

            for (int i = 0; i < adj.Length - 1; i++)
                if (isCyclicUtil(adjutil, i, visited, recStack))
                {
                    Console.Write("Cycle in graph:");
                    for (int k = 0; recStack[k] != false; k++)
                    {
                        Console.Write(k + " ");
                    }
                    return true;
                }


            return false;

        }

        private bool isCyclicUtil(List<int>[] adjutil, int i, bool[] visited,
                                      bool[] recStack)
        {

            // Mark the current node as visited and 
            // part of recursion stack 
            if (recStack[i])
            {
                return true;
            }


            if (visited[i])
            {
                return false;
            }


            visited[i] = true;

            recStack[i] = true;
            List<int> children = adjutil[i];

            foreach (int c in children)

                if (isCyclicUtil(adjutil, c, visited, recStack))
                {
                    return true;
                }


            recStack[i] = false;

            return false;
        }



    }

}
}
