using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GraphDS
    {
        public static void  Driver()
        {
            Graph graph = new Graph(7);
            graph.AddEdge(graph, 0, 1);
            graph.AddEdge(graph, 0, 4);
            graph.AddEdge(graph, 1, 4);
            graph.AddEdge(graph, 1, 2);
            graph.AddEdge(graph, 1, 3);
            graph.AddEdge(graph, 2, 3);
            graph.AddEdge(graph, 3, 4);

            graph.PrintGraph(graph);
        }
    }

    //A Graph is an array of Adjacency List
    //Size of array will be V (Number of vertices in Graph)
    public class Graph
    {
        int vertices;
        LinkedList<int>[] adjArrayList;

        public Graph(int _vertices)
        {
            vertices = _vertices;
            adjArrayList = new LinkedList<int>[vertices];

            for (int i = 0; i < vertices; i++)
                adjArrayList[i] = new LinkedList<int>();
        }

        //Undirected graph, so add froom source to dest and vice versa
        public void AddEdge(Graph graph, int source, int destinaion)
        {
            graph.adjArrayList[source].AddLast(destinaion);
            graph.adjArrayList[destinaion].AddFirst(source);
        }

        public void PrintGraph(Graph graph)
        {
            for (int v = 0; v < graph.vertices; v++)
            {
                Console.WriteLine();
                Console.WriteLine($"Adjacency list of vertex {v}");
                Console.Write("Head");
                foreach (var num in graph.adjArrayList[v])
                    Console.Write($"-->{num}");
                Console.WriteLine();
            }
        }
    }
}
