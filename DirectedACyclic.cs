using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    //Depth First Traversal can be used to detect a cycle in a Graph. DFS for a connected graph produces a tree. 
    //There is a cycle in a graph only if there is a back edge present in the graph. A back edge is an edge that 
    //is from a node to itself (self-loop) or one of its ancestor in the tree produced by DFS
    // You need array to check if node has been visited and recursion stack to check the parent of the node.
    // 0 - >[1, 2] 
    // 1 - > 2
    // 2 - > [ 0,3]
    // 3 -> 3
    //For example: you start with 0: Find children of 0, so you visit 1 and then find children of 1 so you find 2
    // then find children of 2 which is 0 and 3 so you visit 0 and you check 0 is recursion stack which means it is 
    // parent of node 2 so there is a cycle.
    class DirectedACyclic : GraphsWithAdjacentList
    {

        public bool CheckIfCycleExists(List<int>[] adj)
        {
            List<int>[] adjutil = adj;
            bool[] visited = new bool[adj.Length - 1];
            bool[] recStack = new bool[adj.Length - 1];

            for (int i = 0; i < adj.Length - 1; i++)
                if (isCyclicUtil(adjutil,i, visited, recStack))
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

        private bool isCyclicUtil(List<int>[] adjutil,int i, bool[] visited,
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

            foreach(int c in children)

                if (isCyclicUtil(adjutil,c, visited, recStack))
                {
                    return true;
                }
                   

            recStack[i] = false;

            return false;
        }



    }
}
