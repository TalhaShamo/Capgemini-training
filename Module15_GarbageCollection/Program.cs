// "Garbage Collection" is a theoretical concept often an interview favorite because it tests if you understand what happens 
// under the hood of your code.

// Since you know C++, this will be fascinating for you. In C++, you had to manually delete objects (delete ptr). If you forgot,
// you got a Memory Leak. In C#, you never write delete. Why? Because of the Garbage Collector (GC).

// 🗑️ What is the Garbage Collector?

// The GC is an automatic memory manager running in the background. Think of it as a Roomba for your RAM.

//     Your Job: Create objects (new Book()). Throw them around.

//     GC's Job: Watch your memory. When an object is no longer being used by anyone, the GC sweeps it up and frees the memory.

// ⚙️ How It Works: The "Generations" Algorithm

// The GC doesn't just scan everything every time (that would be slow). It uses an algorithm based on Generations. 
// It assumes: "New objects die young, old objects live forever."

// It divides the Managed Heap (memory) into 3 buckets:

//     Generation 0 ( The Nursery):

//         Who lives here: Every brand new object you create starts here.

//         Collection Frequency: Very High (Runs constantly).

//         Behavior: Most temporary variables (like loop counters or temp strings) die here instantly. The GC wipes them out fast.

//     Generation 1 (The Buffer):

//         Who lives here: Survivors of Generation 0.

//         Collection Frequency: Medium.

//         Behavior: If an object survives a Gen 0 cleanup, it gets promoted to Gen 1. It's a "mid-life" object.

//     Generation 2 (The Elderly):

//         Who lives here: Survivors of Generation 1.

//         Collection Frequency: Very Low (Rare).

//         Behavior: These are long-term objects (like your static VendingMachine or a DatabaseConnection). The GC rarely checks 
//         these because checking them is expensive.





















using System;
namespace Module15_GarbageCollection
{
    class Employee
    {
        public string ID;
        public double Salary;
        public Employee(string id, int sal)
        {
            ID = id;
            Salary = sal;
        }
        public void display()
        {
            Console.WriteLine($"EmployeeID - {ID}, Salary - {Salary}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("12212341", 15000);
            emp.display();
        }
    }
}