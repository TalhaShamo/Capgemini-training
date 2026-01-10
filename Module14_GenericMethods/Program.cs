using System;
namespace Module14_GenericMethods
{
    class Utils
    {
        public void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string greet = "Hello";
            string name = "John";
            Utils newUtil = new Utils();
            Console.WriteLine($"Before Swapping : {greet} {name}");
            newUtil.Swap<string>(ref greet, ref name);
            Console.WriteLine($"After Swapping : {greet} {name}");

            int num1 = 10;
            int num2 = 20;
            Console.WriteLine($"Before Swapping : {num1} {num2}");
            newUtil.Swap<int>(ref num1, ref num2);
            Console.WriteLine($"AFter Swappnig : {num1} {num2}");

            //So in short we are able to swap different types of datatypes with the same method with the help of generic methods.
            //This is inline wtih the DRY concept (Do not repeat yourself)
        }
    }
}