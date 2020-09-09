using System;

namespace CleanCode
{
    /// <summary>
    /// Action, Prdicate and Func Delegates
    /// </summary>
    public class GenericDelegates
    {
        public static void Driver()
        {
            //    Action action;
            //    Func<int,int,bool> func;
            //    Predicate<string> predicate;

            SampleDelegates sampleDelegates = new SampleDelegates();

            Action action = new Action(sampleDelegates.GenericAction);

            Action<string> actionOne = new Action<string>(sampleDelegates.GenericAction);

            Action<string, string> actionPara = new Action<string, string>(sampleDelegates.GenericAction);

            Func<string> func = new Func<string>(sampleDelegates.GenericFunc);

            Predicate<int> predicate = new Predicate<int>(sampleDelegates.GenrericPredicate);

            action();
            actionOne("Here come the one and only parameter");
            actionPara("FirstPara", "SecondPara");

            Console.WriteLine(func());

            Console.WriteLine(predicate(10));
        }
    }

    public class SampleDelegates
    {
        public void GenericAction() => Console.WriteLine("Its Generic Action Method");

        public void GenericAction(string para1) => Console.WriteLine($"Its Generic Action Method : {para1}");

        public void GenericAction(string para1, string para2) => Console.WriteLine($"Its Generic Action Method : {para1}  {para2}");
        
        public string GenericFunc()
        {
            Console.WriteLine("Its generic function method");
            return "Returning from GenericFun";
        }

        public bool GenrericPredicate(int num)
        {
            Console.WriteLine("Its generic predicate method, argument passed is " + num);
            return true;
        }
    }
}
