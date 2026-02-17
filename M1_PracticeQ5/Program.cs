using System;
using System.Text.RegularExpressions;
namespace M1_PracticeQ5;
class Program
{
    static void Main(string[] arg)
    {
        int n = int.Parse(Console.ReadLine());
        for(int i=0; i<n; i++)
        {
            string input = Console.ReadLine();
            if(Regex.IsMatch(input, @"^EMP-20\d{2}-[A-Z]{3}$"))
            {
                Console.WriteLine($"{input} is Valid");
            }
            else
            {
                Console.WriteLine($"{input} is Invalid");
            }
        }
    }
}