using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class BuilderPattern
    {
        public static void Driver()
        {
            var carBuilder = new HighPriceCarBuilder();
            var mecEngineer = new MechanicalEngineer(carBuilder);

            mecEngineer.BuildCar();
            var car = mecEngineer.GetCar();
            Console.WriteLine($"Builder Constrcuted {car} Car");
        }
    }

    public interface ICarPlan
    {
        void SetBase(string baseMent);
        void SetWheels(string wheels);
        void SetEngine(string engine);
        void SetRoof(string roof);
        void SetMirror(string mirror);
        void SetLights(string lights);
        void SetInterior(string interior);             
    }

    public class Car : ICarPlan
    {
        public string Base { get; private set; }
        public string Wheels { get; private set; }
        public string Engine { get; private set; }
        public string Roof { get; private set; }
        public string Mirror { get; private set; }
        public string Light { get; private set; }
        public string Interior { get; private set; }

        public void SetBase(string baseMent) => Base = baseMent;

        public void SetEngine(string engine) => Wheels = engine;

        public void SetInterior(string interior) => Interior = interior;

        public void SetLights(string light) => Light = light;

        public void SetMirror(string mirror) => Mirror = mirror;

        public void SetRoof(string roof) => Roof = roof;

        public void SetWheels(string wheel) => Wheels = wheel;

    }

    public interface ICarBuilder
    {
        Car GetCar();
        void BuildBase();
        void BuildEngine();
        void BuildInterior();
        void BuildMirror();
        void BuildRoof();
        void BuildLight();
        void BuildWheels();
    }

    public class LowPriceCarBuilder : ICarBuilder
    {
        private Car Car;

        public LowPriceCarBuilder() => Car = new Car();

        public Car GetCar() => Car;

        public void BuildBase() => Car.SetBase("Low Priced Base");

        public void BuildEngine() => Car.SetEngine("Low Priced Engine");

        public void BuildInterior() => Car.SetInterior("Low Priced Interior");

        public void BuildLight() => Car.SetLights("Low Priced Lights");

        public void BuildMirror() => Car.SetMirror("Low Priced Mirrors");

        public void BuildRoof() => Car.SetRoof("Low Priced Roofs");

        public void BuildWheels() => Car.SetWheels("Low Priced Wheels");
    }

    public class HighPriceCarBuilder : ICarBuilder
    {

        private Car Car;

        public HighPriceCarBuilder() => Car = new Car();

        public Car GetCar() => Car;

        public void BuildBase() => Car.SetBase("High Priced Base");

        public void BuildEngine() => Car.SetEngine("High Priced Engine");

        public void BuildInterior() => Car.SetInterior("High Priced Interior");

        public void BuildLight() => Car.SetLights("High Priced Lights");

        public void BuildMirror() => Car.SetMirror("High Priced Mirrors");

        public void BuildRoof() => Car.SetRoof("High Priced Roofs");

        public void BuildWheels() => Car.SetWheels("High Priced Wheels");
    }
    
    public class MechanicalEngineer
    {
        private ICarBuilder CarBuilder { get; }

        public MechanicalEngineer(ICarBuilder carBuilder) => CarBuilder = carBuilder;

        public Car GetCar() => CarBuilder.GetCar();

        public void BuildCar()
        {
            CarBuilder.BuildBase();
            CarBuilder.BuildEngine();
            CarBuilder.BuildInterior();
            CarBuilder.BuildLight();
            CarBuilder.BuildMirror();
            CarBuilder.BuildRoof();
            CarBuilder.BuildWheels();
        }
    }
}
