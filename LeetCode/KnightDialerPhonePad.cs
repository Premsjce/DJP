using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class KnightDialerPhonePad
    {
        private static int golbalCounter = 0;

        public static void Driver()
        {
            Console.WriteLine(GetValidNumberDP(3131));
        }

        private static int GetValidNumberDP(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 10;

            long modulo = (1000 * 1000 * 1000) + 7;
            long result = 0;

            long[,] stepTable = new long[10, n + 1];

            
            for(int phNum = 0; phNum < 10; phNum++)
                stepTable[phNum, 1] = 1;


            for (int numberLength = 2; numberLength <= n; numberLength++)
            {
                stepTable[0, numberLength] = (stepTable[4, numberLength - 1] + stepTable[6, numberLength - 1]) % modulo;
                stepTable[1, numberLength] = (stepTable[6, numberLength - 1] + stepTable[8, numberLength - 1]) % modulo;
                stepTable[2, numberLength] = (stepTable[7, numberLength - 1] + stepTable[9, numberLength - 1]) % modulo;
                stepTable[3, numberLength] = (stepTable[4, numberLength - 1] + stepTable[8, numberLength - 1]) % modulo;
                stepTable[4, numberLength] = (stepTable[0, numberLength - 1] + stepTable[3, numberLength - 1] + stepTable[9, numberLength - 1]) % modulo; 
                stepTable[6, numberLength] = (stepTable[0, numberLength - 1] + stepTable[1, numberLength - 1] + stepTable[7, numberLength - 1]) % modulo; 
                stepTable[7, numberLength] = (stepTable[2, numberLength - 1] + stepTable[6, numberLength - 1]) % modulo;
                stepTable[8, numberLength] = (stepTable[1, numberLength - 1] + stepTable[3, numberLength - 1]) % modulo;
                stepTable[9, numberLength] = (stepTable[2, numberLength - 1] + stepTable[4, numberLength - 1]) % modulo;
            }

            for(int i = 0; i < 10;i++)
            {
                result += (stepTable[i, n] % modulo);
            }

            return (int)(result % modulo);
        }

        private static int GetValidNumber(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 10;

            if (n == 2)
                return 20;


            char[,] phonePad = new char[4, 3]
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'},
                {'*','0','#'}
            };

            bool[,] visited;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    visited = new bool[4, 3];
                    DFS(phonePad, visited, i, j, 1, n);
                }

            }

            return golbalCounter;
        }

        private static void DFS(char[,] phonePad, bool[,] visited, int row, int col, int count, int n)
        {
            if (count == n)
            {
                golbalCounter += 1;
                return;
            }

            int[] ROWS = { -2, -2, -1, -1, 2, 2, 1, 1 };
            int[] COLS = { -1, 1, -2, 2, -1, 1, -2, 2 };

            visited[row, col] = true;


            for (int i = 0; i < 8; i++)
            {
                int nextRow = ROWS[i] + row;
                int nextCol = COLS[i] + col;

                if (IsSafeToJump(phonePad, nextRow, nextCol, 4, 3, visited))
                    DFS(phonePad, visited, nextRow, nextCol, count + 1, n);
            }

            visited[row, col] = false;
        }

        private static bool IsSafeToJump(char[,] phonePad, int row, int col, int R, int C, bool[,] visited)
        {
            return row >= 0 && row < R && col >= 0 && col < C && phonePad[row, col] != '*'
                && phonePad[row, col] != '#' && !visited[row, col];
        }
    }
}
