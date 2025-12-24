// What is an Abstract Class? Think of it as a Skeleton.

//     It defines the basic structure (head, spine, ribs) that every body must have.

//     But it is incomplete. It has no muscles, skin, or eyes.

//     You cannot have a "living" Skeleton walking around by itself. (You cannot do new Skeleton()).

// Once you inherit an abstract class, the child class MUST override the abstract class and define it in their own way

using System;
using System.Dynamic;
namespace Module10_Abstraction
{
    class Program
    {
        //Abstract class declaration
        abstract class Shape
        {
            public string Color {get; set;}
            public Shape(string c)
            {
                Color = c;
            }
            //Abstract method declaration
            public abstract float GetArea();
            public void Display()
            {
                Console.WriteLine($"Color of the shape is {Color}");
            }
        }

        class Circle : Shape
        {
            public float radius {get; set;}
            public Circle(float r, string c) : base(c)
            {
                radius = r;
            }
            public override float GetArea() //We MUST override the abstract class inherited from parent otherwise it wont work.
            {
                return 3.14f*radius*radius;
            }
        }

        class Square : Shape
        {
            public float side {get; set;}
            public Square(float s, string c) : base(c)
            {
                side = s;
            }
            public override float GetArea()
            {
                return side*side;
            }
        }
        static void Main(string[] args)
        {
            float area;
            Square s = new Square(10f, "Red");
            area = s.GetArea();
            Console.WriteLine($"Area of Square - {area} with color {s.Color}");

            float circle;
            Circle c = new Circle(10f, "Green");
            area = c.GetArea();
            Console.WriteLine($"Area of Circle - {area} with color {c.Color}");
        }
    }
}