using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * 
     * The Liskov Substitution Principle (LSP) states that child class objects should be able to replace parent class objects 
     * without compromising application integrity. 
     * What this means essentially, is that we should put an effort to create such derived class objects which can replace objects of the base class
     * without modifying its behavior. If we don’t, our application might end up being broken.
     * https://code-maze.com/liskov-substitution-principle/
     * 
     */

    public class SumCalculator
    {
        public int[] numbers;
        public SumCalculator(int[] nums)
        {
            numbers = nums;
        }

        public virtual int Calculate() => numbers.Sum();
    }


    public class EvenSumCalculator : SumCalculator
    {
        public EvenSumCalculator(int[] nums) : base(nums)
        {
        }
        public override int Calculate() => numbers.Where(x => x % 2 == 0).Sum();
    }

    //now the problem with above code is that we can do
    // SumCalulator  sumCalc = new EvenSumCalulator({1,2,3,4,5,6,7,8,9});
    //And the result would be total sum and not even number sum


    class LiskovSubstitution
    {
        public static void Driver()
        {
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };

            SumCalculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");

            Console.WriteLine();

            SumCalculator evenSum = new EvenSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
        }
    }

    //Even better solution is to create an abstract base class,
    //Such that when baseclass reference is given to derrived class object then it shouldn't change the behaviour

    public abstract class Calculator
    {
        public int[] numbers;
        public Calculator(int[] nums)
        {
            numbers = nums;
        }
        public abstract int Calculate();
    }

    public class SumCalculatorBetter : Calculator
    {
        public SumCalculatorBetter(int[] nums) : base(nums)
        {

        }
        public override int Calculate() => numbers.Sum();
    }

    public class EvenNumberSumCalculatorBetter : Calculator
    {
        public EvenNumberSumCalculatorBetter(int[] nums)  : base(nums)
        {

        }

        public override int Calculate() => numbers.Where(x => x % 2 == 0).Sum();
    }


    public class OddNumberSumCalculatorBetter : Calculator
    {
        public OddNumberSumCalculatorBetter(int[] nums) : base(nums)
        {

        }

        public override int Calculate() =>numbers.Where(x => x % 2 != 0).Sum();
    }


}
