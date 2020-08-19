using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Encryption
    {
        // Complete the encryption function below.
        static string encryption(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            sb.Replace(" ", null);
            double nr = Math.Floor(Math.Sqrt((double)sb.Length));
            double nc = Math.Ceiling(Math.Sqrt((double)sb.Length));
            if (nr * nc < sb.Length)
            {
                nr++;
            }
            StringBuilder[] nsb = new StringBuilder[(int)nr];
            int len = (int)nc;
            int k = 0;
            for (int i = 0; i < sb.Length; i = i + (int)nc)
            {
                if (sb.Length - i < len)
                    len = sb.Length - i;
                nsb[k] = new StringBuilder(sb.ToString(), i, len, len);
                k++;
            }
            StringBuilder ss = new StringBuilder();
            for (int i = 0; i < nc; i++)
            {
                for (int j = 0; j < nr; j++)
                {
                    if (i < nsb[j].Length)
                        ss.Append(nsb[j][i]);
                }
                ss.Append(" ");
            }
           // sb.Append()
            return ss.ToString();

        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = encryption(s);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
