using System;
namespace M1_PracticeQ6
{
    class Employee
    {
        public string Id{get; set;}
        public string Name{get; set;}
        public string Type{get; set;}
        public double Salary{get; set;}

        public Employee(string id, string name, string type, double salary)
        {
            Id = id;
            Name = name;
            Type = type;
            Salary = salary;
        }
    }

    class TaxCalculator
    {
        List<Employee> AllEmp = new List<Employee>();

        public void AddEmp(Employee emp)
        {
            AllEmp.Add(emp);
        }

        public void calculateTax()
        {
            foreach(var v in AllEmp)
            {
                double TotalTax = 0;
                if(v.Type == "Contract")
                {
                    TotalTax = 0.15 * v.Salary;   
                }
                else if(v.Type == "Standard")
                {
                    if(v.Salary > 500000 && v.Salary < 1000000)
                    {
                        TotalTax = 0.1 * v.Salary;
                    }   
                    else if(v.Salary >= 1000000)
                    {
                        TotalTax = 0.2*v.Salary;
                    }
                }
                Console.WriteLine($"Id: {v.Id}, Name: {v.Name}, Tax: {TotalTax}");
            }
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            TaxCalculator calcTax = new TaxCalculator();

            int n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');

                string id = parts[0];
                string name = parts[1];
                string type = parts[2];
                double salary = double.Parse(parts[3]);
                
                Employee newEmp = new Employee(id, name, type, salary);
                calcTax.AddEmp(newEmp);
            }
            calcTax.calculateTax();
        }
    }
}