using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    //PalindromicSubsets
    class PalindromicSubsets
    {



        static void Main(string[] args)
        {
            string[] nq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nq[0]);

            int q = Convert.ToInt32(nq[1]);

            string s = Console.ReadLine();

            for (int qItr = 0; qItr < q; qItr++)
            {
                // Write Your Code Here
                int[] queries = Array.ConvertAll(Console.ReadLine().Split(' '), qu => Convert.ToInt32(qu));
                char[] news;
                switch (queries[0])
                {
                    case 1: news = s.ToCharArray();
                        //Console.WriteLine(s);
                        int check;
                        for (int i = queries[1]; i <= queries[1] + queries[2]; i++)
                        {
                            check = (int)news[i] + queries[3];
                            if (check > 122)
                                check = check - 122+96;
                            news[i] = (char)(check);
                        }
                        s = new string(news);
                      //  Console.WriteLine(s);
                        break;
                    case 2: news = s.ToCharArray(queries[1], queries[2] - queries[1] + 1);
                        int count = 0;
                        break;
                }
            }
        }
    }

}
