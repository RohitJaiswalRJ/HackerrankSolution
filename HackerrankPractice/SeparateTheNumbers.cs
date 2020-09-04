using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class SeparateTheNumbers
    {
        static void separateNumbers(string s)
        {
            string temp = "";
            if (s.Length > 1)
            {
                for (int i = 0; i < s.Length/2; i++)
                {
                    temp = "";
                    StringBuilder sb = new StringBuilder(s, 0, i + 1, i + 1);
                    long t = Convert.ToInt64(sb.ToString());
                    long test = t;
                    while (temp.Length < s.Length)
                    {
                        temp += t.ToString();
                        t++;
                    }
                    if (temp.Equals(s))
                    {
                        Console.WriteLine("YES " + test);
                        return;
                    }
                }
            }
            Console.WriteLine("NO");
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                separateNumbers(s);
            }
        }
    }
}
