using System;

namespace SOLID
{
    class ZZDriver
    {
        static void Main(string[] args)
        {
            int i = 5;
            int j = 6;
            calc(ref i);
            calc(6);
            Console.WriteLine(i);
            Console.ReadLine();
        }

        static void calc(ref int x)
        {
            x = x * x;
        }
        static void calc(int x)
        {
            Console.WriteLine(x * x * x);
        }

        public static ZZDriver operator +(ZZDriver zZDriver)
        {
            return null;
        }

        //public static ZZDriver operator -(ZZDriver zZDriver)
        //{
        //    return null;
        //}

        public static bool operator true(ZZDriver unary)
        {
            return true;
        }

        public static bool operator false(ZZDriver unary)
        {
            return false;
        }
    }
}
