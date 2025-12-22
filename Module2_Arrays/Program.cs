using System;

namespace Module2_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter the number of students: ");
            n = int.Parse(Console.ReadLine());

            float[] a = new float[n];
            Console.WriteLine("Enter the scores of each student: ");
            for(int i=0; i<a.Length; i++)
            {
                a[i] = float.Parse(Console.ReadLine());
            }

            float sum = 0;
            foreach(float s in a)
            {
                sum += s;
            }
            Console.Write($"Average score of the class: {sum/a.Length}");
        }
    }
}
