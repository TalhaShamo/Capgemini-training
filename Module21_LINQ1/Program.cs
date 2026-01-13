using System;
using System.Collections.Generic;
using System.Linq; // 👈 CRITICAL: Brings in the Extension Methods

namespace Module21_LINQ_Mastery
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. The Data Source (List stores data in RAM)
            List<Employee> staff = new List<Employee>
            {
                new Employee { Name = "Alice", Salary = 50000 },
                new Employee { Name = "Bob", Salary = 40000 },
                new Employee { Name = "Charlie", Salary = 90000 },
                new Employee { Name = "Dave", Salary = 30000 }
            };

            // This is the power of LINQ. We are able to pinpoint data without using if/else just like in SQL.
            // This code is also applicable with other languages like SQL,XML etc...
            var richEmployees = staff
                .Where(e => e.Salary > 45000)   // Filter: Keep rich people
                .OrderBy(e => e.Salary)         // Sort: Lowest of the rich to Highest
                .Select(e => e.Name);           // Transform: We only want Names (Strings)

            // ⚠️ AT THIS POINT, NO CODE HAS RUN YET!
            // 'richEmployees' is just an instruction set.

            Console.WriteLine("--- High Earners ---");

            // 3. The Execution
            // The loop forces the query to run.
            foreach (var name in richEmployees)
            {
                // 'name' is a string, because .Select() threw away the rest of the object
                Console.WriteLine(name);
            }
        }
    }
}