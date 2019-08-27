using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class AbstractFactory
    {
        public static void Driver()
        {
            var phoneFactory = PhoneAbstractFactory.GetPhoneFactory(PhoneManufacturers.HTC);
            Console.WriteLine(phoneFactory.ToString());
            Console.WriteLine(phoneFactory.GetDumbPhone().Name());
            Console.WriteLine(phoneFactory.GetSmartPhone().Name());

            Console.WriteLine();
            phoneFactory = PhoneAbstractFactory.GetPhoneFactory(PhoneManufacturers.Nokia);
            Console.WriteLine(phoneFactory.ToString());
            Console.WriteLine(phoneFactory.GetDumbPhone().Name());
            Console.WriteLine(phoneFactory.GetSmartPhone().Name());

            Console.WriteLine();
            phoneFactory = PhoneAbstractFactory.GetPhoneFactory(PhoneManufacturers.Samsung);
            Console.WriteLine(phoneFactory.ToString());
            Console.WriteLine(phoneFactory.GetDumbPhone().Name());
            Console.WriteLine(phoneFactory.GetSmartPhone().Name());
        }
    }


    public class PhoneAbstractFactory
    {
        public static IPhoneFactory GetPhoneFactory(PhoneManufacturers phoneManufacturers)
        {
            IPhoneFactory phoneFactory;
            switch(phoneManufacturers)
            {
                case PhoneManufacturers.HTC:
                    phoneFactory = new HTCFactory();
                    break;
                case PhoneManufacturers.Nokia:
                    phoneFactory = new NokiaFactory();
                    break;
                case PhoneManufacturers.Samsung:
                    phoneFactory = new SamsungFactory();
                    break;
                default:
                    phoneFactory = new SamsungFactory();
                    break;
            }
            return phoneFactory;
        }
    }

    public enum PhoneManufacturers
    {
        Nokia,
        Samsung,
        HTC
    }

    public interface IPhone
    {
        string Name();
    }

    public interface ISmartPhone : IPhone
    {
        string  AndroidVersion { get; set; }
    }

    public interface IDumbPhone : IPhone
    {
        int ContactBookSize { get; set; } 
    }


    //Concrete classes for Dumb phones
    public class Asha : IDumbPhone
    {
        public int ContactBookSize { get; set; }

        public string Name() => $"Asha Dumb feature Phone";
    }

    public class Pasha : IDumbPhone
    {
        public int ContactBookSize { get; set; }

        public string Name() => $"Pasha Dumb feature Phone";
    }

    public class Genie : IDumbPhone
    {
        public int ContactBookSize { get; set; }

        public string Name() => $"Genie Dumb feature Phone";
    }


    //Concrete classes for Smart phones
    public class Lumia : ISmartPhone
    {
        public string AndroidVersion { get; set; }

        public string Name() => $"Lumia Smart phone";        
    }

    public class Galaxy : ISmartPhone
    {
        public string AndroidVersion { get; set; }

        public string Name() => $"Galaxy Smart phone";
    }

    public class Tital : ISmartPhone
    {
        public string AndroidVersion { get; set; }

        public string Name() => $"Titan Smart phone";
    }

    public interface IPhoneFactory
    {
        ISmartPhone GetSmartPhone();
        IDumbPhone GetDumbPhone();
    }

    public class SamsungFactory : IPhoneFactory
    {
        public override string ToString() => $"From Samsung : ";
        public IDumbPhone GetDumbPhone() => new Pasha();
        public ISmartPhone GetSmartPhone() => new Galaxy();        
    }

    public class NokiaFactory : IPhoneFactory
    {
        public override string ToString() => $"From Nokia : ";
        public IDumbPhone GetDumbPhone() => new Asha();
        public ISmartPhone GetSmartPhone() => new Lumia();
    }

    public class HTCFactory : IPhoneFactory
    {
        public override string ToString() => $"From HTC : ";
        public IDumbPhone GetDumbPhone() => new Genie();
        public ISmartPhone GetSmartPhone() => new Tital();
    }
}

