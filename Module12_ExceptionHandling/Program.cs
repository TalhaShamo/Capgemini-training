using System;
using System.ComponentModel;
namespace Module12_ExceptionHandling
{
    class Item
    {
        public string Name;
        //Default Constructor
        public Item()
        {
            Name = "Unknown Item";
        }
        // Parametrized Constructor
        public Item(string n)
        {
            Name = n;
        }
    }
    class Inventory
    {
        public List<Item> myInventory = new List<Item>(); //This is a list of objects from class Item.
        public void GetMethod(int index)
        {
            try
            {
                Item listItem = myInventory[index];
                Console.WriteLine($"Your Item : {listItem.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong!");
                Console.WriteLine($"Error - {ex}");
            }
            finally
            {
                Console.WriteLine("This block runs regardless of the outcome of both try and catch blocks");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("Sword"); //Using the parameterized contructor
            Item item2 = new Item(); //Using the default constructor

            Inventory cart = new Inventory();
            cart.myInventory.Add(item1);
            cart.myInventory.Add(item2);

            cart.GetMethod(1);
            cart.GetMethod(10);
        }
    }
}