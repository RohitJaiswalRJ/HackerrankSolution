using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class LongestCommonEnd
    {
        public static String LongestCommonEnding(string s1, string s2)
        {
            List<char> commonEnding = new List<char>();
            int min;
            int i = s1.Length - 1, j = s2.Length - 1;
            if (s1.Length < s2.Length)
                min = s1.Length-1;
            else
                min = s2.Length-1;
            while(min>=0)
            {
                if (s1[i] == s2[j])
                    commonEnding.Insert(0,s1[i]);
                else 
                    break;
                i--;
                j--;
                min--;
            }
            string s = "";
            for (int k = 0; k < commonEnding.Count; k++) 
            {
                s += commonEnding[k];
            }
            return s;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[5];
            List<int> list = new List<int>();
            list = arr.ToList();
            list.Sort();
            //list.re;
            Console.WriteLine(LongestCommonEnding("multiplication", "ration"));
            Console.WriteLine(LongestCommonEnding("potent", "tent"));
            Console.WriteLine(LongestCommonEnding("skyscraper", "carnivore"));
        }
    }
}
