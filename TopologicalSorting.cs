using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms
{
    class TopologicalSorting : DirectedACyclic
    {

        /* Topological sorting for Directed Acyclic Graph (DAG) is a linear ordering of vertices such that
         * for every directed edge uv, vertex u comes before v in the ordering. Topological Sorting for
         * a graph is not possible if the graph is not a DAG. In topological sorting, 
         * we need to print a vertex before its adjacent vertices.
         * In DFS, we print a vertex and then recursively call DFS for its adjacent vertices. In topological sorting,
         * we use a temporary stack. We don’t print the vertex immediately, we first recursively call topological
         * sorting for all its adjacent vertices, then push it to a stack. Finally, print contents of stack. 
         * Note that a vertex is pushed to stack only when all of its adjacent vertices (and their adjacent
         * vertices and so on) are already in stack.
         * We will be using a list and a stack. List will contain all the vertices that have been visited.
         * Stack will contain all the vertices that have been explored, which means all their children have also
         * been explored.
         * For example: Graph is 
         *                            5               4
         *                        /      \          /   \
         *                        >       >      <       >
         *                        2           0           1
         *                                               ^
         *                          \                  /  
         *                            >               /
         *                                    3
         *  First we check if there is a cycle as topological sort only works for acyclic graph.
         *  Then we start with 0 and and call utility function. First it checks if vertice 0 has been visited. If not
         *  we add to visited list and then explore node 0 to find their children. In this case, 0 does not have any  
         *  children, so we add it to stack. Then same for 1 and then for 2, it has 3 as children so first we will 
         *  go to 2 and then find 3 and then find children of 3. As 3 does not have any children, 3 will be added to
         *  stack. Then 2 will be added to stack as 2 does not have any more children.Similar stpes for 3, 4, 5                                                     
         *                                    
         */

        public void TopologicalSort(List<int>[] adj)
        {

           if (CheckIfCycleExists(adj) == false)
            {
                List<int> visited = new List<int>();
                Stack<int> recStack = new Stack<int>();
                for (int i = 0; i < adj.Length; i++)

                {
                    if (!visited.Contains(i))
                    {
                        TopologicalSortUtil(adj, i, visited, recStack);
                    }

                }


                //Print Stack
                foreach(var k in recStack)
                {
                    Console.Write(k + " ");
                }

            }

        }

        public void TopologicalSortUtil(List<int>[] adj, int vertice,List<int> visited,Stack<int> recStack)
        {
            //Add the vertice to list to mark this visited.
            visited.Add(vertice);

            if (!recStack.Contains(vertice))
            {

                //Explore the vertice. Find their children
                foreach (var j in adj[vertice])
                {
                    if (!visited.Contains(j))
                    {
                        // if the vertice has not been visted, recursively call utility method.
                        TopologicalSortUtil(adj, j, visited, recStack);
                    }
                }

                //Once the vertice has been explored, push it to the stack
                recStack.Push(vertice);

            }

        }

    }
}
