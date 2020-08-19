using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class JesseandCookies
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public Node()
            {
                Left = null;
                Right = null;
                Parent = null;
            }

        }
        public class MinHeap
        {
            public Node Root { get; set; }
            public int Count { get; set; }
            public MinHeap()
            {
                Count = 0;
                Root = null;
            }
            public void Add(Node node)
            {
                Node pointer = Root;
                if(Root==null)
                {
                    Root = node;
                    Count++;
                    pointer = Root;
                }
                else
                {
                    string bincount = Convert.ToString(Count+1, 2);
                    for (int i = 1; i < bincount.Length; i++)
                    {
                        if (bincount[i] == '0')
                        {
                            if (pointer.Left == null)
                            {
                                pointer.Left = new Node();
                                pointer.Left.Parent = pointer;
                            }
                            pointer = pointer.Left;
                        }
                        else
                        {
                            if (pointer.Right == null)
                            {
                                pointer.Right = new Node();
                                pointer.Right.Parent = pointer;
                            }
                            pointer = pointer.Right;
                        }
                    }
                    pointer.Data = node.Data;
                    Count++;
                }
                while(true)
                {
                    if (pointer == Root)
                        break;
                    if (pointer.Data < pointer.Parent.Data)
                    {
                        int temp = pointer.Data;
                        pointer.Data = pointer.Parent.Data;
                        pointer.Parent.Data = temp;
                        pointer = pointer.Parent;
                    }
                    else
                        break;
                }

            }
            public void Heapify()
            {
                Node pointer = Root;
               
                while (true)
                {
                    Node small = pointer.Left;
                    if (small == null)
                        break;
                    if (pointer.Left != null && pointer.Right != null)
                    {
                        if (pointer.Left.Data < pointer.Right.Data)
                        {
                            small = pointer.Left;
                        }
                        else
                        {
                            small = pointer.Right;
                        }
                    }
                    if (pointer.Data > small.Data)
                    {
                        int temp = small.Data;
                        small.Data = pointer.Data;
                        pointer.Data = temp;
                    }
                    pointer = small;
                }
            }
            public int Remove()
            {
                int data = Root.Data;
                string bitcount = Convert.ToString(Count, 2);
                Node pointer = Root;
                for (int i = 1; i < bitcount.Length; i++)
                {
                    if(bitcount.Length==2)
                        Console.WriteLine();
                    if(bitcount[i]=='0')
                    {
                        pointer = pointer.Left;
                    }
                    else
                    {
                        pointer = pointer.Right;
                    }
                }
                Root.Data = pointer.Data;
                if (pointer.Parent != null)
                {
                    if (pointer == pointer.Parent.Left)
                    {
                        pointer.Parent.Left = null;
                    }
                    else
                    {
                        pointer.Parent.Right = null;
                    }
                    Count--;
                    Heapify();
                }
                else
                {
                    Root = null;
                }
                return data;
            }


            public int Remove(int data)
            {
                string bitcount;
                Node pointer = new Node();
                int c = 0;
                for (int j = (Count + 1) / 2; j <= Count; j++)
                {
                    if (data == Root.Data)
                        break;
                    bitcount = Convert.ToString(j, 2);
                    pointer = Root;
                    for (int i = 1; i < bitcount.Length; i++)
                    {
                        
                        if (bitcount[i] == '0')
                        {
                            pointer = pointer.Left;
                        }
                        else
                        {
                            pointer = pointer.Right;
                        }
                        if (pointer.Data == data)
                            c=1;
                    }
                    if (c == 1)
                        break;
                }
               bitcount = Convert.ToString(Count, 2);
               Node pointer1 = Root;
                for (int i = 1; i < bitcount.Length; i++)
                {
                    if (bitcount[i] == '0')
                    {
                        pointer1 = pointer1.Left;
                    }
                    else
                    {
                        pointer1 = pointer1.Right;
                    }
                }
               
                pointer.Data = pointer1.Data;
                if (pointer1.Parent != null)
                {
                    if (pointer1 == pointer1.Parent.Left)
                    {
                        pointer1.Parent.Left = null;
                    }
                    else
                    {
                        pointer1.Parent.Right = null;
                    }
                    Count--;
                    Heapify();
                }
                else
                {
                    Root = null;
                }
                return data;
            }
        }
        static int cookies(int k, int[] A)
        {
            /*
             * Write your code here.
             */
            MinHeap minHeap = new MinHeap();
            foreach (var item in A)
            {
                Node node = new Node();
                node.Data = item;
                minHeap.Add(node);
            }
            int operations = 0;
            Console.WriteLine(minHeap.Remove(3));
            while(true)
            {
                int min1 = minHeap.Remove();
                if (min1 >= k)
                    break;
                if (minHeap.Root == null)
                {
                    operations = -1;
                    break;
                }
                int min2 = minHeap.Root.Data;
                int newNode = (1*min1)+(2*min2);
                if (min1 < k)
                {
                    minHeap.Root.Data = newNode;
                    minHeap.Heapify();
                    operations++;
                }
                else
                    break;
            }
            return operations;

        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), ATemp => Convert.ToInt32(ATemp));
            //int[] A = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    A[i] = 1;
            //}
            int result = cookies(k, A);
            Console.WriteLine(result);
            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
