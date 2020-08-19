using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class MergeSort
    {
        public static void MergeSortFunc(int low, int high, int[] arr)
        {
            if(low<high)
            {
                int mid = (low + high) / 2;
                MergeSortFunc(low, mid, arr);
                MergeSortFunc(mid + 1, high, arr);
                Merge(low, mid, high, arr);
            }
        }
        public static void Merge(int low, int mid, int high, int[] arr)
        {
            int i = low;
            int j = mid + 1;
            int k = 0;
            int[] newarr = new int[high + 1];

            while(i<=mid && j<=high)
            {
                if (arr[i] < arr[j])
                {
                    newarr[k] = arr[i];
                    k++;
                    i++;
                }
                else
                {
                    newarr[k] = arr[j];
                    k++;
                    j++;
                }
            }
            while(i<=mid)
            {
                newarr[k++] = arr[i];
                i++;
            }
            while(j<=high)
            {
                newarr[k++] = arr[j];
                j++;
            }
            j = 0;
            for(i = low; i<=high; i++,j++)
            {
                arr[i] = newarr[j];
            }
        }

        static void Main(string[] args)
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
            MergeSortFunc(0, arr.Length - 1, arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
