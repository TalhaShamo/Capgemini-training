using System.Collections.Generic;

namespace Module3_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cart = new List<string>();
            while (true)
            {
                string choice;
                Console.WriteLine("Add/Remove/Show/Exit :");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "Add":
                    string add;
                    Console.Write("Enter the item you wish to add: ");
                    add = Console.ReadLine();
                    cart.Add(add);
                    break;

                    case "Remove":
                    string remove;
                    Console.Write("Enter the item you wish to remove: ");
                    remove = Console.ReadLine();
                    cart.Remove(remove);
                    break;

                    case "Show":
                    Console.Write("Here are the items in your cart: ");
                    foreach(string s in cart)
                        {
                            Console.Write($"{s} ");
                        }
                    Console.WriteLine();
                    break;

                    case "Exit":
                    return;

                    default:
                    Console.WriteLine("Unknown Command!");
                    break;
                }
            }
        }
    }
}
