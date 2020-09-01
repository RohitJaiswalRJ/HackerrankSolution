using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Strange_Code
    {
        static long strangeCounter(long t)
        {
            long div = (long)(t - 1L) / 3;
            long index = (long)Math.Log((double)div + 1L, (double)2);
            long startin = (long)3 * ((long)Math.Pow((double)2, (double)index) - 1) + 1;
            long startv = (long)Math.Pow((double)2, (double)index) * 3;
            long result = startv - (t - startin);
            return result;
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            long t = Convert.ToInt64(Console.ReadLine());

            long result = strangeCounter(t);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
