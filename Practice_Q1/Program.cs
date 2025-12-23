//Question Statement -

// Sam is planning to buy a laptop or a computer from Bejoy Computers. The final price of the selected device will depend on the 
// type of processor and any additional accessories added to the purchase. To facilitate this process, an application will be 
// used to gather input from the user regarding their preferred processor type and accessories, and subsequently calculate the 
// total price of the selected device. Help them to create an application using your C# coding skills.Functionalities:
// In class Computer, implement the below-given properties.
//     Data Type
//    Property Name
//     string
//   Processor
//     int
//   RamSize
//     int
//   HardDiskSize
//     int
//   GraphicCardIn class Desktop, implement the below-given properties and method and also inherit the class Computer.    Data Type
//    Property Name
//     int
//   MonitorSize
//     int
//   PowerSupplyVolt    Method
//    Description
//    public double DesktopPriceCalculation()
//  This method is used to calculate the price of the desktop and return it.
// To calculate the price of the desktop, the processor and other accessories prices are given below.In class Laptop, 
// implement the below-given properties and method and also inherit the class Computer.    Data Type
//    Property Name
//     int
//   DisplaySize
//     int
//   BatteryVolt    Method
//    Description
//    public double LaptopPriceCalculation()
//  This method is used to calculate the price of the laptop and return it.
// To calculate the price of the laptop, the processor and other accessories prices are given below.
// Formula 1: Desktop Price = Processor Cost + (RamSize * Ram Price) + (HardDiskSize * Hard Disk Price) + (GraphicCard * Graphic Card Price) + (MonitorSize * Monitor Price) + (PowerSupplyVolt * Power Supply Volt Price);    
// Processor
//    Processor Cost
//     i3
//   1500
//     i5
//   3000
//     i7
//   4500   Ram price (per GB)
//   Hard disk (per TB)
//   Graphic Card (per GB)
//   Power supply (per Volt)
//   Monitor (per inch)
//     200
//    1500
//    2500
//    20
//  250 
//  Formula 2: Laptop Price = Processor Cost + (RamSize * Ram Price) + (HardDiskSize * Hard Disk Price) + (GraphicCard * Graphic Card Price) +
//   (Display Size* Display Price) + (BatteryVolt * Battery Volt Price);    Processor
//    Processor Cost
//     i3
//   2500
//     i5
//   5000
//     i7
//   6500  Ram price (per GB)
//   Hard disk (per TB)
//  Graphic Card (per GB)
//  Battery(per Volt)
//  Display(per inch)
//     200
//    1500
//    2500
//    20
//  250Note:
// Processor is Case-sensitive.In Program class - Main method,
// 1.    Get the values from the user as per the Sample Input.
// 2.    Call the methods accordingly and display the result as per the Sample Output.Note:
// Keep the properties, methods and classes as public.
// Please read the method rules clearly.

//     Do not use Environment.Exit() to terminate the program.
//     Do not change the given code template. 

// Summary :
// Through creating this application, they have learned about Inheritance in C#.
// Inheritance is a mechanism in object-oriented programming that allows a class to inherit properties and behaviors from a 
// parent class, thus avoiding code duplication and promoting code reuse.Sample Input 1:
// 1.Desktop
// 2.Laptop
// Choose the option
// 1
// Enter the processor
// i3
// Enter the ram size
// 8
// Enter the hard disk size
// 32
// Enter the graphic card size
// 32
// Enter the monitor size
// 22
// Enter the power supply volt
// 240
// Sample Output 1:
// Desktop price is 141400Sample Input 2:
// 1.Desktop
// 2.Laptop
// Choose the option
// 2
// Enter the processor
// i7
// Enter the ram size
// 16
// Enter the hard disk size
// 32
// Enter the graphic card size
// 22
// Enter the display size
// 13
// Enter the battery volt
// 240
// Sample Output 2:
// Laptop price is 120750

using System;

namespace Practise_Q1
{
    class Computer
    {
        public string Processor;
        public int RamSize, HardDiskSize, GraphicCard;
        public Computer(string P, int R, int H, int G)
        {
            Processor = P;
            RamSize = R;
            HardDiskSize = H;
            GraphicCard = G;
        }
    }
    class Desktop : Computer
    {
        public int MonitorSize, PowerSupplyVolt;
        public Desktop(string P, int R, int H, int G, int M, int Pow) : base(P, R, H, G)
        {
            MonitorSize = M;
            PowerSupplyVolt = Pow;
        }
        public double DesktopPriceCalculation()
        {
            int ProcessorPrice = 0;
            if(Processor == "i3") ProcessorPrice = 1500;
            else if(Processor == "i5") ProcessorPrice = 3000;
            else if(Processor == "i7") ProcessorPrice = 4500;

            double DesktopCost = ProcessorPrice + (RamSize*200) + (HardDiskSize*1500) + (GraphicCard*2500) + (MonitorSize*250) + (PowerSupplyVolt*20);

            return DesktopCost;
        }
    }
    
    class Laptop : Computer
    {
        public int DisplaySize, BatteryVolt;
        public Laptop(string P, int R, int H, int G, int D, int B) : base(P, R, H, G)
        {
            DisplaySize = D;
            BatteryVolt = B;
        }
        public double LaptopPriceCalculation()
        {
            int ProcessorPrice = 0;
            if(Processor == "i3") ProcessorPrice = 2500;
            else if(Processor == "i5") ProcessorPrice = 5000;
            else if(Processor == "i7") ProcessorPrice = 6500;

            double LaptopCost = ProcessorPrice + (RamSize*200) + (HardDiskSize*1500) + (GraphicCard*2500) + (DisplaySize*250) + (BatteryVolt*20);

            return LaptopCost;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            Console.WriteLine("Select (a) Desktop (b) Laptop: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "Desktop":
                string proc;
                int ram, harddisk, graphics, monitor, power;
                Console.WriteLine("Enter Processor, RamSize, HardDiskSize, GraphicsCard, MonitorSize and PowerSupplyVoltage in order : ");
                proc = Console.ReadLine();
                ram = int.Parse(Console.ReadLine());
                harddisk = int.Parse(Console.ReadLine());
                graphics = int.Parse(Console.ReadLine());
                monitor = int.Parse(Console.ReadLine());
                power = int.Parse(Console.ReadLine());
                Desktop d1 = new Desktop(proc, ram, harddisk, graphics, monitor, power);
                double DesktopPrice = d1.DesktopPriceCalculation();
                Console.WriteLine($"Price of your Desktop is - ${DesktopPrice}");
                break;

                case "Laptop":
                string Proc;
                int Ram, Harddisk, Graphics, Display, Battery;
                Console.WriteLine("Enter Processor, RamSize, HardDiskSize, GraphicsCard, DisplaySize and BatteryVoltage in order : ");
                Proc = Console.ReadLine();
                Ram = int.Parse(Console.ReadLine());
                Harddisk = int.Parse(Console.ReadLine());
                Graphics = int.Parse(Console.ReadLine());
                Display = int.Parse(Console.ReadLine());
                Battery = int.Parse(Console.ReadLine());
                Laptop l1 = new Laptop(Proc, Ram, Harddisk, Graphics, Display, Battery);
                double LaptopPrice = l1.LaptopPriceCalculation();
                Console.WriteLine($"Price of your Desktop is - ${LaptopPrice}");
                break;

                default:
                Console.WriteLine("Wrong Option! Enter either Laptop or Desktop");
                break;
            }
        }
    }
}