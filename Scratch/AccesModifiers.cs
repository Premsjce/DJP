using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratch
{
    public class AccesModifiers
    {
        public static void Driver()
        {
            new NedStark().Testing();
        }
    }

    public class BasePerson
    {
        public BasePerson() { } //default constructor

        public BasePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
        protected string GetInfo() => $"{Name} is {Age} years old";
    }

    public class NedStark : BasePerson
    {
        public NedStark() { } // Default constructor
        
        public NedStark(string name, int age): base(name,age) { }
        public string NedStarksProperty { get; } = "ITs NED's Property";
        
        public void Testing()
        {
            NedStark nedStark = new NedStark("Ned", 52) ;
            string name = nedStark.NedStarksProperty;
            nedStark.GetInfo();
        }
    }

    public class RobStark : NedStark
    {
        public string RobStarksProperty { get; } = "Its rob starks property";

        public void TestingRobStark()
        {            
            NedStark stark = new NedStark();
            //Cmompiler error
            //stark.GetInfo();

            RobStark robStark = new RobStark();
            robStark.GetInfo();
        }
    }
}
