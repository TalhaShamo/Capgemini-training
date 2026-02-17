using System;
using System.Text;
namespace Practice_Q3
{
    class Program
    {
        static void Main(string[] arg)
        {
            string input = Console.ReadLine();
            StringBuilder filteredString = new StringBuilder();
            foreach(char c in input)
            {
                if (char.IsLetterOrDigit(c) || c == ' ')
                {
                    char lowChar = char.ToLower(c);
                    filteredString.Append(lowChar);
                }
            }
            string finalString = filteredString.ToString();
            string[] parts = finalString.Split(" ");

            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach(var v in parts)
            {
                if (wordFreq.ContainsKey(v))
                {
                    wordFreq[v]++;
                }
                else
                {
                    wordFreq.Add(v, 1);
                }
            }
            foreach(var v in wordFreq)
            {
                Console.WriteLine($"{v.Key} : {v.Value}");
            }
        }
        
    }
}