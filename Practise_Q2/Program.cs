// Q2 Convert feet to centimetre

using System;
using System.Security.Cryptography.X509Certificates;
namespace Practise_Q2
{
    class Conversion
    {
        private double _feet; // Underscore before variable is a naming convention used for private variables
        public double Feet
        {
            get
            {
                return _feet;
            }
            set
            {
                // 'value' is the number the user is trying to set
                if(value < 0)
                {
                    Console.WriteLine("Height cannot be negative");
                    _feet = 0;
                }
                else
                {
                    _feet = value;
                }
            }
        }
        public Conversion(double f)
        {
            Feet = f;
        }
        public double Feet_to_Centimetre()
        {
            double centimetre = Math.Round(_feet*30.48, 2, MidpointRounding.AwayFromZero); //Important
            return centimetre;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double feet;
            Console.WriteLine("Enter feet: ");
            feet = double.Parse(Console.ReadLine());
            Conversion cm = new Conversion(feet);
            double centimetre = cm.Feet_to_Centimetre();
            Console.WriteLine($"{feet} feet = {centimetre} centimeters");
        }
    }
}