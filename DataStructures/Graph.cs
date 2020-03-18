using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class GraphDS
    {
        public static void  Driver()
        {
            //New Graph

            List<GraphEdge> graphEdges = new List<GraphEdge>()
            {
                new GraphEdge(0, 1, 6),
                new GraphEdge(1, 2, 7),
                new GraphEdge(2, 0, 5),
                new GraphEdge(2, 1, 4),
                new GraphEdge(3, 2, 10),
                new GraphEdge(4, 5, 1)
            };

            var graph = new GraphDataStructure(graphEdges);

            graph.AddEdge(new GraphEdge(5, 4, 3));
            graph.PrintGraph();        

            /*
            Graph graph = new Graph(7);
            graph.AddEdge(graph, 0, 1);
            graph.AddEdge(graph, 0, 4);
            graph.AddEdge(graph, 1, 4);
            graph.AddEdge(graph, 1, 2);
            graph.AddEdge(graph, 1, 3);
            graph.AddEdge(graph, 2, 3);
            graph.AddEdge(graph, 3, 4);

            graph.PrintGraph(graph);
            */
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

    public class GraphDataStructure
    {
        private List<List<GraphNode>> AdjacenceyList = new List<List<GraphNode>>();

        public GraphDataStructure(List<GraphEdge> graphEdges)
        {
            for (int i = 0; i < graphEdges.Count; i++)
                AdjacenceyList[i] = new List<GraphNode>();

            //Initialize all the vertices in Graph
            foreach (var edge in graphEdges)
            {
                AdjacenceyList[edge.Source] = new List<GraphNode>();
                AdjacenceyList[edge.Source].Add(new GraphNode(edge.Destination, edge.Cost));
            }
        }

        public void AddEdge(GraphEdge graphEdge)
        {
            if (AdjacenceyList[graphEdge.Source] == null)
                AdjacenceyList[graphEdge.Source] = new List<GraphNode>();

            AdjacenceyList[graphEdge.Source].Add(new GraphNode(graphEdge.Destination, graphEdge.Cost));
        }

        public void RemoveEdge(GraphEdge graphEdge)
        {
            if (AdjacenceyList[graphEdge.Source] == null)
                throw new Exception("Such edge does not exists");
            var removalNode = AdjacenceyList[graphEdge.Source].Find((x) => (x.Destination == graphEdge.Destination) && (x.Cost == graphEdge.Cost));
            AdjacenceyList[graphEdge.Source].Remove(removalNode);
        }

        public void PrintGraph()
        {
            foreach(var node in AdjacenceyList)
            {
                foreach(var innerNode in node)
                {
                    Console.Write($"{node} {innerNode.Destination} => {innerNode.Cost}");
                }
                Console.WriteLine();
            }
        }
        
    }

    public class GraphEdge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Cost { get; set; }

        public GraphEdge(int src, int dest, int cost)
        {
            Source = src;
            Destination = dest;
            Cost = cost;
        }
    }

    public class GraphNode
    {
        public int Destination { get; set; }
        public int Cost { get; set; }

        public GraphNode(int dest, int cost)
        {
            Destination = dest;
            Cost = cost;
        }
    }
}
