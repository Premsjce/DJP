using System;

namespace DesignPatterns
{
    class DesignPatternDriver
    {
        static void Main(string[] args)
        {
            PubSub.Driver();
            //Observer.Driver();
            //FactoryMethod.Driver();
            //AbstractFactory.Driver();
            //BuilderPattern.Driver();
            //BridgePattern.Driver();
            //Singleton.Driver();
            Console.WriteLine("Press Enter to close......");
            Console.ReadLine();
        }
    }
}
