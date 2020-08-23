using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class OrganisingContainersOfBalls
    {
        static string organizingContainers(int[][] container)
        {
            int[][] column = new int[container.GetLength(0)][];
            for (int i = 0; i < container.GetLength(0); i++)
            {
                column[i] = new int[container.GetLength(0)];
                for (int j = 0; j < container.GetLength(0); j++)
                {
                    column[i][j] = container[j][i];
                }
            }

            int k = 0;
            for (k = 0; k < container.GetLength(0); k++)
            {
                //Console.WriteLine("Sum {0} : {1} and {2}",k, container[k].Sum(t => Convert.ToInt64(t)), column[k].Sum(t => Convert.ToInt64(t)));
                long sum1 = container[0].Sum(t => Convert.ToInt64(t)) - container[0][k];
                long sum2 = column[k].Sum(t => Convert.ToInt64(t)) - column[k][0];
                if (sum1 == sum2)
                    return "Possible";
            }
            return "Impossible";
        }

        static void Main(string[] args)
        {
          //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[][] container = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
                }

                string result = organizingContainers(container);
                Console.WriteLine(result);
               // textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
