using System;

namespace DesignPatterns
{
    class DesignPatternDriver
    {
        static void Main(string[] args)
        {
            //FactoryMethod.Driver();
            //AbstractFactory.Driver();
            //BuilderPattern.Driver();
            BridgePattern.Driver();
            
            Console.WriteLine("Press Enter to close......");
            Console.ReadLine();
        }
    }
}
