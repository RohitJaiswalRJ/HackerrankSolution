using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Two_Characters
    {
        static int alternate(string s)
        {
            Dictionary<char, List<int>> charindexlist = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charindexlist.ContainsKey(s[i]))
                {
                    charindexlist[s[i]].Add(i);
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(i);
                    charindexlist.Add(s[i], temp);
                }
            }
            List<List<int>> list = new List<List<int>>();
            foreach (var item in charindexlist.Values)
            {
                list.Add(item);
            }
            list.Sort((x, y) => y.Count.CompareTo(x.Count));
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Count == list[i + 1].Count || list[i].Count - list[i + 1].Count == 1)
                {
                    int j = 0;
                    if (list[i].Count > list[i + 1].Count)
                    {
                        for (j = 0; j < list[i + 1].Count; j++)
                        {
                            if (!(list[i + 1][j] > list[i][j] && list[i + 1][j] < list[i][j + 1]))
                            {
                                break;
                            }
                        }
                        if (j == list[i + 1].Count)
                        {
                            return list[i + 1].Count + list[i].Count;
                        }
                    }
                    else
                    {
                        List<int> maxlist = list[i + 1];
                        List<int> minlist = list[i];
                        if (list[i][0] > list[i + 1][0])
                        {
                            maxlist = list[i];
                            minlist = list[i + 1];
                        }
                        for (j = 0; j < maxlist.Count - 1; j++)
                        {
                            if (!(maxlist[j] > minlist[j] && maxlist[j] < minlist[j + 1]))
                            {
                                break;
                            }
                        }
                        if (maxlist[j] > minlist[j])
                        {
                            j++;
                        }
                        if (j == maxlist.Count)
                        {
                            return list[i + 1].Count + list[i].Count;
                        }
                    }
                }
            }
            return 0;

        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int l = Convert.ToInt32(Console.ReadLine().Trim());

            string s = Console.ReadLine();

            int result = alternate(s);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
