using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankPractice
{
    class BinarySearchTree
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

        public static Node insert(Node root, int data)
        {
            if(root==null)
            {
                return new Node(data);
            }
            else
            {
                if(data<=root.data)
                {
                    root.left = insert(root.left, data);
                }
                else
                {
                    root.right = insert(root.right, data);
                }
                return root;
            }
        }

        public static int height(Node root)
        {
            if (root == null)
                return -1;
            else
            {
                int lh = height(root.left) + 1;
                int rh = height(root.right) + 1;
                if (lh > rh)
                    return lh;
                else
                    return rh;
            }
        }
        public static void preorder(Node root)
        {
            if (root == null)
                return;
            else
            {
                Console.Write(root.data+" ");
                preorder(root.left);
                preorder(root.right);
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nodes = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
            Node root = new Node(nodes[0]);
            List<int> list = new List<int>();
            //string s = "rohit";
        
            for(int i = 1; i<n; i++)
            {
                root = insert(root, nodes[i]);
            }
            //int totheight = height(root);
            //Console.WriteLine(totheight); 

            preorder(root);
        }
    }
}
