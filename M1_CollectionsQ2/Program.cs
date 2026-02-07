using System;
namespace M1_CollectionsQ2
{
    class ForensicReportClass
    {
        private Dictionary<string, DateOnly> ForensicReports;

        public ForensicReportClass()
        {
            ForensicReports = new Dictionary<string, DateOnly>();
        }

        public void AddReports(string s, DateOnly d)
        {
            if (ForensicReports.ContainsKey(s))
            {
                ForensicReports[s] = d;
            }
            else
            {
                ForensicReports.Add(s, d);
            }
        }

        public void ViewReport(DateOnly d)
        {
            foreach(var v in ForensicReports)
            {
                if(v.Value == d)
                {
                    Console.WriteLine(v.Key);
                    return;
                }
            }
            Console.WriteLine("No reporting Officer found");
        }

    }
    class Program
    {
        static void Main(string[] arg)
        {
            ForensicReportClass reportMap = new ForensicReportClass();

            Console.WriteLine("Enter number of reports to be added : ");
            int reportCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Forensic Reports (Reporting Officer:Report Filed Date (yyyy-MM-DD))");
            for(int i=0; i<reportCount; i++)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(':');
                string key = parts[0];
                DateOnly val = DateOnly.Parse(parts[1]);
                
                reportMap.AddReports(key, val);
            }

            Console.WriteLine("Enter the filed date to identify officers");
            DateOnly findVal = DateOnly.Parse(Console.ReadLine());
            reportMap.ViewReport(findVal);
        }
    }
}
