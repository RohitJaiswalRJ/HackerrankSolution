using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class BigSorting
    {
        // Complete the bigSorting function below.
        public static void MergeSort(int low, int high, string[] str)
        {
            if(low<high)
            {
                int j = (low + high) / 2;
                MergeSort(low, j, str);
                MergeSort(j + 1, high, str);
                Merge(low, j, high, str);
            }
        }
        public static void Merge(int low, int mid, int high, string[] str)
        {
            int i = low;
            int j = mid + 1;
            string[] newlist = new string[high-low+1];
            int a = 0;
            while(i<=mid && j<=high)
            {
                if(BigInteger.Parse(str[i])<= BigInteger.Parse(str[j]))
                {
                    newlist[a++] = str[i++];
                }
                else
                {
                    newlist[a++] = str[j++];
                }

            }
            while(i<=mid)
            {
                newlist[a++] = str[i++];
            }
            while (j <= high)
            {
                newlist[a++] = str[j++];
            }
            a = 0;
            for(int k = low; k<=high; k++)
            {
                str[k] = newlist[a++];
            }
        }
    static string[] bigSorting(string[] unsorted)
        {
            
            MergeSort(0, unsorted.Length - 1, unsorted);
            
            return unsorted;
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            string[] unsorted = new string[n];

            for (int i = 0; i < n; i++)
            {
                string unsortedItem = Console.ReadLine();
                unsorted[i] = unsortedItem;
            }

            string[] result = bigSorting(unsorted);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
            

            //textWriter.WriteLine(string.Join("\n", result));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
