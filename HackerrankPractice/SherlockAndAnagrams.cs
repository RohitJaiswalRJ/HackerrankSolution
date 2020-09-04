using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class SherlockAndAnagrams
    {
        static int sherlockAndAnagrams(string s)
        {
            Dictionary<int, List<List<char>>> dic = new Dictionary<int, List<List<char>>>();
            for (int i = 1; i < s.Length; i++)
            {
                List<List<char>> lc = new List<List<char>>();

                for (int k = 0; k <= s.Length - i; k++)
                {
                    List<char> list = new List<char>();
                    for (int j = k; j < i + k; j++)
                    {
                        list.Add(s[j]);
                    }
                    lc.Add(list);
                }
                dic.Add(i, lc);
            }
            int count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < dic[i].Count - 1; j++)
                {
                    int[] arr = new int[26];
                    foreach (var item in dic[i][j])
                    {
                        arr[(int)item - 97] = 1;
                    }
                    for (int k = j + 1; k < dic[i].Count; k++)
                    {
                        int c = 1;
                        int[] newarr = new int[26];
                        foreach (var item in dic[i][k])
                        {
                            newarr[(int)item - 97]++;
                            if (newarr[(int)item - 97] != arr[(int)item - 97])
                            {
                                c = 0;
                                break;
                            }
                          
                        }
                        if (c == 1)
                            count++;
                    }
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = sherlockAndAnagrams(s);
                Console.WriteLine(result);
                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
