using System;
namespace M1_StringQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your string : ");
            string input = Console.ReadLine();

            // Note: Use single quotes ' ' for characters in Split
            string[] words = input.Split(' ');
            int length = words.Length;

            if (length % 2 != 0)
            {
                for (int i = 0; i < length; i++)
                {
                    char[] charArray = words[i].ToCharArray();
                    Array.Reverse(charArray);
                    words[i] = new string(charArray);
                }
            }
            else
            {
                Array.Reverse(words);
            }

            string finalResult = string.Join(" ", words);
            Console.WriteLine(finalResult);
        }
    }
}