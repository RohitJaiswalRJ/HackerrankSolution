using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class GridChallenge
    {
        static string gridChallenge(string[] grid)
        {
            List<List<char>> grids = new List<List<char>>();
            for (int i = 0; i < grid.Length; i++)
            {
                List<char> charlist = grid[i].ToList();
                charlist.Sort();
                grids.Add(charlist);
            }
            int max = 0;
            int check = 0;
            for (int i = 0; i < grid[0].Length; i++)
            {
                max = 0;
                for (int j = 0; j < grid.Length; j++)
                {
                    if ((int)grids[j][i] >= max)
                    {
                        max = (int)grids[j][i];
                    }
                    else
                    {
                        check = 1;
                        break;
                    }
                }
                if (check == 1)
                {
                    break;
                }
            }
            if (check == 1)
            {
                return "NO";
            }
            return "YES";
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                string[] grid = new string[n];

                for (int i = 0; i < n; i++)
                {
                    string gridItem = Console.ReadLine();
                    grid[i] = gridItem;
                }

                string result = gridChallenge(grid);
                Console.WriteLine(result);

                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
