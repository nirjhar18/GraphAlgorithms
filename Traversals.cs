using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    class Traversals : GraphsWithAdjacentList
    {

        /*Breadth First Search of a vertice
        // We have an array to check if the vertice/node has already been visisted. I am using a queue to keep
        // vertices. We start with input vertice and add it to queue and change the flag to visited.
        // Then we dequeue and print that vertice and loop through the list of that vertice to find its adjacent
        // nodes/neighbors. We add it to queue and then dequeue the first element and print it 
        // and then we loop through to find the adjacent members of the de-queued vertice.
        //https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/
        *Example: List of arrays 0,1,2,3 on left hand side is index of array and in 0th index list contains
        * 1 and 2. In index 1, list has 2. In index 2, list has 0 and 3.
        * 0 - >[1, 2] 
        * 1 - > 2
        * 2 - > [ 0,3 ]
        * 3 -> 3
        * In Breadth first search, we start with vertice we want to and go through the list of that vertice
        * Then it will find the list of vertices of first node visited by previous index
        * For example: If we start with 2 in above example, first it will print 2 then list in index 2 which will be 
        * 0 and 3. Then it will go to 0 and then print the list of 0. As 2 is already visited, it will only print 1.
        * Then it will check list of 3 which only has 3 which is already printed so BFS of 2 will be
        * 2,0,3,1
        */

        public override void BFS(List<int>[] adj, int vertice)
        {
            bool[] visited = new bool[5];
            Queue<int> vertices = new Queue<int>();
            vertices.Enqueue(vertice);
            visited[vertice] = true;

            //While Queue is not empty, keep going
            while (vertices.Count != 0)
            {

                vertice = vertices.Dequeue();
                Console.Write(vertice + " ");
                foreach (var i in adj[vertice])
                {
                    //If the vertice has not been visited
                    if (visited[i] == false)
                    {
                        //Visit the node and add it to the queue
                        visited[i] = true;
                        vertices.Enqueue(i);
                    }
                }
            }

        }


        /* Example: List of arrays 0,1,2,3 on left hand side is index of array and in 0th index list contains
        * 1 and 2. In index 1, list has 2. In index 2, list has 0 and 3.
        * 0 - >[1, 2] 
        * 1 - > 2
        * 2 - > [ 0,3]
        * 3 -> 3
        * In Dept first search, we start with vertice we want to and go through the list of that vertice
        * Then it will find the list of vertices of first node visited by previous index
        * For example: If we start with 2 in above example, first it will print 2 then list in index 2 which will be 
        * 0. Then it will go to 0 and then print the list of 0. As 2 is already visited, it will only print 1.
        * Then it will check list of 3 which only has 3 which is already printed so BFS of 2 will be
        * 2,3,0,1  O(V +E) V= vertices, E= Edges
        * 
        */

        public override void DFS(List<int>[] adj, int vertice)
        {
            bool[] visited = new bool[adj.Length - 1];
            Stack<int> vertices = new Stack<int>();
            //Make sure you check each vertex even if all vertices are not connected to each other

            for (int j = 0; j < visited.Length; j++)
            {
                // Only visit the vertex if you have not visited it.
                if (visited[j] == false)
                {
                    if (visited[vertice] == true) { vertice = j; }
                    
                    vertices.Push(vertice);

                    visited[vertice] = true;
                    while (vertices.Count != 0)
                    {
                        vertice = vertices.Pop();
                        Console.Write(vertice + " ");

                        foreach (var i in adj[vertice])
                        {
                            if (visited[i] == false)
                            {
                                visited[i] = true;
                                vertices.Push(i);


                            }
                        }

                    }

                }
            }

        }

        public void DFS(List<int>[] adj, int vertice, bool[] visited)
        {
            // Mark the current node as visited and print it 
            visited[vertice] = true;
            Console.WriteLine(vertice + " ");

            // Recur for all the vertices adjacent to this vertex 
           
            foreach (var k in adj[vertice])
            {
                int n = k;
                if (!visited[n])
                    DFS(adj, n, visited);
            }

        }

        public void RecursiveDFS(List<int>[] adj, int v)
        {
            // Mark all the vertices as not visited
            bool[] visited = new bool[5];

            // Call the recursive helper function to print DFS traversal 
            DFS(adj, v, visited);
        }


    }
}
