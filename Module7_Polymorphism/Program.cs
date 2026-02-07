using System;
using System.Runtime.Intrinsics.X86;

namespace Module6_Inheritance;

class Character
{
    public string name;
    public float health, strength;

    public Character(string n, float h, float s)
    {
        name = n;
        health = h;
        strength = s;
    }
    //We write virtual on the Parent's method. It means "I allow my children to change this."
    public virtual void Attack(Character target)
    {
        Console.WriteLine($"{this.name} has hit {target.name} for {this.strength} damage!");
        target.health -= this.strength;
    }
}

class Warrior : Character
{
    public float rage;
    
    public Warrior(float r, string n, float h, float s) : base(n, h,s )
    {
        rage = r;
    }
    public void Berserk()
    {
        this.strength = this.strength * this.rage;
        Console.WriteLine($"{this.name} has gone Berserk! {this.name} has {this.strength} strength now");
    }
    //We write override on the Child's method. It means "I am replacing the parent's version."
    public override void Attack(Character target)
    {
        this.strength *= 1.5f; 
        Console.WriteLine("Warriors have 50% attack buff by default");
        target.health -= this.strength;
        Console.WriteLine($"{this.name} has hit {target.name} for {this.strength} damage. {target.name} has {target.health} hp left!");
        this.strength /= 1.5f;
    }
}

class Mage : Character
{
    public float mana;

    public Mage(float m, string n, float h, float s) : base(n, h, s)
    {
        mana = m;
    }

    public void Heal()
    {
        if(mana < 5)
        {
            Console.WriteLine($"Not enough mana. Remaining mana : {this.mana}");
        }
        else
        {
            this.mana = this.mana - 5;
            this.health = this.health + 10;
            Console.WriteLine($"{this.name} has healed. {this.name} has {this.health}  health now.");
        }
    }

    //We write override on the Child's method. It means "I am replacing the parent's version."
    public override void Attack(Character target)
    {
        target.health -= this.strength;
        Console.WriteLine($"{this.name} has hit {target.name} for {this.strength} damage. {target.name} has {target.health} hp left!");
        this.mana += 4;
        Console.WriteLine($"{this.name} drains energy from {target.name}. They regain mana - remaining mana : {this.mana}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Warrior BadiGadi = new Warrior(3, "Badigadi", 20, 5);
        Mage Rudeus = new Mage(9, "Rudeus", 12, 10);

        Rudeus.Heal();
        BadiGadi.Attack(Rudeus);
        Rudeus.Attack(BadiGadi);
        Rudeus.Heal();
        BadiGadi.Berserk();
        BadiGadi.Attack(Rudeus);
    }
}
