using System;
using System.Collections.Generic;

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
                if (queue.Count > 0)
                    break;
                for (int column = 0; column < COLUMNLENGTH; column++)
                {
                    if (charArray[row, column] == '0')
                        visited[row, column] = true;
                    else if (charArray[row, column] == 's')
                    {
                        source = new BFSNode(row, column, 0);
                        queue.Enqueue(source);
                        break;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (charArray[item.Row, item.Column] == 'd')
                    return item.Distance;

                int[] ROW = { 0, 0, -1, 1 };
                int[] COL = { -1, 1, 0, 0 };


                for (int i = 0; i < 4; i++)
                {
                    int currentRow = item.Row + ROW[i];
                    int currentCol = item.Column + COL[i];

                    if (IsSafeAndValid(charArray, visited, currentRow, currentCol, ROWLENGTH, COLUMNLENGTH))
                    {
                        queue.Enqueue(new BFSNode(currentRow, currentCol, item.Distance + 1));
                        visited[currentRow, currentCol] = true;
                    }
                }
            }

            return -1;
        }

        private static bool IsSafeAndValid(char[,] charArray, bool[,] visited, int row, int col, int rLength, int cLength)
        {
            return row >= 0 && col >= 0 && row < rLength && col < cLength && !visited[row, col] && charArray[row, col] == '*';
        }
    }
}
