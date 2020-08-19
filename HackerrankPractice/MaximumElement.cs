using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class MaximumElement
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
        public class MaxHeap
        {
            public Node Root { get; set; }
            public int Count { get; set; }
            public MaxHeap()
            {
                Count = 0;
                Root = null;
            }
            public void Add(Node node)
            {
                Node pointer = Root;
                if (Root == null)
                {
                    Root = node;
                    Count++;
                    pointer = Root;
                }
                else
                {
                    string bincount = Convert.ToString(Count + 1, 2);
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
                while (true)
                {
                    if (pointer == Root)
                        break;
                    if (pointer.Data > pointer.Parent.Data)
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
                        if (pointer.Left.Data > pointer.Right.Data)
                        {
                            small = pointer.Left;
                        }
                        else
                        {
                            small = pointer.Right;
                        }
                    }
                    if (pointer.Data < small.Data)
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
                    if (bitcount[i] == '0')
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
                    pointer = Root;
                    if (data == Root.Data)
                        break;
                    bitcount = Convert.ToString(j, 2);
                    
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
                        {
                            c = 1;
                            break;
                        }
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
                    Count--;
                    Root = null;
                }
                return data;
            }
        }
        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            MaxHeap maxHeap = new MaxHeap();
            for (int i = 0; i < q; i++)
            {
                int[] queries = Array.ConvertAll(Console.ReadLine().Split(' '), item => Convert.ToInt32(item));
                switch (queries[0])
                {
                    case 1:
                        stack.Push(queries[1]);
                        Node node = new Node();
                        node.Data = queries[1];
                        maxHeap.Add(node);
                        break;

                    case 2:
                        int rem = stack.Pop();
                        maxHeap.Remove(rem);
                        break;

                    case 3:
                        Console.WriteLine("-----"+maxHeap.Root.Data+"-----");
                        break;
                }
            }
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        }
    }
}
