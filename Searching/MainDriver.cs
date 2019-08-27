using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class MainDriver
    {
        static void Main(string[] args)
        {
            //BreadthFirstSearch.Driver();
            DepthFirstSearch.Driver();
            Console.WriteLine("Press Enter to close....");
            Console.ReadLine();
        }
    }
}
