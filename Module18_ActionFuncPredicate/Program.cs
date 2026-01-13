// Microsoft realized developers were tired of defining custom delegates like public delegate int MathOp(int a, int b);. 
// So, they gave us three standard generic tools that cover 99% of scenarios.

// 1. Action

//     Purpose: Runs code that returns nothing (void).

//     Signature: Action<InputType>

//     Behavior: "Take this data, do something with it, and don't come back."

//     Common Use: Printing, Logging, Saving to DB, UI Updates.

//     Example: Action<string> print = Console.WriteLine;

// 2. Func

//     Purpose: Runs code that returns a value.

//     Signature: Func<InputType, ReturnType>

//     Rule: The LAST type listed is always the Return Type.

//     Behavior: "Take this input, calculate something, and give me the result."

//     Common Use: Math, Transformations (Data A -> Data B), Factories.

//     Example: Func<int, int> square = x => x * x; (Input int, Return int).

// 3. Predicate

//     Purpose: Checks a condition and returns true/false.

//     Signature: Predicate<InputType>

//     Behavior: "Take this object, inspect it, and tell me if it passes the test."

//     Common Use: Filtering lists, Validation, Searching.

//     Example: Predicate<int> isEven = x => x % 2 == 0;


using System;

namespace Module18_AllDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 🎓 The Delegate Math Exam ---");

            // ---------------------------------------------------------
            // 1. FUNC: The Calculator
            // Logic: Takes two ints (inputs), Returns an int (output)
            // ---------------------------------------------------------
            Func<int, int, int> multiply = (a, b) => 
            {
                return a * b;
            };

            // Let's use it
            int num1 = 5;
            int num2 = 4;
            int correctAnswer = multiply(num1, num2); // Returns 20

            // ---------------------------------------------------------
            // 2. PREDICATE: The Validator
            // Logic: Takes an int (user answer), Returns true/false
            // ---------------------------------------------------------
            Predicate<int> checkAnswer = (userAnswer) => 
            {
                return userAnswer == correctAnswer;
            };

            // Simulate User Input
            Console.Write($"What is {num1} * {num2}? ");
            int input = int.Parse(Console.ReadLine());

            // ---------------------------------------------------------
            // 3. ACTION: The Reporter
            // Logic: Takes a bool (result), Returns void (just prints)
            // ---------------------------------------------------------
            Action<bool> printResult = (isCorrect) => 
            {
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Correct! You are a genius.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ Wrong! The answer was {correctAnswer}.");
                }
                Console.ResetColor();
            };

            // --- TIE IT ALL TOGETHER ---
            
            // Step A: Check the answer using Predicate
            bool result = checkAnswer(input);

            // Step B: Print the report using Action
            printResult(result);
        }
    }
}