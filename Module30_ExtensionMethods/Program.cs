// Study Notes: Extension Methods
// 1. What are ExtensionMethods?

// Extension methods allow you to "add" new CUSTOM methods to existing types without modifying the original source code. 
// We define what these custom methods do ourselves.

// 2. The Three Golden Rules
// To create an extension method, you must follow this exact structure:

//     a) The container class must be static.

//     b) The method itself must be static.

//     c) The first parameter must utilize the this keyword to specify which type is being extended.

using System;
namespace Module30_ExtensionMethods4
{
    // RULE 1: The container class must be 'static'
    public static class MoneyExtension
    {
        // RULE 2: The method itself must be 'static'
        // RULE 3: The 'this' keyword tells C# to attach this method to the 'double' type
        public static string ToCurrency(this double amount)
        {
            // "F2" formats it to Fixed-point notation with 2 decimal places
            return $"${amount.ToString("F2")}"; 
        }
    }

    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter your money : ");
            double myMoney = double.Parse(Console.ReadLine());

            // USAGE: call it as if it were a native method of the Double class.
            // Note: We don't pass any arguments because 'myMoney' moves into 'amount' automatically.
            string myCurrency = myMoney.ToCurrency();
            
            Console.WriteLine($"Here is your currency : {myCurrency}");
        }
    }
}
