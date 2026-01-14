// Study Notes: StringBuilder (System.Text)
// 1. The Problem: String Immutability

// In C#, standard "string" objects are Immutable (Unchangeable).

//     The Trap: Every time you modify a string (using "+" or ".Replace()"), C# does not change the original. Instead, 
//     it creates a brand new copy in memory and throws the old one in the trash.

//     The Consequence: Doing this in a loop (e.g., 10,000 times) creates 10,000 temporary objects, causing memory spikes and 
//     slowing down your app.

// 2. The Solution: StringBuilder

// "StringBuilder" is a Mutable string.

//     Analogy:

//         String: A block of ice. To change the shape, you must melt it and freeze a new block.

//         StringBuilder: A bucket of water. You can add, remove, or stir the water instantly without needing a new bucket.

//     When to use: Whenever you are manipulating text inside a Loop or making many changes to a single text variable.

// 3. Key Properties

//     Length: The number of characters currently in the string.

//     Capacity: The amount of memory reserved behind the scenes. (Tip: If you know the size upfront, set this in the constructor to avoid resizing overhead.)

// 4. The Toolkit (Essential Methods)

// All these methods modify the object in-place.

// A. Adding Text 
// 1) StringBuilder sb = new StringBuilder(); sb.Append("Hello");  Adds text to the end 
// 2) sb.AppendLine(" World");  Adds text to the end + a New Line

// B. Editing Text 
// 1) sb.Insert(6, "beautiful ");  Injects text at a specific index ("Hello World" -> "Hello beautiful World")
// 2) sb.Replace("Hello", "Hi");  Swaps ALL occurrences of a word

// C. Deleting Text 
// 1) sb.Remove(0, 3);  Removes text starting at index 0 for a length of 3 (Removes "Hi ")

// D. Resetting 
// 1) sb.Clear();  Wipes the text but keeps the memory reserved (Good for loops)

// E. Finalizing 
// 1) string result = sb.ToString();  Converts the StringBuilder back to a regular String so you can use it

using System;
using System.Text;
namespace Module23_StringBuilder
{
    class Program
    {
        static void Main(string[] arg)
        {
            StringBuilder message = new StringBuilder("System Status: Error. The user is offline.");
            Console.WriteLine(message);

            message.Replace("Error", "Active");
            message.Replace("offline", "online");
            Console.WriteLine(message);

            //This is the way to safely navigate indices
            string currentText = message.ToString();
            int index = currentText.IndexOf("online");
            if(index != -1) //Checking for out of bounds
            {
                message.Insert(index, "currently ");
            }
            Console.WriteLine(message);

            message.AppendLine("Last checked: 10:00 AM");
            Console.WriteLine(message);

            Console.WriteLine($"Length of message : {message.Length}");

            currentText = message.ToString();
            int index1 = currentText.IndexOf("Last");
            if(index1 != -1)
            {
                message.Remove(index1, 22);
            }
            Console.WriteLine(message);

            message.Clear();
        }
    }
}