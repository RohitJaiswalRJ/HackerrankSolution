using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Solution5
    {

        /*
         * Complete the componentsInGraph function below.
         */
       static List<int>[] graph;
        static int min, max = 0,count = 0;
        static int[] componentsInGraph(int[][] gb)
        {
            /*
             * Write your code here.
             */
            graph = new List<int>[(gb.Length*2)+1];
            for (int i = 1; i <= gb.Length*2; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < gb.Length; i++)
            {
                if (!graph[gb[i][0]].Contains(gb[i][1]))
                {
                    graph[gb[i][0]].Add(gb[i][1]);
                    graph[gb[i][1]].Add(gb[i][0]);
                }
            }
            bool[] visited = new bool[(gb.Length*2)+1];
            for (int i = 1; i <= gb.Length*2; i++)
            {
                if (!visited[i])
                {
                    visit(i, visited);
                }
                if (count>0 && min == 0)
                    min = count;
                if (count > max)
                    max = count;
                else if (count < min && count!=0 && count !=1)
                    min = count;
                count = 0;
            }
            int[] arr = { min, max };
            return arr;
        }
        public static void visit(int x,bool[] visited)
        {
            count++;
                visited[x] = true;
            
                foreach (var item in graph[x])
                {
                if(!visited[item])
                    visit(item, visited);
                }
            
        }
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[][] gb = new int[n][];

            for (int gbRowItr = 0; gbRowItr < n; gbRowItr++)
            {
                gb[gbRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), gbTemp => Convert.ToInt32(gbTemp));
            }

            int[] result = componentsInGraph(gb);
            Console.WriteLine(result[0]+" "+result[1]);
            //textWriter.WriteLine(string.Join(" ", SPACE));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

}
