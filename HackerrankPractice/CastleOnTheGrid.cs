using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class CastleOnTheGrid
    {
        public class newtype
        {
            public int a { get; set; }
            public int b { get; set; }
        }
        // Complete the minimumMoves function below.
        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            int[,] visited = new int[grid.Length, grid.Length];
            newtype[,] predecessor = new newtype[grid.Length, grid.Length];
            q.Enqueue((startX, startY));
            visited[startX, startY] = 1;
            (int a, int b) t;
            while (true)
            {
                t = q.Dequeue();
                visited[t.a, t.b] = 2;
                int c = -1;
                int check = 0;
                for (int i = t.b; i >= 0 && i < grid.Length; i = i + c)
                {
                    if (grid[t.a][i] == 'X' && c == -1)
                    {
                        c = 1;
                        i = t.b+1;
                    }
                    else if (grid[t.a][i] == 'X')
                        break;
                    if (visited[t.a, i] == 0)
                    {
                        q.Enqueue((t.a, i));
                        visited[t.a, i] = 1;
                        predecessor[t.a, i] = new newtype() { a = t.a, b = t.b };
                    }
                    if (t.a == goalX && i == goalY)
                    {
                        check = 1;
                        break;
                    }
                    if (i == 0)
                    {
                        i = t.b;
                        c = 1;
                    }
                }
                if (check == 1)
                    break;
                c = -1;
                for (int i = t.a; i >= 0 && i < grid.Length; i = i + c)
                {

                    if (grid[i][t.b] == 'X' && c == -1)
                    {
                        c = 1;
                        i = t.a;
                    }
                    else if (grid[i][t.b] == 'X')
                        break;
                    if (visited[i, t.b] == 0)
                    {
                        q.Enqueue((i, t.b));
                        visited[i, t.b] = 1;
                        predecessor[i, t.b] = new newtype() { a = t.a, b = t.b };
                    }
                    if (i == goalX && t.b == goalY)
                    {
                        check = 1;
                        break;
                    }
                    if (i == 0)
                    {
                        i = t.a;
                        c = 1;
                    }
                }
                if (check == 1)
                    break;
            }
            Stack<(int, int)> s = new Stack<(int, int)>();
            s.Push((goalX, goalY));
            (int a, int b) pre;
            while (true)
            {
                pre.a = predecessor[s.Peek().Item1, s.Peek().Item2].a;
                pre.b = predecessor[s.Peek().Item1, s.Peek().Item2].b;
                s.Push(pre);
                if (pre.a == startX && pre.b == startY)
                    break;
            }
            return s.Count-1;
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            string[] grid = new string[n];

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }

            string[] startXStartY = Console.ReadLine().Split(' ');

            int startX = Convert.ToInt32(startXStartY[0]);

            int startY = Convert.ToInt32(startXStartY[1]);

            int goalX = Convert.ToInt32(startXStartY[2]);

            int goalY = Convert.ToInt32(startXStartY[3]);

            int result = minimumMoves(grid, startX, startY, goalX, goalY);

            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
