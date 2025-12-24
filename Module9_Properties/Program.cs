//Properties Notes :
// What is a Property? It looks like a variable, but it acts like a security guard. It is a "Smart Field" that lets you control 
// how data is read (get) and written (set).

// The Golden Rule: In professional C#, never make a variable (field) public. Always use a Property.
// 1. Why do we need properties? (The 3 Superpowers)

//     Validation (The Bouncer): You can stop bad data from entering your object.

//         Example: "You cannot set Health to -500."

//         Example: "You cannot set Name to an empty string."

//     Read-Only Access (The Glass Case): You can let the world see the data, but only let the class touch it.

//         Example: Balance. You can check your bank balance, but you can't just write a new number on the screen.

//     Triggers (The Tripwire): You can make things happen automatically when a value changes.

//         Example: "When Health drops below 20, automatically turn the screen red."

using System;
namespace Module9_Properties
{
    class BankAccount
    {
        public decimal Balance {get; private set;} //This is a property. NOT a variable.
        public void Deposit(decimal amount) //decimal is a C# variable used for Money related operations. They are much more accurate than flaot or double
        {
            if(amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Amount added");
            }
            else
            {
                Console.WriteLine("Negative amount cannot be added!");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAcc = new BankAccount();
            Console.WriteLine($"You Balance : {myAcc.Balance}");
            //We cannot write myacc.Balance = 10000 to update balance. It would give an error. But in the case of a normal public variable we can! 
            // This is a huge security vulnerability and this is why we use properties insteadof public variables.

            //We call the setter for the property to safely update balance.
            myAcc.Deposit(-200m); //m for money for decimal variable. Just like f for float
            myAcc.Deposit(6000);
            Console.WriteLine($"You Balance : {myAcc.Balance}");
        }
    }
}