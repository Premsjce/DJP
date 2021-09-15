using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class TopViewOfTree
    {
        public static void Driver()
        {
            BinaryNode rootNode = new BinaryNode(1);
            rootNode = new BinaryNode(1);
            rootNode.Left = new BinaryNode(2);
            rootNode.Right = new BinaryNode(3);
            rootNode.Left.Right = new BinaryNode(4);
            rootNode.Left.Right.Right = new BinaryNode(5);
            rootNode.Left.Right.Right.Right = new BinaryNode(6);

            PrintTopView(rootNode);
        }

        public static void PrintTopView(BinaryNode rootNode)
        {
            if (rootNode == null)
                return;

            Queue<QueueNode> queueNodes = new Queue<QueueNode>();
            SortedDictionary<int, BinaryNode> topViewMap = new SortedDictionary<int, BinaryNode>();

            queueNodes.Enqueue(new QueueNode(rootNode, 0));

            while(queueNodes.Count != 0)
            {
                var currentQueueNode = queueNodes.Dequeue();

                if (!topViewMap.ContainsKey(currentQueueNode.Distance))
                    topViewMap.Add(currentQueueNode.Distance, currentQueueNode.Node);

                if (currentQueueNode.Node.Left != null)
                    queueNodes.Enqueue(new QueueNode(currentQueueNode.Node.Left, currentQueueNode.Distance - 1));

                if (currentQueueNode.Node.Right != null)
                    queueNodes.Enqueue(new QueueNode(currentQueueNode.Node.Right, currentQueueNode.Distance + 1));

            }

            foreach(var node in topViewMap.Values)
                Console.WriteLine(node.Data);

        }

    }

    public class BinaryNode
    {
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }
        public int Data { get; set; }

        public BinaryNode(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    public class QueueNode
    {
        public BinaryNode Node { get; set; }
        public int Distance { get; set; }
        public QueueNode(BinaryNode node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
