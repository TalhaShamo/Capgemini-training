// Study Notes: Reflection (Part 3 - Dynamic Invocation)
// 1. The Problem: The "Generic Object" Trap

// When you create an object using Late Binding (Activator.CreateInstance), the compiler treats it as a generic "object". 
// Even if the object in memory is a "Dog", the variable is just type "object".

//     The Issue: You cannot write obj.Bark() because the compiler doesn't see a Bark method on the generic object class.

//     The Solution: You must use Reflection Invocation.

// 2. The Logic: "The Robot Finger"

// Since you cannot press the button yourself (using code syntax), you ask Reflection to find the button and press it for you.

//     Step 1 (Find): Ask the Type object to find the specific method by name.

//     Step 2 (Press): Tell that method to "Invoke" (run) itself on your object instance.

// 3. The Toolkit: MethodInfo and Invoke

// A. Getting the Method Use t.GetMethod("NameString").

//     This returns a MethodInfo object (The button).

//     Critical Safety: If the method doesn't exist, this returns null. Always check for null before proceeding!

// B. Running the Method Use methodInfo.Invoke(objectInstance, parameters).

//     Argument 1 (The Target): The actual object in memory you created (e.g., unknownObj).

//     Argument 2 (The Inputs): An array of arguments to pass to the function. If the method has no arguments (like void Bark()), 
//     pass null.

// 4. Code Syntax (Step-by-Step)

// Scenario: We want to run Bark() on unknownObj.

// Step 1: Get the Method Handle MethodInfo method = t.GetMethod("Bark");

// Step 2: Check if it exists if (method != null) { // Step 3: Run it! // We pass 'null' because Bark() needs no inputs. method.Invoke(unknownObj, null); }
// 5. Summary Checklist: The Full Reflection Cycle

//     Late Binding: Activator.CreateInstance -> Creates the Object.

//     Inspection: t.GetMethod -> Finds the Method.

//     Invocation: method.Invoke -> Runs the Code.

using System;
using System.Reflection;

namespace Module27_Reflection
{
    class SmartLight
    {
        public void TurnOn() => Console.WriteLine("💡 Light switched on!");
        public void TurnOff() => Console.WriteLine("🌑 Light switched off!");
    }

    class SmartSpeaker
    {
        public void PlayMusic() => Console.WriteLine("🎵 Playing Music...");
        public void StopMusic() => Console.WriteLine("Paused Music");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Which device? (SmartLight / SmartSpeaker)");
            string classChoice = Console.ReadLine();

            string className = "Module27_Reflection." + classChoice;

            Type t = Type.GetType(className);

            if (t != null)
            {
                object unknownObj = Activator.CreateInstance(t);
                Console.WriteLine("- Object Created successfully!");

                // --- Inspection (Menu) ---
                MethodInfo[] methods = t.GetMethods();
                Console.WriteLine("> Available Commands:");
                
                foreach (var m in methods)
                {
                    if (m.DeclaringType == t)
                    {
                        Console.WriteLine($"- {m.Name}");
                    }
                }

                // --- Invocation (Action) ---
                Console.WriteLine("> Enter command:");
                string methodChoice = Console.ReadLine();
                MethodInfo methodToRun = t.GetMethod(methodChoice);

                if (methodToRun != null)
                {
                    Console.WriteLine("> Running Command...");
                    methodToRun.Invoke(unknownObj, null); //This is where all the magic happens
                }
                else
                {
                    Console.WriteLine("> Command not found!");
                }
            }
            else
            {
                Console.WriteLine("> Error: Class not found. Did you type 'SmartLight' exactly?");
            }
        }
    }
}