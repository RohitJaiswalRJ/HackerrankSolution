using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class SwapNodes
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

           public Node(int data)
            {
                this.data = data;
                this.left = null;
                this.right = null;
            }
        }

        public static int depth(Node root)
        {
            if (root.data == -1)
                return 0;
            int hl = 1 + depth(root.left);
            int hr = 1 + depth(root.right);
            if (hl > hr)
                return hl;
            else
                return hr;
        }
        public static Queue<Node> inorder = new Queue<Node>();
        public static void SearchNode(Node root, int depth)
        {
            if (depth == 0)
            {
                inorder.Enqueue(root);
            }
            else
            {
                if (root.left.data != -1)
                {
                    SearchNode(root.left, depth - 1);
                }
                if (root.right.data != -1)
                {
                    SearchNode(root.right, depth - 1);
                }
            }
        }
        static int[][] swapNodes(int[][] indexes, int[] queries)
        {
            /*
             * Write your code here.
             */
            Node root = new Node(1);
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node temp = root;
            int i = 0;
            while (i < indexes.GetLength(0))
            {
                temp = q.Dequeue();
                if (temp.data != -1)
                {
                    Node n1 = new Node(indexes[i][0]);
                    Node n2 = new Node(indexes[i][1]);
                    temp.left = n1;
                    temp.right = n2;
                    q.Enqueue(n1);
                    q.Enqueue(n2);
                    i++;
                }
            }
            int d = depth(root);
            
            int[][] result = new int[queries.Length][];
            int k = 0;
            int mul = 0;
            Stack s = new Stack();
            for (i = 0; i < queries.Length; i++)
            {
                k = queries[i];
                for (int j = 1; j * k <= d; j++)
                {
                    mul = j * k;
                    SearchNode(root, mul-1);
                    while (inorder.Count > 0)
                    {
                        Node t = inorder.Dequeue();
                        temp = t.left;
                        t.left = t.right;
                        t.right = temp;
                    }
                }
                temp = root;
                result[i] = new int[indexes.GetLength(0)];
                k = 0;
                while (temp.data != -1 || s.Count > 0)
                {
                    while (temp.data != -1)
                    {
                        s.Push(temp);
                        temp = temp.left;
                    }
                    temp = s.Pop() as Node;
                    result[i][k++] = temp.data;
                    temp = temp.right;
                }

            }
            return result;
        }

        static void Main(string[] args)
        {
           // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[][] indexes = new int[n][];

            for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
            {
                indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine());

            int[] queries = new int[queriesCount];

            for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine());
                queries[queriesItr] = queriesItem;
            }

            int[][] result = swapNodes(indexes, queries);

            foreach (var item in result)
            {
                foreach (var k in item)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();
            }
            //textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
