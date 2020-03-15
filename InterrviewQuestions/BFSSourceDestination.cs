using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public class BFSNode
    {
        public int Row { get; }
        public int Column { get; }
        public int Distance { get; }

        public BFSNode(int _row, int _col, int _distance)
        {
            Row = _row;
            Column = _col;
            Distance = _distance;
        }
    }

    public class BFSSourceDestination
    {
        public static void Driver()
        {
            char[,] charArray = {{ '0', '*', '0', 's' },
                                 { '*', '0', '*', '*' },
                                 { '0', 'd', '*', '*' },
                                 { '*', '*', '*', '*' }};
            
            int result = DestinationDistance(charArray);
            Console.WriteLine(result);
        }

        private static int DestinationDistance(char[,] charArray)
        {
            int ROWLENGTH = charArray.GetLength(0);
            int COLUMNLENGTH = charArray.GetLength(1);

            bool[,] visited = new bool[ROWLENGTH, COLUMNLENGTH];
            Queue<BFSNode> queue = new Queue<BFSNode>();
            BFSNode source;

            for (int row = 0; row < ROWLENGTH; row++)
            {
                for (int column = 0; column < COLUMNLENGTH; column++)
                {
                    if (charArray[row, column] == '0')
                        visited[row, column] = true;
                    else if (charArray[row, column] == 's')
                    {
                        source = new BFSNode(row, column, 0);
                        queue.Enqueue(source);
                    }
                }
            }

            while(queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (charArray[item.Row, item.Column] == 'd')
                    return item.Distance;

                //Moving up
                if(item.Row - 1 >= 0 && !visited[item.Row-1, item.Column])
                {
                    queue.Enqueue(new BFSNode(item.Row - 1, item.Column, item.Distance + 1));
                    visited[item.Row - 1, item.Column] = true;
                }

                //Moving down
                if (item.Row + 1 < ROWLENGTH && !visited[item.Row + 1, item.Column])
                {
                    queue.Enqueue(new BFSNode(item.Row + 1, item.Column, item.Distance + 1));
                    visited[item.Row + 1, item.Column] = true;
                }

                //Moving left
                if (item.Column -1 >= 0 && !visited[item.Row , item.Column - 1])
                {
                    queue.Enqueue(new BFSNode(item.Row, item.Column - 1, item.Distance + 1));
                    visited[item.Row, item.Column -1] = true;
                }

                //Moving left
                if (item.Column + 1 < COLUMNLENGTH && !visited[item.Row, item.Column + 1])
                {
                    queue.Enqueue(new BFSNode(item.Row, item.Column + 1, item.Distance + 1));
                    visited[item.Row, item.Column + 1] = true;
                }
            }

            return -1;
        }
    }
}
