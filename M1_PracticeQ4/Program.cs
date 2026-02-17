using System;
namespace M1_PracticeQ4
{
    class Members
    {
        public string MemberId {get; set;}
        public string Name {get; set;}
        public int Age {get; set;}
        public int Months {get; set;}
        public  double MonthlyFee {get; set;}

        public Members(string mId, string mName, int mAge, int mMonths, double mFee)
        {
            MemberId = mId;
            Name = mName;
            Age = mAge;
            Months = mMonths;
            MonthlyFee = mFee;
        }
    }

    class FitLifeGym
    {
        public List<Members> GymMembers = new List<Members>();

        public void AddMembers(Members m)
        {
            GymMembers.Add(m);
        }

        public void CalculateTotalFee()
        {
            foreach(var v in GymMembers)
            {
                string Plan = " ";
                if(v.Months <= 6) Plan = "Short Term";
                else if(v.Months > 6) Plan = "Long Term";

                double TotalFee = v.Months * v.MonthlyFee;

                if(v.Age > 50)
                {
                    TotalFee *= 0.8;
                }
                else if(v.Age < 25)
                {
                    TotalFee *= 0.9;
                }
                
                Console.WriteLine($"Member: {v.Name}, Plan: {Plan}, Fee: {TotalFee}");
            }
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            FitLifeGym memberObj = new FitLifeGym();

            int n = int.Parse(Console.ReadLine());

            for(int i=0; i<n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArr = input.Split(" ");

                string memId = inputArr[0];
                string name = inputArr[1];
                int age = int.Parse(inputArr[2]);
                int months = int.Parse(inputArr[3]);
                double monFee = double.Parse(inputArr[4]);

                Members newMember = new Members(memId, name, age, months, monFee);
                memberObj.AddMembers(newMember);
            }

            memberObj.CalculateTotalFee();
        }
    }
}