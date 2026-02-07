// 📘 Module: C# Dictionaries (Hash Maps)
// 1. The Concept

// A Dictionary (Dictionary<TKey, TValue>) is a collection of Key-Value pairs.

//     Analogy: A Phone Book (Look up a Name → Get a Number).

//     Speed: It is the fastest data structure for lookups. Finding a key takes O(1) (instant) time, regardless of how big the list is.

//     Namespace: Requires using System.Collections.Generic;

// 2. Declaration & Basics
//     // Key is String (Country), Value is Integer (Population)
//     Dictionary<string, int> population = new Dictionary<string, int>();

//     // 1. ADDING DATA
//     population.Add("USA", 330);      // Throws error if "USA" already exists
//     population["India"] = 1400;      // Safe: Adds if new, Updates if exists

//     // 2. CHECKING EXISTENCE (Crucial!)
//     if (population.ContainsKey("Japan")) {
//         // Safe to proceed
//     }

//     // 3. REMOVING
//     population.Remove("USA"); // Returns true if it was found & removed

// 3. The "Safe Read" (TryGetValue)
//     Never just assume a key exists (e.g., int x = myDict["Key"]), or your app will crash. Use this pattern instead:

//     if (population.TryGetValue("Mars", out int popCount))
//     {
//         Console.WriteLine($"Population is {popCount}");
//     }
//     else
//     {
//         Console.WriteLine("Key not found.");
//     }

// 4. Looping
//     Use var to avoid typing long class names.

//     foreach (var item in population)
//     {
//         // item.Key is the Country
//         // item.Value is the Population
//         Console.WriteLine($"{item.Key}: {item.Value}");
//     }


using System;
namespace Module31_Dictionary
{
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter your string : ");
            string input = Console.ReadLine();

            Dictionary<char, int> charFreq = new Dictionary<char, int>();

            for(int i=0; i<input.Length; i++)
            {
                if(charFreq.ContainsKey(input[i]))
                {
                    charFreq[input[i]]++;
                }
                else
                {
                    charFreq.Add(input[i], 1);
                }
            }

            char maxChar = ' ';
            int maxVal = 0;
            foreach(var v in charFreq)
            {
                if(v.Value > maxVal)
                {
                    maxVal = v.Value;
                    maxChar = v.Key;
                }   
            }
            Console.WriteLine($"The character '{maxChar}' appears {maxVal} times!");
        }
    }
}