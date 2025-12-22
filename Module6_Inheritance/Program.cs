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
}

class Program
{
    static void Main(string[] args)
    {
        Warrior BadiGadi = new Warrior(3, "Badigadi", 20, 5);
        Mage Rudeus = new Mage(9, "Rudeus", 12, 10);

        BadiGadi.Berserk();
        Rudeus.Heal();
        Rudeus.Heal();
    }
}
