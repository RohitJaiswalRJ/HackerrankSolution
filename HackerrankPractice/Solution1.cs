using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class Solution1
    {

        // Complete the formingMagicSquare function below.
        static int formingMagicSquare(int[][] s)
        {
            int sum = 0,sumr=0,sumc=0,sumd=0;
            int diff1, diff2, diff3;
            for (int i = 0; i < s.GetLength(0); i++)
            {
                for (int j = 0; j < s.GetLength(0); j++)
                {
                    
                    for (int k = 0; k < s.GetLength(0); k++)
                    {
                        sumr += s[i][k];
                        sumc += s[k][j];
                        if (i == j)
                            sumd += s[k][k];
                        else if (i + j == 2)
                            sumd += s[k][2 - k];
                    }
                    diff1 = Math.Abs(15 - sumr);
                    diff2 = Math.Abs(15 - sumc);
                    diff3 = Math.Abs(15 - sumd);
                    if(diff1 == diff2 && (sumd==0 || diff2 == diff3) && sumr!=15)
                    {
                        Console.Write(s[i][j]+" --> ");
                        if(sumr>15)
                            s[i][j] -= diff2;
                        else if(sumc>15)
                            s[i][j] -= diff2;
                        else
                            s[i][j] += diff2;
                        sum += diff2;
                        Console.WriteLine(s[i][j]);
                    }
                    sumr = sumc = sumd= 0;
                }

            }
            return sum;

        }

        static void Main(string[] args)
        {
          //  TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] s = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }

            int result = formingMagicSquare(s);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }


}
