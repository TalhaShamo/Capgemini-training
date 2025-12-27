using System;
using System.Data;
namespace MiniProject1
{
    interface IHealable
    {
        void Heal();
    }
    abstract class Fighter
    {
        private int _health;
        public string Name {get; set;}
        public Fighter(string n)
        {
            Name = n;
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if(value <= 0)
                {
                    _health = 0;
                }
                else
                {
                    _health = value;
                }
            }
        }
        public abstract void Attack(Fighter target);
    }
    class Warrior : Fighter
    {
        Random rnd = new Random();
        public Warrior(string n) : base(n)
        {
            Health = 100;
        }
        public override void Attack(Fighter target)
        {
            int damage = rnd.Next(5, 15);
            target.Health -= damage; //Randomly damages target for 5 to 15 damage
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} slashes {target.Name} for {damage}. Remaining health - {target.Health}hp!");
        }
    }
    class Mage : Fighter, IHealable
    {
        Random rnd = new Random();
        public Mage(string n) : base(n)
        {
            Health = 60;
        }
        public override void Attack(Fighter target)
        {
            int damage = rnd.Next(10, 20);
            target.Health -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} casts fireball on {target.Name} for {damage}. Remaining health - {target.Health}hp!");
        }
        public void Heal()
        {
            Health += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} uses heal. Current hp : {Health}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Warrior hulk = new Warrior("Hulk");
            Mage loki = new Mage("Loki");
            while(loki.Health > 0 && hulk.Health > 0)
            {
                hulk.Attack(loki);
                if (loki.Health <= 0) break;
                System.Threading.Thread.Sleep(3000);

                Random rand = new Random();
                int choice = rand.Next(0, 2);
                if(choice == 1)
                {
                    loki.Attack(hulk);
                }
                else
                {
                    loki.Heal();
                }
                System.Threading.Thread.Sleep(3000);
                if(hulk.Health <= 0) break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if(hulk.Health <= 0) Console.WriteLine($"Game Over! {loki.Name} wins 🎉");
            else Console.WriteLine($"Game over! {hulk.Name} wins 🎉");
        }
    }
}