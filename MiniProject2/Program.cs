using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
namespace MiniProject2
{
    class Product
    {
        public string ProdName {get; set;}
        public decimal ProdCost {get; set;}
        public Product(string PName, decimal PCost)
        {
            ProdName = PName;
            ProdCost = PCost;
        }
    }
    class VendingMachine 
    {
        public List<Product> Inventory = new List<Product>();
        public int Quarter;
        public int Dime;
        public int Nickel;
        public int Penny;
        public void AddItem(string name, decimal cost)
        {
            Inventory.Add(new Product(name, cost));
            Console.WriteLine($"{name} added!");
        }
        public void ShowItem()
        {
            foreach(Product item in Inventory)
            {
                Console.WriteLine($"{item.ProdName} : ${item.ProdCost}");
            }
        }
        public void BuyItem(string name, decimal amount)
        {
            foreach(Product item in Inventory)
            {
                if(name == item.ProdName)
                {
                    if(item.ProdCost <= amount)
                    {
                        decimal change = amount - item.ProdCost;
                        Console.WriteLine($"Dispensing {name}...");
                        Console.WriteLine($"Your change is {change}");
                        Inventory.Remove(item);
                        return; //There is a hidden danger here. In C#, if you try to Remove an item inside a foreach loop, 
                        // the program will usually crash with an error: "Collection was modified; enumeration operation may not 
                        // execute. Why? Because the loop loses its place if you delete the floor it's standing on.
                    }
                    else
                    {
                        Console.WriteLine("Not enough money!");
                        return;
                    }
                }
            }
            Console.WriteLine("Item not available");
            return;
        }
        public void AddCurrency(int quarters, int dime, int nickels, int penny)
        {
            Quarter = quarters;
            Dime = dime;
            Nickel = nickels;
            Penny = penny;

            Console.WriteLine("Currency successfully added!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine();
            Console.WriteLine("Vending Machine System Loading......");
            Thread.Sleep(2000);
            Console.WriteLine("System Online -");
            bool exit = false;
            Thread.Sleep(1000);

            while (!exit)
            {
                Console.WriteLine("1. Buy Item (Press 1)");
                Console.WriteLine("2. Stock Item (Press 2)");
                Console.WriteLine("3. Stock Currency (Press 3)");
                Console.WriteLine("4. Exit (Press 4)");

                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.WriteLine("Items available : ");
                    vm.ShowItem();
                    Console.WriteLine("What would you like to buy? ");
                    string itemName = Console.ReadLine();
                    Console.WriteLine("Insert amount : ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    vm.BuyItem(itemName, amount);
                }

                else if(choice == "2")
                {
                    Console.WriteLine("Enter Authorization code : ");
                    string authCode = Console.ReadLine();
                    if(authCode == "password")
                    {
                        Console.WriteLine("Name of item : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Cost of item : ");
                        decimal cost = decimal.Parse(Console.ReadLine());
                        vm.AddItem(name, cost);
                    }
                    else
                    {
                        Console.WriteLine("Wrong code!");
                    }
                }
                
                else if(choice == "3")
                {
                    Console.Write("Enter number of Quarters you wish to add - ");
                    int quarters = int.Parse(Console.ReadLine());

                    Console.Write("Enter number of Dime you wish to add - ");
                    int dime = int.Parse(Console.ReadLine());

                    Console.Write("Enter number of Nickels you wish to add - ");
                    int nickels = int.Parse(Console.ReadLine());

                    Console.Write("Enter number of Penny you wish to add - ");
                    int penny = int.Parse(Console.ReadLine());

                    vm.AddCurrency(quarters, dime, nickels, penny);
                }

                else if(choice == "4")
                {
                    exit = true;
                    Console.WriteLine("Exiting system.....");
                    Thread.Sleep(2000);
                }
                
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
            Console.WriteLine("Exited successfully");
        }
    }
}