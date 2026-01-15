// Study Notes: Reflection (Part 1 - Inspection)
// 1. What is Reflection?

// Normally, when you write code (Car c = new Car();), you know exactly what the class is. This is called Early Binding.

// Reflection allows your code to inspect itself at runtime. It is like an "X-Ray" machine for your code. It allows you to 
// take an unknown object (a "Black Box") and ask:

//     "What Class are you?"

//     "What Methods do you have?"

//     "What Properties (variables) do you have?"

// Analogy:

//     Normal Code: You built the car, so you know how to drive it.

//     Reflection: You found a UFO. You have to scan it to figure out where the door is and how to turn it on.

// 2. Why do we need it? (The "Reverse Engineering" Tool)

//     Inspect Unknown DLLs: If you download a library written by someone else, Reflection lets you see what code is inside 
//     without having the source files.

//     Extensibility: It allows programs to load "Plugins" dynamically. (e.g., A game finding all "Mod" files and loading them).

//     Testing: It is how Unit Test frameworks (like NUnit) find your test methods.

// 3. The Master Key: System.Type

// In C#, every object has a "Shadow" called its Type. This holds all the metadata (Blueprints). To use Reflection, you must 
// first get this Type object.

// Now how to get this metadata :
// // Method A: If you know the class name while coding
// Type t1 = typeof(Student);

// // Method B: If you only have an object instance (Runtime)
// Student s = new Student();
// Type t2 = s.GetType();

// 4. The Toolkit: Inspection Methods

// Once you have the Type t, you can unlock the class secrets using these methods from the System.Reflection namespace.

// A. Basic Info

//     t.Name: The name of the class (e.g., "Rocket").

//     t.Namespace: The folder/namespace it lives in (e.g., "Module25").

// B. Inspecting Data (Properties)

//     t.GetProperties(): Returns an array of PropertyInfo[].

//     Each PropertyInfo has:

//         .Name: The variable name (e.g., "Fuel").

//         .PropertyType: The data type (e.g., "System.Int32").

// C. Inspecting Logic (Methods)

//     t.GetMethods(): Returns an array of MethodInfo[].

//     Each MethodInfo has:

//         .Name: The function name (e.g., "Launch").

//         .ReturnType: What it sends back (e.g., "void").

//         .DeclaringType: The class where it was actually written.

using System;
using System.ComponentModel;
using System.Reflection;
namespace Module25_Reflection
{
    class Rocket
    {
        public string Model {get; set;}
        public int Fuel {get; set;}
        public Rocket(string m, int f)
        {
            Model = m;
            Fuel = f;
        }
        public void Launch()
        {
            Console.WriteLine("Rocket Launching.....");
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            // Imagine this object came from a database or a file. We pretend we dont know what is inside it
            Rocket V12 = new Rocket("SovietV12", 100);

            // First we get the class type (Getting the metadata)
            Type t = V12.GetType();
            Console.WriteLine($"Class Name : {t.Name}");

            // Inspecting Properties 
            PropertyInfo[] props = t.GetProperties();
            Console.WriteLine("Properties inside class V12 : ");
            foreach(var p in props)
            {
                Console.WriteLine($"{p.Name} - {p.PropertyType.Name}");
            }

            // Inspecting Methods
            MethodInfo[] methods = t.GetMethods();
            Console.WriteLine("Methods inside class V12: ");
            foreach(var m in methods)
            {
                // With the filter (m.DeclaringType == t): You are asking: "Only show me methods that were created inside the 
                // Rocket class itself. Ignore the stuff inherited from parents."
                if(m.DeclaringType == t) 
                {
                    Console.WriteLine($"{m.Name}");
                }
            }

            
        }
    }
}