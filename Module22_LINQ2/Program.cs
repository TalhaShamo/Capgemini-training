// 📝 Study Notes: LINQ Precision Operators
// 1. The Searcher: FirstOrDefault()

// What is it? Finds the single specific item that matches your condition.

// Do not user First():

//     First(): If it finds nothing, it throws an Exception and crashes your app.

//     FirstOrDefault(): If it finds nothing, it returns null (or 0 for numbers).

// The Workflow:

//     Scans the list until it finds a match.

//     Stops looking immediately.

//     Returns that object.

//     Crucial Step: You must check if the result is null before using it.

// 2. The Scanner: Any()

// What is it? Checks if something exists. It returns a simple bool (True/False).

// The Performance Boost:

//     Bad Way (List.Count > 0): Counts every single item (1, 2, ... 10,000) just to tell you the list isn't empty.

//     Good Way (List.Any()): Peeks at the first item. If it sees one, it returns true and stops. Instant.

// Two Modes:

//     Empty Check: list.Any() -> Is the list not empty?

//     Condition Check: list.Any(x => x > 10) -> Does at least one item match this rule?

// 3. The Inspector: All

// What is it? Validates that every single item in the list follows a rule.

// The Rule:

//     If one item fails, All immediately returns false.

//     It only returns true if every single item passes.

// Use Case: Data Integrity. (e.g., "Do all users have a valid email address?")

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
namespace Module22_LINQ2
{
    class User
    {
        public string Name {get; set;}
        public string Password {get; set;}
        public User(string n, string p)
        {
            Name = n;
            Password = p;
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            List<User> users = new List<User>
            {
                new User("Alok", "6578"),
                new User("Ed", ""),
                new User("Saleema", "4444"),
                new User("Admin", "1234")
            };

            var admin = users.FirstOrDefault(u => u.Name == "Admin" && u.Password == "1234");
            if(admin != null)
            {
                Console.WriteLine($"Found admin : {admin.Name}");
            }
            else
            {
                Console.WriteLine("No admin found!");
            }

            var hasNoPassword = users.Any(u => u.Password == "");
            if (hasNoPassword)
            {
                Console.WriteLine("Someone has not set a password");
            }

            var allNamesValid = users.All(u => u.Name.Length >= 3);
            Console.WriteLine($"All names have more than 3 characters? {allNamesValid}");
        }
    }
}