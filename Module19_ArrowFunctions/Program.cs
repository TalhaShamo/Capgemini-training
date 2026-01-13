using System;
namespace Module19_ArrowFunctions
{
    class Program
    {
        // You might be wondering why we used a delegate here for logic. We used it to demonstrate the Second Major Use Case of delegates -
        // Use Case 1 (The one you know): Decoupling two classes (Events, Notifications).
        // Use Case 2 (This one): Making a "Universal Method" (Passing Logic as a Parameter).

        // If we didn't use a delegate, we would have to write the logic inside the method using a switch case or if/else.
        // By using a delegate, we turned Calculate into a Universal Engine. It doesn't know math. It just knows how to run whatever 
        // you give it. 
        static int Calculate(int x, int y, Func<int, int, int> logic)
        {
            int result = logic(x, y);
            return result;
        }
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter two numbers -");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Add/Subtract/Multiply?");
            string operation = Console.ReadLine();

            int ans = 0;

            // As seen, we are able to define the logic of the calculator on the go. This is the advantage of using arrow functions
            if(operation == "Add")
            {
                ans = Calculate(num1, num2, (num1, num2) => num1 + num2);
            }
            else if(operation == "Subtract") ans = Calculate(num1, num2, (num1, num2) => num1 - num2);
            else if(operation == "Multiply") ans = Calculate(num1, num2, (num1, num2) => num1*num2);
            else Console.WriteLine("No such operation!");

            Console.WriteLine($"Answer : {ans}");
        }
    }
}