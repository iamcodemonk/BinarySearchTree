using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{
    class BinarySearchTree
    {
        #region Node Class
        class Node
        {
            internal int data;
            internal protected Node left;
            internal Node right;

            public Node(int d)
            {
                data = d;
                left = right = null;
            }
        }
        #endregion

        Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        #region Insert a recod
        public void Insert(int data) {
            root = InsertRec(root, data);
        }

         Node InsertRec(Node root, int data)
        {
            if(root  == null)
            {
                root = new Node(data);
                return root;
            }

            if(data < root.data)
            {
                root.left = InsertRec(root.left, data);
            }
            else if(data > root.data)
            {
                root.right = InsertRec(root.right, data);
            }

            return root;
         }
#endregion


        #region Inorder traversal
        public void Inorder()
        {
             InorderRec(root);
        }
        void InorderRec(Node root)
        {
            if(root != null)
            {
                InorderRec(root.left);
                Console.Write(root.data + " ");
                InorderRec(root.right);
            }
        }
        #endregion


        #region To search an element in the tree
        public void Search(int key)
        {
            var x =  SearchRec(root, key);
            Console.WriteLine(x);
        }

        bool SearchRec(Node root, int key)
        {
            if (root == null)
                return false;
            if (root.data == key)
                return true;
            else if (key <= root.data)
                return SearchRec(root.left, key);
            else if (key > root.data)
                return SearchRec(root.right, key);
            return false;
        }
        #endregion


        #region To find MIn element of Tree
        public void FindMin()
        {
           int x =  FindMinRec(root);
            Console.WriteLine($"Min is {x}");
        }

        int FindMinRec(Node root)
        {
            Node temp = root;
            while (temp.left != null)
                temp = temp.left;
            return temp.data;
        }
        #endregion


        #region To find Height of Tree
        public void FindHeight()
        {
            Console.WriteLine(FindHeightRec(root)); 
        }

        int FindHeightRec(Node root)
        {
            if(root == null)
                return -1;
            return Math.Max(FindHeightRec(root.left), FindHeightRec(root.right)) + 1;
        }
        #endregion


        #region level order
        public void LevelOrder()
        {
            LevelOrderTravelsal(root);
        }

        void LevelOrderTravelsal(Node root)
        {
            if (root == null)
                return;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Console.WriteLine("Level order Traversal");

            while(q.Count != 0)
            {
                Node current = q.First();
                Console.Write($"{current.data} - ");
                if (current.left != null)
                    q.Enqueue(current.left);
                if (current.right != null)
                    q.Enqueue(current.right);
                q.Dequeue(); 
            }
        }
        #endregion

    }


    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();

            bst.Insert(55);
            bst.Insert(50);
            bst.Insert(52);
            bst.Insert(54);
            bst.Insert(56);
            bst.Inorder();

            bst.Search(50);

            bst.FindMin();
      
            bst.FindHeight();

            bst.LevelOrder();
        }
    }
}
