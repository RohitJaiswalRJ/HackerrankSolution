using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class cuboid
    {
        public static void Main(string[] args)
        {
            //    int n = Convert.ToInt32(Console.ReadLine());
            //    //String[] s = new string[n];
            //    List<List<char>> list1 = new List<List<char>>();
            //    List<char> list = new List<char>();
            //    for (int i = 0; i < n; i++)
            //    {
            //        list = Array.ConvertAll(Console.ReadLine().Split(' '), t => Convert.ToChar(t)).ToList();
            //        list.Sort();
            //        list1.Add(list);
            //    }
            //    //foreach (var item in list1)
            //    //{
            //    //    foreach (var i in item)
            //    //    {
            //    //        Console.Write(i + " ");
            //    //    }
            //    //    Console.WriteLine();
            //    //}

            //    List<List<char>> list2 = new List<List<char>>();
            //    for(int i = 0; i<n; i++)
            //    {
            //        list = new List<char>();
            //        for (int j = 0; j < n; j++)
            //        {
            //            list.Add(list1[j][i]);
            //        }
            //        list.Sort();
            //        list2.Add(list);
            //    }
            //    for(int i = 0; i<list1.Count; i++)
            //    {
            //        for (int j = list1[i].Count - 1; j >= 0 ; j--)
            //        {

            //        }
            //    }



            int[] mn = Array.ConvertAll(Console.ReadLine().Split(' '), t => Convert.ToInt32(t));
            int m = mn[0];
            int n = mn[1];
            int[][] locker = new int[m][];
            for (int k = 0; k < m; k++)
            {
                locker[k] = Array.ConvertAll(Console.ReadLine().Split(' '), t => Convert.ToInt32(t));
            }
            int[] rot = Array.ConvertAll(Console.ReadLine().Split(' '), t => Convert.ToInt32(t));
            int r1 = 0;
            int c1 = 0;
            int r2 = m - 1;
            int c2 = n - 1;
            int i = 0;
            int j = 0;
            List<List<int>> layers = new List<List<int>>();
            int l = 0;
            int layern = 0;
            while(l<rot.Length)
            {
                i = r1;
                j = c1;
                List<int> list = new List<int>();
                while(j<c2)
                {
                    list.Add(locker[i][j++]);
                }
                while (i < r2)
                {
                    list.Add(locker[i++][j]);
                }
               
                while (j > c1)
                {
                    list.Add(locker[i][j--]);
                }
                while (i > r1)
                {
                    list.Add(locker[i--][j]);
                }
                layers.Add(list);
                r1++;
                c1++;
                c2--;
                r2--;
                l++;
                layern++;
            }
            foreach (var item in layers)
            {
                foreach (var s  in item)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }

        }
    }
}

