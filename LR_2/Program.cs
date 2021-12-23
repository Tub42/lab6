using System;
using System.Collections.Concurrent;

namespace LR_2
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Node[] n = GenerateProbability();
           
            double counter = 0;
            foreach (Node node in n)
            {
                counter += node.probability;
                Console.WriteLine(node.probability);
            }
            Console.WriteLine();
            Console.WriteLine(counter);
            Console.WriteLine();
            Node[] n1 = Huffman(ref n);
            Traverse(n1);
        }

        public static Node[] GenerateProbability()
        {
            Node[] nodes = new Node[19];
            nodes[0] = new Node() { letter = "a" };
            nodes[1] = new Node() { letter = "b" };
            nodes[2] = new Node() { letter = "c" };
            nodes[3] = new Node() { letter = "d" };
            nodes[4] = new Node() { letter = "e" };
            nodes[5] = new Node() { letter = "f" };
            nodes[6] = new Node() { letter = "g" };
            nodes[7] = new Node() { letter = "h" };
            nodes[8] = new Node() { letter = "i" };
            nodes[9] = new Node() { letter = "j" };
            nodes[10] = new Node() { letter = "k" };
            nodes[11] = new Node() { letter = "l" };
            nodes[12] = new Node() { letter = "m" };
            nodes[13] = new Node() { letter = "n" };
            nodes[14] = new Node() { letter = "o" };
            nodes[15] = new Node() { letter = "p" };
            nodes[16] = new Node() { letter = "q" };
            nodes[17] = new Node() { letter = "r" };
            nodes[18] = new Node() { letter = "s" };

            Random rnd = new Random();
            double sum = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].probability = rnd.Next(1, 101);
                sum += nodes[i].probability;
            }
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].probability /= sum;
            }
            Array.Sort(nodes);
            Array.Reverse(nodes);
            return nodes;
        }
        public static Node[] Huffman(ref Node[] nodes)
        {
            if (nodes.Length == 1) return nodes;
            Array.Sort(nodes);
            Array.Reverse(nodes);
            Node end = nodes[nodes.Length - 1];
            Node pre_end = nodes[nodes.Length - 2];
            Node parent = new Node()
            { letter = pre_end.letter + end.letter, probability = pre_end.probability + end.probability, left = end, right = pre_end };
            nodes[nodes.Length - 2] = parent;
            Array.Resize(ref nodes, nodes.Length - 1);
            Huffman(ref nodes);
            return nodes;
        }
        public static void Traverse(Node[] nodes)
        {
            Node root = nodes[0];
            string code = "";
            Traverse(root, code);
        }
        private static void Traverse(Node node, string code)
        {
            if (node.left != null && node.right != null)
            {
                Traverse(node.left, code + "1");
                Traverse(node.right, code + "0");
            }
            if (node.left == null && node.right == null)
            {
                
                Console.WriteLine($"{node.letter}\t{node.probability}\t{code}");
            }
        }
    }
    class Node : IComparable<Node>
    {
        public string letter;
        public double probability;
        public string code;
        public Node left;
        public Node right;
        public Node()
        {
            letter = "a";
            probability = 0;
            code = "";
            left = null;
            right = null;
        }
        public Node(string letter)
        {
            this.letter = letter;
            probability = 0;
            code = "";
            left = null;
            right = null;
        }
        public Node (string letter, double probability, Node left, Node right)
        {
            this.letter = letter;
            this.probability = probability;
            code = "";
            this.left = left;
            this.right = right;
        }
        public int CompareTo(Node n)
        {
            return this.probability.CompareTo(n.probability);
        }
    }
}
