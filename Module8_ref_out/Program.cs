// By default, C# uses pass by value. It passes simple types (int, bool, double) by Value (a photocopy). If the method changes the copy, 
// the original in Main is safe. ref and out break this rule. They allow a method to reach out and modify the Original Variable.

// 1. ref (Reference) - Basically Call by reference
// The Concept: A Two-Way Street (Read & Write). You pass an existing variable into the method. 
// The method can read its current value, modify it, and when the method ends, the original variable is changed.

// 2. out (Output)
// The Concept: A One-Way Exit (Write Only). You pass an empty "container" into the method. 
// The method ignores whatever was in there and promises to fill it with new data.
//     Use Case: Returning multiple values (e.g., DidLoginSucceed (bool) AND ErrorMessage (string)).

using System;
using System.Linq.Expressions;

namespace Module8_ref_out
{
    class ServerUtils
    {
        //By adding ref it is the same as int& x in C++
        public static void ServerSwap(ref string serverA, ref string serverB) 
        {
            string temp = serverB;
            serverB = serverA;
            serverA = temp;
        }
        
        //So even tho the return is a boolean. We get to have another output string msg using out keyword.
        public static bool ValidateUser(string user, string pass, out string msg)
        {
            if(user == "admin" && pass == "1234")
            {   
                msg = "Welcome!";
                return true;
            }
            else
            {
                msg = "Bad pass";
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Primary", s2 = "Backup";
            ServerUtils.ServerSwap(ref s1, ref s2); //Unlike CPP we have to write ref here as well
            Console.WriteLine($"Servers swapped : s1 = {s1}  s2 = {s2}");

            bool result;
            string message;
            result = ServerUtils.ValidateUser("admin", "111", out message); //Have to write out here as well to get the message
            Console.WriteLine(message);
            result = ServerUtils.ValidateUser("admin", "1234", out message);
            Console.WriteLine(message);

        }
    }
}
