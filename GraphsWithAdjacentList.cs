﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    public class GraphsWithAdjacentList
    {

        public int V; // Number of vertices
        public List<int>[] adj; //Array of Lists

        public GraphsWithAdjacentList() { }

        //Constructor for new adjacent list
        public GraphsWithAdjacentList(int vertices)
        {
            V = vertices;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();

            }
        }

        public List<int>[] GivenGraph
        {
            get { return adj; }
        
        }


        //Use an array of Lists
        // 0 - > List ()
        // 0 -> [1, 2]
        // 1 - > 2
        public void AddEdge(int a, int b)
        {
            adj[a].Add(b);
        }

        //Print Edges 
        public void PrintEdge()
        {
            for (int i = 0; i < adj.Length; i++)

            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + (k + ",");
                }
                if (s.Length > 0) { s = s.Substring(0, s.Length - 1); }
                

                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }

        }

        //Find the index of most adjacent neighbors
        public int MostNeighbors()
        {

            int[] finalCount = new int[adj.Length];
            for (int i = 0; i < adj.Length; i++)

            {
                finalCount[i] = adj[i].Count;

            }

            return Array.IndexOf(finalCount, finalCount.Max());

        }

        //Breadth First Search of a vertice
        // We have an array to check if the vertice/node has already been visisted. I am using a queue to keep
        // vertices. We start with input vertice and add it to queue and change the flag to visited.
        // Then we dequeue and print that vertice and loop through the list of that vertice to find its adjacent
        // nodes/neighbors. We add it to queue and then dequeue the first element and print it 
        // and then we loop through to find the adjacent members of the de-queued vertice.

        public virtual void BFS(List<int>[] adj,int vertice) { }


        public virtual void DFS(List<int>[] adj,int vertice) { }

    }
}