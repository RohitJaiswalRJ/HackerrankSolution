using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class AbsolutePermutation
    {
        static int[] absolutePermutation(int n, int k)
        {
            List<int> arr = new List<int>();
            int[] newarr = new int[n];
            if (n % 2 == 1)
            {
                if (k != 0)
                {
                    arr.Add(-1);
                    return arr.ToArray();
                }
                else
                {

                    for (int i = 0; i < n; i++)
                        newarr[i] = i + 1;
                    return newarr;
                }
            }
            else
            {
                int[] check = new int[n + 1];
                for (int i = 0; i < n; i++)
                {
                    int r = i + 1 + k;
                    int l = i + 1 - k;
                    newarr[i] = r;
                    if (r > n && l <= 0)
                    {
                        arr.Add(-1);
                        return arr.ToArray();
                    }
                    else if (l < r && l > 0)
                    {
                        if (check[l] != 1)
                        newarr[i] = l;
                        else if(r>n)
                        {
                            arr.Add(-1);
                            return arr.ToArray();
                        }
                    }

                    check[newarr[i]] = 1;
                }
                return newarr;
            }
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nk = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nk[0]);

                int k = Convert.ToInt32(nk[1]);

                int[] result = absolutePermutation(n, k);

                //textWriter.WriteLine(string.Join(" ", result));
                foreach(var item in result)
                {
                    Console.Write(item + " ");
                }
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
