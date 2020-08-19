using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Solution7
    {

        /*
         * Complete the runningMedian function below.
         */
        static double[] runningMedian(int[] a)
        {
            /*
             * Write your code here.
             */
            List<int> b = new List<int>();
            double[] result = new double[a.Length];
            int s;
            
            //Console.WriteLine(b.BinarySearch(2));
            //b.Insert()
            for (int i = 0; i < a.Length;i++)
            {
                b.Add(a[i]);
                b.Sort();
                s = b.Count;
                if (s % 2 == 0)
                    result[i] = (double)((double) (b[s / 2] + b[s / 2 - 1]) / (double)2);
                else
                    result[i] = b[s / 2];
            }
            return result;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int aCount = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[aCount];

            for (int aItr = 0; aItr < aCount; aItr++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[aItr] = aItem;
            }

            double[] result = runningMedian(a);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            //textWriter.WriteLine(string.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

}
