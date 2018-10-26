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
            GraphsWithAdjacentList graph = new GraphsWithAdjacentList(7);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);
            graph.AddEdge(4, 5);

            graph.PrintEdge();

            Console.WriteLine("Most Neighbors: " + graph.MostNeighbors());
            Traversals traverse = new Traversals();

            Console.WriteLine("Breadth First Search for vertice 2: ");

            traverse.BFS(graph.GivenGraph, 2);

            Console.WriteLine();

            Console.WriteLine("Depth First Search for vertice 2: ");

            traverse.DFS(graph.GivenGraph, 2);

            Console.WriteLine();

            DirectedACyclic dag = new DirectedACyclic();
            bool checkDag = dag.CheckIfCycleExists(graph.GivenGraph);

            Console.WriteLine(checkDag);



            GraphsWithAdjacentList TopologicalGraph = new GraphsWithAdjacentList(6);

            TopologicalGraph.AddEdge(5, 2);
            TopologicalGraph.AddEdge(5, 0);
            TopologicalGraph.AddEdge(4, 0);
            TopologicalGraph.AddEdge(4, 1);
            TopologicalGraph.AddEdge(2, 3);
            TopologicalGraph.AddEdge(3, 1);

            TopologicalSorting top = new TopologicalSorting();


            top.TopologicalSort(TopologicalGraph.GivenGraph);


            Console.ReadLine();
        }

    }
}
