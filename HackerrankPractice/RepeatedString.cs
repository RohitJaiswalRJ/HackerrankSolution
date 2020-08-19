using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class RepeatedString
    {
        // Complete the repeatedString function below.
        static long repeatedString(string s, long n)
        {
            if (s == "a")
                return n;
            else if (s.Length == 1)
                return 0;
            else
            {
                long count = 0;
                long[] lcount = new long[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'a')
                        count++;
                    lcount[i] = count;
                }
                long div = (long)(n / s.Length);
                count *= div;
                int rem = (int)(n % s.Length);
                if(rem != 0)
                count += lcount[rem - 1];
                return count;
            }
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long result = repeatedString(s, n);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
