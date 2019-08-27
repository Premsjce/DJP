using System;

namespace DynamicProgramming
{
    class TowerOfHanoi
    {
        static long globalCounter;
        public static void Driver()
        {
            int discs = 6;
            char mainRod = 'A', auxRod = 'B', destRod = 'C';
            MakeMovement(discs, mainRod, auxRod, destRod);
            Console.WriteLine($"Total movements for {discs} were : {globalCounter}");
        }

        public static void MakeMovement(int discs, char mainRod, char auxRod, char destRod)
        {
            if(discs==1)
            {
                Console.WriteLine($"Moving disc {discs} from rod {mainRod} to rod {destRod}");
                ++globalCounter;
                return;
            }
            MakeMovement(discs - 1, mainRod, destRod, auxRod);
            Console.WriteLine($"Moving disc {discs} from rod {mainRod} to rod {destRod}");
            ++globalCounter;
            MakeMovement(discs - 1, auxRod, mainRod, destRod);
        }
    }
}
