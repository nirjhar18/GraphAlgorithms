using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    class Traversals : GraphsWithAdjacentList
    {

        //Breadth First Search of a vertice
        // We have an array to check if the vertice/node has already been visisted. I am using a queue to keep
        // vertices. We start with input vertice and add it to queue and change the flag to visited.
        // Then we dequeue and print that vertice and loop through the list of that vertice to find its adjacent
        // nodes/neighbors. We add it to queue and then dequeue the first element and print it 
        // and then we loop through to find the adjacent members of the de-queued vertice.
        //https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/

        public override void BFS(int vertice)
        {
            bool[] visited = new bool[5];
            Queue<int> vertices = new Queue<int>();
            vertices.Enqueue(vertice);
            visited[vertice] = true;


            while (vertices.Count != 0)
            {

                vertice = vertices.Dequeue();
                Console.Write(vertice + " ");
                foreach (var i in adj[vertice])
                {
                    if (visited[i] == false)
                    {
                        visited[i] = true;
                        vertices.Enqueue(i);
                    }
                }
            }

        }

    }
}
