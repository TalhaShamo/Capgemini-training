// Interfaces are like these particular traits which we define that an object inherits

// 1. The Problem: The "One Dad" Rule

// In C#, a class can only have ONE Parent (Inheritance).

//     a) You cannot say: class Superman : Hero, Alien, Reporter. (C# will crash).

//     b) You are only allowed one biological father.

// But... Superman is a Hero, but he also has the Ability to Fly. A Helicopter is a Vehicle, but it also has the Ability to Fly.

// If you put the Fly() method inside the Hero class, then Helicopters can't use it (because they aren't Heroes). If you put Fly() 
// inside Vehicle, Superman can't use it.

// 2. The Solution: Interfaces

// An Interface allows totally different things (Heroes, Birds, Machines) to share the Same Ability.

//     -> Abstract Class (Inheritance): Defines WHAT YOU ARE. You can only be one thing.

//     -> Interface: Defines WHAT YOU CAN DO. You can have as many as you want.

// 3. The Advantages

//     a) Multiple Abilities: A class can implement multiple interfaces -
//     class Superman : Hero, IFlyable, IStrong, ILaserEyes
//     { ... }

//     b) Standardization (The Universal Remote): This is the "Corporate" advantage. If I have a list of objects that implement 
//     IFlyable, I don't care if they are Birds, Planes, or Supermen. I know for a fact they all have a Fly() method.

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Module11_Interfaces
{
    interface IFlyable //All interface names have to start with "I"
    {
        void Fly(); //Everything inside an interface is public by default. So no need to write public.
    }

    interface IStrong
    {
        void Strong();//An interface is just a list of demands. It contains no logic.
    }
    abstract class SuperHero
    {
        public string name {get; set;}
        public SuperHero(string n)
        {
            name = n;
        }
        public abstract void ShowPower();
    }

    class Superman : SuperHero, IFlyable, IStrong
    {
        public Superman(string n) : base(n){}
        public void Fly() //All the inherited interfaces MUST be defined
        {
            Console.WriteLine($"{name} can fly!");
        }
        public void Strong()
        {
            Console.WriteLine($"{name} is strong!!");
        }
        public override void ShowPower()
        {
            Fly();
            Strong();
        }
    }

    class Hulk : SuperHero, IStrong
    {
        public Hulk(string n) : base(n){}
        public void Strong()
        {
            Console.WriteLine($"{name} is so strong he lifts a truck!");
        }
        public override void ShowPower()
        {
            Strong();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hulk hulk = new Hulk("hulk");
            Superman superman = new Superman("superman");
            superman.ShowPower();
            hulk.ShowPower();
        }
    }
}