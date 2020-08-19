using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Result1
    {

        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            int lastans = 0;
            List<List<int>> seqlist = new List<List<int>>();
            List<int> lasta = new List<int>();
            for (int i = 0; i < n; i++)
            {
                seqlist.Add(new List<int>());
            }
            for (int i = 0; i < queries.Count; i++)
            {
                switch (queries[i][0])
                {
                    case 1: seqlist[(queries[i][1] ^ lastans) % n].Add(queries[i][2]);
                        break;
                    case 2: lastans = seqlist[(queries[i][1] ^ lastans) % n][queries[i][2] % seqlist[(queries[i][1] ^ lastans) % n].Count] ;
                        lasta.Add(lastans);
                        break;
                    default:
                        break;
                }
            }
            return lasta;
        }

    }

    class DynamicArray
    {
        public static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Result1.dynamicArray(n, queries);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            //textWriter.WriteLine(String.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

}
