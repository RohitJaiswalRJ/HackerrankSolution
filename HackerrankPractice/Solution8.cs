using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{


    class Result
    {

        /*
         * Complete the 'circularArray' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY endNode
         */

        public static int circularArray(int n, List<int> endNode)
        {
            int[] visit = new int[n+1];
            for (int i = 0; i < endNode.Count-1; i++)
            {
                int conv = endNode[i + 1];
                if (conv < endNode[i])
                    conv = (n + conv);
                for (int j = endNode[i]; j <= conv; j++)
                {
                    if (j > n)
                        visit[j % n]++;
                    else
                        visit[j]++;
                }
            }

            int max = visit.Max();
            List<int> inlist = visit.ToList<int>();
           
            return inlist.IndexOf(max);
        }

    }

    class Solution8
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int endNodeCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> endNode = new List<int>();

            for (int i = 0; i < endNodeCount; i++)
            {
                int endNodeItem = Convert.ToInt32(Console.ReadLine().Trim());
                endNode.Add(endNodeItem);
            }

            int result = Result.circularArray(n, endNode);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }


}
