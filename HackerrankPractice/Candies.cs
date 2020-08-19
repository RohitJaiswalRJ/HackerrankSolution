using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Candies
    {
        static long candies(int n, int[] arr)
        {
            List<int> sorted = arr.ToList();
            sorted.Sort();
            Dictionary<int, List<int>> valinpair = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (valinpair.ContainsKey(arr[i]))
                {
                    valinpair[arr[i]].Add(i);
                }
                else
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    valinpair.Add(arr[i], l);
                }
            }
            int[] noofcandy = new int[arr.Length];

            for (int i = 0; i < sorted.Count; i++)
            {
                int index = valinpair[sorted[i]][valinpair[sorted[i]].Count - 1];
                valinpair[sorted[i]].RemoveAt(valinpair[sorted[i]].Count - 1);
                if (index < arr.Length - 1 && index > 0)
                {
                    if (arr[index] <= arr[index + 1] && arr[index] <= arr[index - 1])
                    {
                        noofcandy[index] = 1;
                    }
                    else if (arr[index] > arr[index + 1] && arr[index] > arr[index - 1])
                    {
                        if (noofcandy[index + 1] > noofcandy[index - 1])
                        {
                            noofcandy[index] = noofcandy[index + 1] + 1;
                        }
                        else
                        {
                            noofcandy[index] = noofcandy[index - 1] + 1;
                        }
                    }
                    else if (arr[index] > arr[index + 1])
                    {
                        noofcandy[index] = noofcandy[index + 1] + 1;
                    }
                    else if (arr[index] > arr[index - 1])
                    {
                        noofcandy[index] = noofcandy[index - 1] + 1;
                    }
                }
                else if (index > 0)
                {
                    if (arr[index] <= arr[index - 1])
                    {
                        noofcandy[index] = 1;
                    }
                    else
                    {
                        noofcandy[index] = noofcandy[index - 1] + 1;
                    }
                }
                else
                {
                    if (arr[index] <= arr[index + 1])
                    {
                        noofcandy[index] = 1;
                    }
                    else
                    {
                        noofcandy[index] = noofcandy[index + 1] + 1;
                    }
                }
            }
            /*string result = "";
            for(int i = 0; i<noofcandy.Length; i++)
            {
                result = result+noofcandy[i].ToString();
            }
            long r = Convert.ToInt64(result);*/
            long sum = (long)noofcandy.Sum(t=>Convert.ToInt64(t));
            return sum;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            long result = candies(n, arr);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
