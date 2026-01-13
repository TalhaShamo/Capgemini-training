// 📝 Study Notes: LINQ (Language Integrated Query)
// 1. The Core Concept

// LINQ is a "Universal Adaptor" for data. It allows you to use one C# syntax to query data, no matter where that data lives 
// (Memory, SQL Database, XML, JSON).

//     Before LINQ: You needed different languages for Lists, SQL for Databases, XPath for XML.

//     With LINQ: You use the Standard Query Operators (Where, Select, etc.) for everything.

// 2. The Data Type: IEnumerable<T>

// This is the most important type in LINQ.

//     What is it? It is the "Grandparent" of all collections. Array, List, Queue, and Stack all inherit from IEnumerable. 
//     LINQ just happens to rely on it heavily because it is the most basic way to look at data.

//     The Difference:

//         List<T>: A warehouse. It holds actual items in RAM. Heavy.

//         IEnumerable<T>: A set of instructions. It knows how to find the next item, but it doesn't hold them all at once.

//     Why use it? It supports Deferred Execution (Laziness). When you write a query, it doesn't run. 
//     It only runs when you actually ask for the data (using foreach or .ToList()).

// 3. The var Keyword

// In LINQ, using var is almost mandatory.

//     What is it? Type Inference. The compiler figures out the type for you.

//     Is it "Dynamic"? NO. It is strongly typed. Once it figures it out, it cannot change.

//     Why is it necessary in LINQ?

//         LINQ methods return complex types that are painful to type manually.

//         Example: OrderBy returns IOrderedEnumerable<Student>.

//         Example: Select (Projection) returns IEnumerable<AnonymousType>.

//         Writing var keeps code clean and prevents errors.

// 4. The Standard Query Operators (The Methods)

// These are the methods used to manipulate data. You chain them together like a pipeline.
// A. Filtering (Where)

//     Role: The "Bouncer". Decides who gets in.

//     Input: A Predicate (x => x.Age > 18).

//     Returns: A smaller list.

// B. Sorting (OrderBy / OrderByDescending)

//     Role: The "Organizer".

//     Input: A Key Selector (x => x.Name).

//     Returns: The same list, re-arranged.

// C. Projection (Select)

//     Role: The "Transformer". Changes the shape of the data.

//     Input: A transformation (x => x.Name).

//     Returns: A list of something else (e.g., turning a list of Student objects into a list of string names).

// D. Execution (ToList / FirstOrDefault)

//     Role: The "Trigger".

//     Action: Forces the lazy query to execute IMMEDIATELY.

//     Use: When you need the results now (to return to a UI or save to a file).

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
namespace Module20_LINQ
{
    class Product
    {
        public string ProductName {get; set;}
        public decimal ProductPrice {get; set;}
        public Product(string Pname, decimal Pprice)
        {
            ProductName = Pname;
            ProductPrice = Pprice;
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            List<Product> cart = new List<Product>
            {
                new Product("Laptop", 1000), 
                new Product("Mouse", 20),
                new Product("Keyboard", 80),
                new Product("Monitor", 150),
                new Product("Mousepad", 10)
            };

            Console.WriteLine("Expensive Products: ");
            var expensiveItem = cart.Where(p => p.ProductPrice > 100);
            foreach(var p in expensiveItem)
            {
                Console.WriteLine($"{p.ProductName} - {p.ProductPrice}");
            }
            
            Console.WriteLine("Sorted Cart: ");
            var sortAscending = cart.OrderBy(p => p.ProductPrice);
            foreach(var p in sortAscending)
            {
                Console.WriteLine($"{p.ProductName} - {p.ProductPrice}");
            }
        }
    }
}