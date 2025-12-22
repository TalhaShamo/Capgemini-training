using System;

namespace Module5_Classes
{
    class Character
    {
        public string Name;
        public float health, Strength;

        public Character(string n, float h, float s)
        {
            Name = n;
            health = h;
            Strength = s;
        }
        public void Attack(Character target)
        {
            target.health = target.health - this.Strength;
            Console.WriteLine($"{this.Name} attacks {target.Name}");
            Console.WriteLine($"{target.Name} has {target.health} health left");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Character hero = new Character("Hero", 5, 10);
            Character monster = new Character("Monster", 15.7f, 2.5f);
            hero.Attack(monster);
            monster.Attack(hero);
            
        }
    }
}
