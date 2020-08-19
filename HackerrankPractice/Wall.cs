using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Wall
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            String[] s = new string[n];
            List<List<char>> list1 = new List<List<char>>();
            for(int i = 0; i< n; i++)
            {
                List<char> list;
               list = Array.ConvertAll(Console.ReadLine().Split(' '),t=>Convert.ToChar(t)).ToList();
                list1.Add(list);
            }
            foreach(var item in list1)
            {
                foreach(var i in item)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
