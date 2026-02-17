using System;
namespace M1_PracticeQ1
{
    class Product
    {
        public string productName {get; set;}
        public decimal productPrice {get; set;}
        public int productCount {get; set;}

        public Product(string prodN, decimal prodP, int prodC)
        {
            productName = prodN;
            productCount = prodC;
            productPrice = prodP;
        }
    }
    class VendingMachine
    {
        List<Product> Inventory = new List<Product>();
        public decimal Balance {get; set;}
        
        public void AddProduct(Product p)
        {
            Inventory.Add(p);
        }

        public void AddBalance(decimal bal)
        {
            Balance += bal;
        }

        public void BuyProduct(string prodName)
        {
            foreach(var v in Inventory)
            {
                if(v.productName == prodName)
                {
                    if(v.productCount == 0)
                    {
                        Console.WriteLine("Stock Finished!");
                        Environment.Exit(0);
                    }
                    else if(Balance < v.productPrice)
                    {
                        Console.WriteLine("Insufficient Balance!");
                        return;
                    }
                    Balance = Balance - v.productPrice;
                    v.productCount--;
                    Console.WriteLine($"Purchased {v.productName}, Balance {Balance}");
                    return;
                }
            }
            Console.WriteLine("This product does not exist in the vending machine");
            return;
        }
    }

    class Program
    {
        static void Main(string[] arg)
        {
            int n = int.Parse(Console.ReadLine());

            VendingMachine vm = new VendingMachine();

            for(int i=0; i<n; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                string prodName = parts[0];
                decimal prodPrice = decimal.Parse(parts[1]);
                int prodCount = int.Parse(parts[2]);

                Product newProduct = new Product(prodName, prodPrice, prodCount);
                vm.AddProduct(newProduct);
            }

            bool flag = true;
            while (flag)
            {
                string choice = Console.ReadLine();
                string[] split = choice.Split(' ');

                int Intchoice = int.Parse(split[0]);
                
                if(Intchoice == 1)
                {
                    int bal = int.Parse(split[1]);
                    vm.AddBalance(bal);
                }
                else if(Intchoice == 2)
                {
                    string prod = split[1];
                    vm.BuyProduct(prod);
                }
                else if(Intchoice == 3)
                {
                    Console.WriteLine("Thank You");
                    flag = false;
                }
            }
        }
    }
}