using System;
using System.Numerics;
namespace M1_InterfacesQ1
{
    class HotelRoom
    {
        public string roomType {get; set;}
        public double ratePerNight {get; set;}
        public string guestName {get; set;}

        public HotelRoom(string room, string name, double rate)
        {
            roomType = room;
            guestName = name;
            ratePerNight = rate;
        }

        public double calculateTotalBill(int nightsStayed, int joiningYear, double rate)
        {
            double TotalBill = nightsStayed * rate;
            if(calculateMembership(joiningYear) > 3)
            {
                TotalBill = TotalBill * 0.9;
            }
            return TotalBill;
        }

        public int calculateMembership(int joinedYear)
        {
            int membership = 2025 - joinedYear;
            return membership;
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Enter Deluxe Room Details");
            Console.Write($"Guest Name: ");
            string name1 = Console.ReadLine();

            Console.Write("Rate per Night: ");
            double rate1 = double.Parse(Console.ReadLine());

            Console.Write("Nights Stayed: ");
            int nights1 = int.Parse(Console.ReadLine());
            
            Console.Write("Joining Year: ");
            int join1 = int.Parse(Console.ReadLine());

            //-----
            
            Console.WriteLine("Enter Suite Room Details");
            Console.Write($"Guest Name: ");
            string name2 = Console.ReadLine();

            Console.Write("Rate per Night: ");
            double rate2 = double.Parse(Console.ReadLine());

            Console.Write("Nights Stayed: ");
            int nights2 = int.Parse(Console.ReadLine());
            
            Console.Write("Joining Year: ");
            int join2 = int.Parse(Console.ReadLine());
            

            HotelRoom guest1 = new HotelRoom("Deluxe Room", name1, rate1);
            HotelRoom guest2 = new HotelRoom("Suite Room", name2, rate2);


            Console.WriteLine("Room Summary:");
            Console.WriteLine($"Deluxe Room:{guest1.guestName}, {guest1.ratePerNight}, {guest1.calculateMembership(join1)}");
            Console.WriteLine($"Deluxe Room:{guest2.guestName}, {guest2.ratePerNight}, {guest2.calculateMembership(join2)}");

            Console.WriteLine("Total Bill: ");
            Console.WriteLine($"For {guest1.guestName} (Deluxe): {guest1.calculateTotalBill(nights1, join1, rate1)}");
            Console.WriteLine($"For {guest2.guestName} (Suite): {guest2.calculateTotalBill(nights2, join2, rate2)}");
        }
    }
}