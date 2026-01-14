// Study Notes: Regular Expressions (Regex)
// 1. Why do we need Regex?

// Standard string methods (Contains, StartsWith, IndexOf) are dumb. They only look for exact text.

//     Contains("User") finds "User", but it fails if the user types "user" (lowercase) or "User123".

// Regex is "Pattern Matching". Instead of searching for specific text, you search for a Rule.

//     "Find anything that looks like an email."

//     "Find exactly 3 digits followed by a dash."

//     "Ensure the password has at least one number."

// 2. The Regex Engine (System.Text.RegularExpressions)

// In C#, we use the Regex.IsMatch() method.

// Important: Always put the @ symbol before your pattern string (e.g., @"pattern").

//     Without @: C# thinks \ is a special code (like \n for newline). You would have to double-escape everything (\\d).

//     With @: C# reads the string literally, making regex much cleaner (\d).

// 3. The Symbol Cheat Sheet

// A. The Anchors (Locking the position)

//     ^ : Start of Line. (Matches "Hello" in "Hello World")

//     $ : End of Line. (Matches "World" in "Hello World")

//     Why use them? Without anchors, \d{3} would match "123" inside "User123456". Anchors force the entire string to match.

// B. The Character Types (What to look for)

//     . : Wildcard. Matches ANY single character (Letter, number, symbol, space).

//     \d : Digit. Matches 0-9.

//     \w : Word Character. Matches Letters (A-Z, a-z), Numbers (0-9), and Underscores (_). It does NOT match symbols ($, @, .).

//     \s : Whitespace. Matches spaces, tabs, or newlines.

// C. The Quantifiers (How many times?)

//     * : Zero or more. (Matches "" or "A" or "AAAA")

//     + : One or more. (Matches "A" or "AAAA", but NOT "")

//     ? : Zero or One (Optional). (Matches "Color" or "Colour")

//     {n} : Exactly n times. (\d{4} matches "2025")

//     {min,max} : Range. (\w{5,15} matches a username between 5 and 15 chars).

// D. The Escapes (Finding real symbols)

//     \ : If you need to find a character that is also a regex command (like ., +, *, ?), you must put a backslash in front of it.

//     Example: To find a literal dot in an email, use \.

// 4. Custom Character Sets: Square Brackets []

// You asked about Square Brackets. These are used to create a "Pick List". If \w is too broad (allows numbers and underscores) 
// and you ONLY want letters, use [].

// How they work: Match ONE character from the list inside.

//     [ABC] : Matches "A" or "B" or "C".

//     [A-Z] : Matches any Uppercase letter.

//     [a-z] : Matches any Lowercase letter.

//     [0-9] : Matches any digit (Same as \d).

//     [A-Za-z] : Matches any letter (Case insensitive).

// Example: A strict name validator (No numbers allowed)

//     Pattern: ^[A-Za-z]+$

//     Explanation: Start ^, Match letters from the list [A-Za-z], One or more times +, End $.

// Negative Sets [^] If you put a ^ inside the bracket, it means "NOT these".

//     [^0-9] : Match anything that is NOT a number.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
namespace Module24_Regex
{
    class Validator
    {
        public void ValidateUsername(string username)
        {
            if(Regex.IsMatch(username, @"^\w{5,15}$"))
            {
                Console.WriteLine("Username is Ok!");
            }
            else
            {
                Console.WriteLine("Invalid Username! Username must be Alphanumeric with atleast 5 characters and at most 15 characters.");
            }
        }
        public void ValidateEmail(string email)
        {
            if(Regex.IsMatch(email, @"^\w+@\w+\.\w{3}")) // w+ means one or more alphanumeric characters
            {
                Console.WriteLine("Email is Ok!");
            }
            else
            {
                Console.WriteLine("Email is Invalid! Write in this format - user@example.com");
            }
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();

            Validator check = new Validator();
            check.ValidateUsername(username);
            check.ValidateEmail(email);
        }
    }
}