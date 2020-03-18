using System;

namespace Searching
{
    class MainDriver
    {
        static void Main(string[] args)
        {
            //BreadthFirstSearch.Driver();
            //DepthFirstSearch.Driver();
            DijkstrasAlgrithm.Driver();
            Console.WriteLine("Press Enter to close....");
            Console.ReadLine();
        }
    }
}
