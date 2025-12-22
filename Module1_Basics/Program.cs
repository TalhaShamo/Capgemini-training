using System;

namespace Module1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2;
            Console.WriteLine("Enter both numbers : ");
            n1 = int.Parse(Console.ReadLine());
            n2 = int.Parse(Console.ReadLine());

            string operation;
            Console.WriteLine("Enter the operation (+, -, *) : ");
            operation = Console.ReadLine();
            switch (operation)
            {
                case "+":
                Console.WriteLine(n1 + n2);
                break;

                case "-":
                Console.WriteLine(n1-n2);
                break;

                case "*":
                Console.WriteLine(n1*n2);
                break;

                default:
                Console.WriteLine("invalid opertaion");
                break; 
            }
        }  
    }
}
