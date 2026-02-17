// using System;
// namespace M1_PracticeQ2
// {
//     class Program
//     {
//         static void Main(string[] arg)
//         {
//             string input = Console.ReadLine();
//             List<char> charList = new List<char>();

//             foreach(var v in input)
//             {
//                 if (char.IsLetterOrDigit(v))
//                 {
//                     charList.Add(char.ToUpper(v));
//                 }
//             }
//             if(charList.Count < 2)
//             {
//                 Console.WriteLine("Invalid input");
//                 return;
//             }
//             char temp = charList[0];
//             charList[0] = charList[charList.Count - 1];
//             charList[charList.Count - 1] = temp;

//             charList.Reverse();

//             char[] charArray = charList.ToArray();

//             string result = new string(charArray);

//             Console.WriteLine(result);
//         }
//     }
// }

using System;
using System.Collections.Generic;

namespace M1_PracticeQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter word1:");
            string word1 = Console.ReadLine();

            Console.WriteLine("Enter word2:");
            string word2 = Console.ReadLine();

            Dictionary<char, int> inventory = new Dictionary<char, int>();

            foreach (char c in word2)
            {
                if (inventory.ContainsKey(c))
                {
                    inventory[c]++;
                }
                else
                {
                    inventory.Add(c, 1);
                }
            }

            int deletionsCount = 0;

            foreach (char c in word1)
            {
                if (inventory.ContainsKey(c) && inventory[c] > 0)
                {
                    inventory[c]--;
                }
                else
                {
                    deletionsCount++;
                }
            }

            // 4. Output the result
            Console.WriteLine(deletionsCount);
        }
    }
}