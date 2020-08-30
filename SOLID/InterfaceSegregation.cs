using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * The Interface Segregation Principle states that no client should be forced to depend on methods it does not use. 
     * So, this is the basic definition which we can read in many different articles, but what does this really mean?
     * 
     * Let’s imagine that we are starting a new feature on our project. We start with some code and from that code, 
     * an interface emerges with the required declarations.
     * Soon after, the customer decides that they want another feature which is similar to the previous one and 
     * we decide to implement the same interface in another class. But now, as a consequence, we don’t need all the methods from that interface, just some of them.
     * Of course, we have to implement all the methods, which we shouldn’t have to, and that ’s the problem and where the ISP helps us a lot.
     * 
     * Basically, the ISP states that we should reduce code objects down to the smallest required implementation 
     * thus creating interfaces with only required declarations. As a result, 
     * an interface that has a lot of different declarations should be split up into smaller interfaces.
     * 
     * https://code-maze.com/interface-segregation-principle/
     */

    //I'll just write the code below, try to understand 

    public interface IVehicle
    {
        void Drive();
        void Fly();
    }

    public class FutureCar : IVehicle
    {
        public void Drive() => Console.WriteLine("Can Drive");
        public void Fly() => Console.WriteLine("Can Fly");
    }

    //Now in below 2 classes problem arises

    public class NormalCar : IVehicle
    {
        public void Drive() => Console.WriteLine("Can Drive");
        
        //Car doesn't need the fly functinality here
        public void Fly() => throw new NotImplementedException();
    }

    public class Airplane : IVehicle
    {
        //Airplane doesn't need the drive functionality
        public void Drive() => throw new NotImplementedException();        

        public void Fly() => Console.WriteLine("Can Fly");
    }
    
    //Now the solution is to create a finely grained and tuned interfaces as per client needs,
    //Which avoid any unnecessarry method implement requirements from force interfaces

    public interface IDrive
    {
        void Drive();
    }

    public interface IFly
    {
        void Fly();
    }

    public interface IMultiFuntionVehicle : IDrive, IFly
    {

    }

    public class Car : IDrive
    {
        public void Drive() => Console.WriteLine("Driving car");
    }

    public class Plane : IFly
    {
        public void Fly() => Console.WriteLine("Flying high the plane");
    }

    class InterfaceSegregation
    {
    }
}
