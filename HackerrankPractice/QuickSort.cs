using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class QuickSort
    {
        public static int partition(int low, int high, int[] arr)
        {
            int i = low;
            int j = high;
            int pivot = arr[low];
            while (i <= j)
            {
                while (arr[i] <= pivot)
                {
                    i++;
                    if (i == arr.Length)
                        break;
                }

                while (arr[j] > pivot)
                {
                    j--;
                    if (j == -1)
                        break;
                }
                if (i < j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[j];
            arr[j] = arr[low];
            arr[low] = temp1;
            return j;
        }
        public static void QuickSortFunc(int low, int high, int[] arr)
        {
            if (low < high)
            {
                int j = partition(low, high, arr);
                QuickSortFunc(low, j, arr);
                QuickSortFunc(j + 1, high, arr);
            }
        }
        static void Main(string[] args)
        {
            //Dictionary<int, int[]> dic = new Dictionary<int, int[]>();
            //dic.Min();
            //dic.Add(1, new int[2]);
            //int keys = dic.Keys.Min();
            
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
            QuickSortFunc(0, arr.Length - 1, arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
