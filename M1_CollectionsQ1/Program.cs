using System;
using System.Text;
namespace M1_CollectionsQ1
{
    class Program
    {
        static void Main(string[] arg)
        {   
            Dictionary<string, double> cakes = new Dictionary<string, double>();

            Console.WriteLine("Enter the number of cake orders to be added");
            int orderQuantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cake Order Details (OrderID:CakeCost)");
            for(int i=0; i<orderQuantity; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(':');

                string OrderID = parts[0];
                double CakeCost = double.Parse(parts[1]);

                if (cakes.ContainsKey(OrderID))
                {
                    cakes[OrderID] = CakeCost;
                }
                else
                {
                    cakes.Add(OrderID, CakeCost);
                }
            }

            Console.WriteLine("Enter the cost to search cake orders");
            double minCakeCost = double.Parse(Console.ReadLine());
            bool found = false;
            Console.WriteLine("Cake Orders above the specified cost");
            foreach(var v in cakes)
            {
                if(v.Value > minCakeCost)
                {
                    Console.WriteLine($"OrderID:{v.Key}, Cake Cost:{v.Value}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No cake orders found");
            }
        }
    }
}