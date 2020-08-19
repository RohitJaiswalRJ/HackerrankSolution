using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    public class Queue
    {
        public Stack<int> stack1 { get; set; }
        public Stack<int> stack2 { get; set; }
        public Queue()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }
        public void enQueue(int x)
        {
            while(stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
            stack1.Push(x);
            while(stack2.Count > 0)
            {
                stack1.Push(stack2.Pop());
            }
        }
        public int? deQueue()
        {
            if (stack1.Count == 0)
            {
                Console.WriteLine("Queue is Empty!");
                return null;
            }
            return stack1.Pop();

        }
        public void print()
        {
            if(stack1.Count > 0)
            {
                Console.WriteLine(stack1.Peek());
            }
            if(stack1.Count == 0)
                Console.WriteLine("Queue is Empty!");
        }
    }
    class Solution4
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] q = new int[n][];
            for (int i = 0; i < n; i++)
            {
                q[i] = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
            }
            Queue q1 = new Queue();
            for (int i = 0; i < n; i++)
            {
                switch (q[i][0])
                {
                    case 1: q1.enQueue(q[i][1]);
                        break;
                    case 2: int? a = q1.deQueue();
                        break;
                    case 3: q1.print();
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
