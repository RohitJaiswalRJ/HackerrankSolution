using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Solution6
    {

        // Complete the isBalanced function below.
        static string isBalanced(string s)
        {
            Stack<char> s1 = new Stack<char>();
            foreach (var item in s)
            {
                if (item == ')')
                {
                    if (s1.Count > 0)
                    {
                        if (s1.Peek() == '(')
                            s1.Pop();
                        else
                            s1.Push(item);
                    }
                    else
                        s1.Push(item);
                }
                else if (item == '}')
                {
                    if (s1.Count > 0)
                    {
                        if (s1.Peek() == '{')
                            s1.Pop();
                        else
                            s1.Push(item);
                    }
                    else
                        s1.Push(item);
                }
                else if (item == ']')
                {
                    if (s1.Count > 0)
                    {
                        if (s1.Peek() == '[')
                            s1.Pop();
                        else
                            s1.Push(item);
                    }
                    else
                        s1.Push(item);
                }
                else
                    s1.Push(item);

            }
            if (s1.Count == 0)
                return "YES";
            else
                return "NO";
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = isBalanced(s);
                Console.WriteLine(result);
               // textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

}
