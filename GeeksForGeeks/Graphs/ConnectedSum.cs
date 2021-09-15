using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeksForGeeks.Graphs
{
    public class ConnectedSum
    {
        public static void Driver()
        {
            int graphNodes = 10;
            List<int> graphFrom = new List<int>() { 1, 1, 2, 3, 7 };
            List<int> graphTo = new List<int>() { 2, 3, 4, 5, 8 };

            int sum = GetConnectedSum(graphNodes, graphFrom, graphTo);
            Console.WriteLine(sum);
        }

        private static int GetConnectedSum(int graphNodes, List<int> graphFrom, List<int> graphTo)
        {
            //First thing to be done is to construct the Graph
            var graph = ConstructGraph(graphFrom, graphTo, graphNodes);

            int sum = 0;
            HashSet<int> visitedNodes = new HashSet<int>();

            //Traverse the graph and get the group count
            for (int node = 1; node <= graphNodes; node++)
            {
                var isolatedGroup = GetIsolatedGroup(node, graph, visitedNodes);

                if (isolatedGroup == null || isolatedGroup.Count == 0)
                    continue;

                var squareRoot = Math.Sqrt(isolatedGroup.Count);
                var ceilingValue = Math.Ceiling(squareRoot);
                sum += (int)ceilingValue;
            }

            return sum;
        }

        private static HashSet<int> GetIsolatedGroup(int node, Dictionary<int, HashSet<int>> graph, HashSet<int> visitedNodes)
        {
            var group = new HashSet<int>();

            if (visitedNodes.Contains(node))
                return group;

            Queue<int> nodesToVisit = new Queue<int>();
            nodesToVisit.Enqueue(node);
            group.Add(node);

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Dequeue();
                visitedNodes.Add(currentNode);
                var childrens = graph[currentNode];

                if (childrens == null)
                    continue;

                foreach(var child in childrens)
                {
                    if(!visitedNodes.Contains(child))
                    {
                        group.Add(child);
                        nodesToVisit.Enqueue(child);
                    }
                }
            }

            return group;
        }

        private static Dictionary<int, HashSet<int>> ConstructGraph(List<int> graphFrom, List<int> graphTo, int graphNodes)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < graphFrom.Count; i++)
            {
                var sourceNode = graphFrom[i];
                var destinationNode = graphTo[i];
                
                //Adding Source to Destination
                if (!graph.ContainsKey(sourceNode))
                    graph.Add(sourceNode, new HashSet<int>());

                graph[sourceNode].Add(destinationNode);

                //Adding Destination to Source
                if (!graph.ContainsKey(destinationNode))
                    graph.Add(destinationNode, new HashSet<int>());

                graph[destinationNode].Add(sourceNode);
            }

            for (int node = 1; node <= graphNodes; node++)
            {
                if(!graph.ContainsKey(node))
                    graph.Add(node, new HashSet<int>());
            }


            return graph;
        }
    }
}