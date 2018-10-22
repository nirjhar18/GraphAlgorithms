using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddEdge(adjlist, 0, 1);
            //AddEdge(adjlist, 0, 4);
            //AddEdge(adjlist, 1, 0);
            //AddEdge(adjlist,1, 3);
            //AddEdge(adjlist,1, 4);
            //AddEdge(adjlist,1, 2);
            //AddEdge(adjlist,2, 1);
            //AddEdge(adjlist,2, 3);
            //AddEdge(adjlist,3, 1);
            //AddEdge(adjlist,3, 2);
            //AddEdge(adjlist,3, 4);
            //AddEdge(adjlist, 4, 3);
            //AddEdge(adjlist, 4, 0);
            //AddEdge(adjlist, 4, 1);
            GraphsWithAdjacentList graph = new GraphsWithAdjacentList(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            graph.PrintEdge();

            Console.WriteLine("Most Neighbors: " + graph.MostNeighbors());
            graph.BFS(2);
            Console.ReadLine();
        }
    }
}
