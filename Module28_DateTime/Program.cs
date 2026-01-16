using System;
using System.Diagnostics;
using System.Net.Mail;
namespace Module28_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Date with time
            DateTime rightNow = DateTime.Now;
            Console.WriteLine(rightNow);

            //Date only
            DateTime justDate = DateTime.Today;
            Console.WriteLine(justDate);

            //Creating a specific date
            DateTime christmas = new DateTime(2025, 12, 25);
            Console.WriteLine($"Christmas is on : {christmas}");

            //Extracting information
            Console.WriteLine($"Day : {christmas.Day}");
            Console.WriteLine($"DayOfWeek : {christmas.DayOfWeek}");
            Console.WriteLine($"Month : {christmas.Month}");

            //Formatting
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString("MM/dd/yyyy"));
            Console.WriteLine(dt.ToString("dd-MMM-yy"));
            Console.WriteLine(dt.ToString("dddd, MMM dd"));

            //Modifying Dates
            // Dates are immutable so in order to update them we have to actually make new variable to store them
            DateTime futureDate = dt.AddHours(5);
            DateTime pastDate = dt.AddYears(-1);
            Console.WriteLine($"5 hours into the future is {futureDate}");
            Console.WriteLine($"1 year in the past was a {pastDate.DayOfWeek}");

            //Subtracting Dates
            DateTime today = DateTime.Now;
            DateTime bday = new DateTime(1999, 12, 15);
            TimeSpan age = today - bday; //Important to use TimeSpan and not DateTime
            Console.WriteLine($"How long have I been alive? {age}");

        }
    }
}