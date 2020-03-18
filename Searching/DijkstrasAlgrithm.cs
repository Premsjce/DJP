using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class DijkstrasAlgrithm
    {
        public static void Driver()
        {
            List<DijkstrasEdge> dijkstrasEdges = new List<DijkstrasEdge>()
            {
                new DijkstrasEdge(0, 1, 10),
                new DijkstrasEdge(0, 4, 3),
                new DijkstrasEdge(1, 2, 2),
                new DijkstrasEdge(1, 4, 4),
                new DijkstrasEdge(2, 3, 9),
                new DijkstrasEdge(3, 2, 7),
                new DijkstrasEdge(4, 1, 1),
                new DijkstrasEdge(4, 2, 8),
                new DijkstrasEdge(4, 3, 2)
            };

            DijkstrasGraph dijkstrasGraph = new DijkstrasGraph(dijkstrasEdges, 5);
            ShortestDistance(dijkstrasGraph, 0, 5);
        }

        public static void ShortestDistance(DijkstrasGraph dijkstrasGraph, int source, int Nodes)
        {
            int[] distance = new int[Nodes];
            int[] previous = new int[Nodes];
            bool[] visited = new bool[Nodes];

            distance[source] = 0;
            previous[source] = -1;

            PriorityQueue<int, DijkstarsNode> minHeap = new PriorityQueue<int, DijkstarsNode>();
            minHeap.Add(new KeyValuePair<int, DijkstarsNode>(0, new DijkstarsNode(source, 0, null)));

            while(minHeap.Count > 0)
            {
                var node = minHeap.Dequeue().Value;
                foreach (var edge in dijkstrasGraph.Edges[node.Vertex])
                {
                    if(!visited[edge.Source])
                    {
                        int edgeDestination = edge.Destination;
                        int edgeWeight = edge.Weight;
                        int newWeight = edgeWeight + node.MinWeight;

                        if(!visited[edgeDestination] && (distance[edgeDestination] > newWeight))
                        {
                            distance[edgeDestination] = newWeight;
                            previous[edgeDestination] = node.Vertex;
                        }

                        minHeap.Add(new KeyValuePair<int, DijkstarsNode>(distance[edgeDestination], new DijkstarsNode(edgeDestination, distance[edgeDestination], node)));
                    }
                }

                visited[node.Vertex] = true;
            }

            Console.WriteLine("Printing all tha paths");
            for (int i = 1; i < Nodes; i++)
            {
                Console.Write($"Shortest Distance from  Node 0 to {i} is  : {distance[i]}, And the path is [ ");
                PrintPath(previous, i);
                Console.Write("]");
                Console.WriteLine();
            }
        }

        private static void PrintPath(int[] previous, int i)
        {
            if (i < 0) return;
            PrintPath(previous, previous[i]);
            Console.Write(i + " ");
        }
    }

    public class DijkstrasEdge
    {
        public int Source { get; }
        public int Destination { get; }
        public int Weight { get; set; }

        public DijkstrasEdge(int src, int dest, int wt)
        {
            Source = src;
            Destination = dest;
            Weight = wt;
        }
    }

    public class DijkstarsNode
    {
        public int Vertex { get; }
        public int MinWeight { get; }
        public DijkstarsNode ComingFrom { get; }

        public DijkstarsNode(int vertex, int minWt, DijkstarsNode comngFrom)
        {
            Vertex = vertex;
            MinWeight = minWt;
            ComingFrom = comngFrom;
        }
    }

    public class DijkstrasGraph
    {
        public List<List<DijkstrasEdge>> Edges { get; set; }

        public DijkstrasGraph(List<DijkstrasEdge> edges, int totalNodes)
        {
            Edges = new List<List<DijkstrasEdge>>();

            for (int i = 0; i < totalNodes; i++)
                Edges.Add(new List<DijkstrasEdge>());

            foreach (var edge in edges)
                Edges[edge.Source].Add(edge);
        }
    }
}
