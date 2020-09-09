using System;
using System.Collections.Generic;

namespace TechieDelight.Arrays
{
    public static class EquilibriumIndex
    {
        public static void Driver()
        {
            int[] array = { 0, -3, 5, -4, -2, 3, 1, 0 };
            var indices = GetEquilibriumIndices(array);
            Console.WriteLine("Equilibrium indices are : " + indices.ListToString());
        }

        private static List<int> GetEquilibriumIndices(int[] array)
        {
            int totalSum = 0;
            foreach (var num in array)
                totalSum += num;

            int right = 0;
            List<int> indices = new List<int>();

            for(int i = array.Length-1; i >= 0; i--)
            {
                if (right == (totalSum - (array[i] + right)))
                    indices.Add(i);

                right += array[i];
            }

            return indices;
        }

        public static string ListToString(this List<int> list)
        {
            string output = "[";
            foreach (var num in list)
                output += $"{num}, ";
            output += "]";

            return output;
        }
    }
    
}
