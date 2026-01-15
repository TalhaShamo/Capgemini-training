// Study Notes: Reflection (Part 2 - Late Binding)
// 1. What is Late Binding?

// Early Binding is what you do every day: Dog d = new Dog();. The compiler knows exactly what the object is before the program runs.

// Late Binding is creating an instance of a class when you do not know its name until the program is actually running (Runtime).

//     Example: Reading a class name from a text file, a database, or user input.

// 2. The Logic Flow

// To achieve this, we follow a 3-step chain: String -> Type -> Object

// Step 1: The Input You start with a simple string representing the class name.

//     Important: This string must be the Fully Qualified Name (Namespace + Dot + ClassName).

//     Example: "Module26.Dog" (Just "Dog" will fail because C# won't know where to look).

// Step 2: The Blueprint (System.Type) You use Type.GetType(string) to search the assembly for a class that matches that name.

//     If found, it returns the Type object (the blueprint).

//     If not found, it returns null.

// Step 3: The Creation (Activator) You cannot use the new keyword because new requires a class name at compile time. 
// Instead, we use Activator.CreateInstance(t).

//     This tells the runtime: "Look at this blueprint and build me one of these in memory."

// 3. The "Generic Object" Limitation

// This is the most critical concept to understand.

// When Activator.CreateInstance hands you the new object, the variable type is object (the generic parent of everything).

//     The Reality: The object in RAM is a real Dog.

//     The Compiler's View: The compiler only sees a generic object.

// The Consequence: You cannot simply write myObj.Bark(). The compiler will stop you and say: 
// "I don't see a Bark method on the 'System.Object' class."

// The Solution: Since we cannot rely on the compiler (Early Binding), we must use Reflection again to find the method and 
// press the button manually. This is called Invoking.

using System;
namespace Module26_Reflection1
{
    class Cat
    {
        public void Nyaa()
        {
            Console.WriteLine("Cat purrs");
        }
    }
    
    class Dog
    {
        public void Bark()
        {
            Console.WriteLine("Dog Barks");
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            //Imagine this string came from the user
            Console.WriteLine("Which animal do you want to call (Dog/Cat)? : ");
            string userChoice = Console.ReadLine();
            string fullname = "Module26_Reflection1." + userChoice;
            Type t = Type.GetType(fullname);

            if(t != null)
            {
                object unknownObj = Activator.CreateInstance(t);
                Console.WriteLine("Object Created successfully!");
            }
            else
            {
                Console.WriteLine("Class not found. Check for any spelling errors!");
            }
        }
    }
}