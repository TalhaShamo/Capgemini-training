using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Module4_Functions{
    class program
    {
        static void Main(string[] args)
        {
            string choice;
            Console.WriteLine("Calculate area of (a)Circle (b)Rectangle : ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                float r;
                Console.WriteLine("Enter the radius: ");
                r = float.Parse(Console.ReadLine());
                float ans = CircleArea(r);
                Console.WriteLine($"Area of circle: {ans}");
                break;

                case "b":
                float l, b;
                Console.WriteLine("Enter length and breadth: ");
                l = float.Parse(Console.ReadLine());
                b = float.Parse(Console.ReadLine());
                float area = RectangleArea(l, b);
                Console.WriteLine($"Area of reactangle: {area}");
                break;

                default:
                Console.WriteLine("Invalid input. Type either 'a' or 'b'");
                break;

            }
        }
        public static float CircleArea(float radius)
        {
            return 3.14f*radius*radius;
        }

        public static float RectangleArea(float length, float breadth)
        {
            return length*breadth;
        }
    }
}
