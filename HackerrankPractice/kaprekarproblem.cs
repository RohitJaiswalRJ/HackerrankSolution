using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class kaprekarproblem
    {
        // Complete the kaprekarNumbers function below.
        static void kaprekarNumbers(int p, int q)
        {
            List<int> list = new List<int>();
            long square = 0;
            string original = "";
            StringBuilder l = new StringBuilder("0");
            StringBuilder r;
            int sum = 0;
            int len = 0;
            for (long i = p; i <= q; i++)
            {
                square =(long)( i * i);
                original = square.ToString();
                if (original.Length - i.ToString().Length > 0)
                {
                    l = new StringBuilder(original, 0, original.Length - i.ToString().Length, original.Length - i.ToString().Length);
                    len = l.Length;
                }
                else
                {
                    len = 0;
                }

                r = new StringBuilder(original, len, i.ToString().Length, i.ToString().Length);
                sum = Convert.ToInt32(l.ToString()) + Convert.ToInt32(r.ToString());
                if (sum == i)
                {
                    list.Add(sum);
                }
            }
            if (list.Count == 0)
                Console.WriteLine("INVALID RANGE");
            else
            {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            int p = Convert.ToInt32(Console.ReadLine());

            int q = Convert.ToInt32(Console.ReadLine());

            kaprekarNumbers(p, q);
        }
    }
}
