using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem5_SmallestMultiple
    {
        public static void Driver()
        {
            int number = 20;
            var result = GetLCMForNNumbers(number);
            Console.WriteLine(result);
        }

        private static int GetLCMForNNumbers(int num)
        {
            int lcmNo = 1;
            int divisor = 2;
            int[] inpuArray = new int[num];
            for (int i = 0; i < num; i++)
                inpuArray[i] = i+1;


            while(true)
            {
                bool isDivided = false;
                int counter = 0;
                for (int i = 0; i < inpuArray.Length; i++)
                {
                    if (inpuArray[i] == 0)
                        return 0;
                    if (inpuArray[i] == 1)
                        counter++;
                        
                    if(inpuArray[i] % divisor == 0)
                    {
                        inpuArray[i] = inpuArray[i] / divisor;
                        isDivided = true;
                    }
                }

                if (isDivided)
                    lcmNo *= divisor;
                else
                    divisor++;

                if (counter == inpuArray.Length)
                    return lcmNo;
            }
        }
    }
}
