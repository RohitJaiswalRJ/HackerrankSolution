using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class DownToZeroII
    {
        static int[] dp = new int[1000000 + 1];
        static DownToZeroII()
        {
            for (int i = 0; i <= 1000000; i++)
                dp[i] = i;

            for (int i = 2; i <= 1000000; i++)
            {
                dp[i] = dp[i - 1] + 1 < dp[i] ? dp[i - 1] + 1 : dp[i];
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        dp[i] = dp[i / j] + 1 < dp[i] ? dp[i / j] + 1 : dp[i];
                    }
                }
            }
        }
        /*
         * Complete the downToZero function below.
         */
        static int downToZero(int n)
        {
            /*
             * Write your code here.
             */
            return dp[n];
        }

        static void Main(string[] args)
        {
          //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int result = downToZero(n);
                Console.WriteLine(result);
              //  textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
