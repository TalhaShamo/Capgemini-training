using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace M1_StringQ2
{
    class Validator
    {
        public void ValidateGenerate(string username)
        {
            if(Regex.IsMatch(username, @"^[A-Z]{4}@1(0[1-9]|1[0-5])$"))
            {
                int sum = 0;
                for(int i=0; i<4; i++)
                {
                    char letter = username[i];
                    int asciiValue = (int)letter;
                    sum += asciiValue;
                }
                string lastTwo = username.Substring(6);
                string password = $"TECH_{sum}{lastTwo}";
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine($"{username} is an invalid username");
                return;
            }
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Validator val = new Validator();
            val.ValidateGenerate(username);
        }
    }
}