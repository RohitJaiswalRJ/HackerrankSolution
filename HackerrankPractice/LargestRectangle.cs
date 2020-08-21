using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class LargestRectangle
    {
        static long largestRectangle(int[] h)
        {

            Stack s = new Stack();
            s.Push(0);
            int i = 1;
            int top = 0;
            long area = 0;
            long maxarea = 0;
            while (i < h.Length)
            {
                if (h[i] >= h[i - 1])
                {
                    s.Push(i);
                }
                else
                {
                    if (s.Count > 0)
                    {
                        while (h[(int)s.Peek()] > h[i])
                        {
                            int popped = (int)s.Pop();
                            if (s.Count == 0)
                            {
                                area = h[popped] * i;
                            }
                            else
                            {

                                area = h[popped] * (i - (int)s.Peek() - 1);
                            }
                            if (area > maxarea)
                            {
                                maxarea = area;
                            }
                            if(s.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                    s.Push(i);
                }
                i++;
            }

            
                while (s.Count > 0)
                {
                    int popped = (int)s.Pop();
                    if (s.Count == 0)
                    {
                        area = h[popped] * i;
                    }
                    else
                    {

                        area = h[popped] * (i - (int)s.Peek() - 1);
                    }
                    if (area > maxarea)
                    {
                        maxarea = area;
                    }
                }
            
            return maxarea;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
            ;
            long result = largestRectangle(h);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
