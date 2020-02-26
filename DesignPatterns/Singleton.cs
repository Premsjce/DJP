namespace DesignPatterns
{
    public class Singleton
    {
        public static void Driver()
        {
            var singleton = ClassSingleton.GetInstance();
            System.Console.WriteLine(ClassSingleton.Temp);

            System.Console.WriteLine(singleton.GetNameOfClass());
            System.Console.WriteLine(singleton.TempRead);

            A a = new B();
            a.AMethod();
        }
    }


    public class A
    {
        public virtual void AMethod() { System.Console.WriteLine("A Method"); }
    }

    public class B : A
    {

        public override void AMethod() { System.Console.WriteLine("B Method"); }
    }

    public class ClassSingleton
    {
        public const int Temp = 45;
        public readonly int TempRead = 50;
        private ClassSingleton()
        {
            //Private Constructor
        }

        private static ClassSingleton instance;
        private static object syncObject = new object();
        public static ClassSingleton GetInstance()
        {
            if (instance == null)
            {
                lock (syncObject)
                {
                    if (instance == null)
                        instance = new ClassSingleton();
                }
            }

            return instance;
        }

        public string GetNameOfClass()
        {
            return GetType().Name;
        }

    }
}
