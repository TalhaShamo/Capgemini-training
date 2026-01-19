using System;

class Program
{
    static void Main(string[] args)
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        
        string v = "aeiouAEIOU";
        string temp = "";

        for (int i = 0; i < s1.Length; i++)
        {
            char c = s1[i];
            if (v.IndexOf(c) != -1)
            {
                temp += c;
            }
            else
            {
                bool found = false;
                for (int j = 0; j < s2.Length; j++)
                {
                    if (char.ToLower(s2[j]) == char.ToLower(c))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    temp += c;
                }
            }
        }

        string res = "";
        if (temp.Length > 0)
        {
            res += temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i] != temp[i - 1])
                {
                    res += temp[i];
                }
            }
        }

        Console.WriteLine(res);
    }
}