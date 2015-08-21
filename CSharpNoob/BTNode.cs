using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	 class BTNode
	 {
		private int data;
		private BTNode left;
		private BTNode right;



		public BTNode AddNode(int value)
		{
			BTNode tmp = new BTNode();
			tmp.data = value;
			return tmp;
		}


		public int GetTreeHeight(BTNode node)
		{
				int x = 0;
				if (node == null) {
					 return 0;
				}
				else {
					 x = 1 + Math.Max(GetTreeHeight(node.left), GetTreeHeight(node.right));
				}
				return x;
		  }
		public void PrintGivenLevel(BTNode node, int level)
		  {
				if (node == null || level < 1) {
					 return;
				}
				if (level == 1) {
					 System.Console.Write(" " + node.data + " ");
				} else {
					 PrintGivenLevel(node.left, level - 1);
					 PrintGivenLevel(node.right, level - 1);
				}
		  }

		public void PrintLevelOrder(BTNode node)
		  {
				if (node == null) {
					 return;
				}
				int height = GetTreeHeight(node);
				for (int i = 1; i <= height; i++) {
					 PrintGivenLevel(node, i);
				}
				
		  }

		public BTNode ReflectTree(BTNode node)
		  {
				if (node == null) {
					 return null;
				}

				BTNode tmp = node;
				BTNode swpNode = tmp.left;

				tmp.left = ReflectTree(tmp.right);
				tmp.right = ReflectTree(swpNode);
									 
				return tmp;
		  }

		public BTNode ReflectTreeIter(BTNode node)
		{
			BTNode tmp = node;
			
			BTNode holder;
			Queue que = new Queue();
			que.Enqueue(tmp);

			while (que.Count > 0)
			{
				tmp = (BTNode) que.Dequeue();
				if (tmp.left != null)
				{
					que.Enqueue(tmp.left);
				}
				if (tmp.right != null)
				{
					que.Enqueue(tmp.right);
				}
				holder = tmp.left;
				tmp.left = tmp.right;
				tmp.right = holder;
			}

			return node;

		}

		public void PrintInOrderTraversal(BTNode node)
		{
			if (node == null) {
					return;
			}
			else {
					PrintInOrderTraversal(node.left);
					System.Console.Write(" " + node.data + " ");
					PrintInOrderTraversal(node.right);
			}
		}

		public void PrintPreOrderTraversal(BTNode node)
		{
			if (node == null) {
					return;
			}
			else {
					System.Console.Write(" " + node.data + " ");
					PrintPreOrderTraversal(node.left);
					PrintPreOrderTraversal(node.right);
			}
		}

		public void PrintPostOrderTraversal(BTNode node)
		{
			if (node == null) {
					return;
			}
			else {
					PrintPostOrderTraversal(node.left);
					PrintPostOrderTraversal(node.right);
					System.Console.Write(" " + node.data + " ");
			}
		}
		/* PreOrder Traversal Using Stacks */
		/* Note if a queue was used instead, then it becomes a Breadth-First Search  */
		public void StackPreOrderTraversal(BTNode node)
		{
			if (node == null) {
					return;
			}
			else {
					Stack nodeStack = new Stack();

					nodeStack.Push(node);
					BTNode tmp = node;
 
					while (nodeStack.Count > 0) {
						while (tmp.left != null) {
							tmp = tmp.left;
							nodeStack.Push(tmp);
						}
						while (nodeStack.Count > 0) {
							tmp = (BTNode) nodeStack.Pop();
							System.Console.Write(" " + tmp.data + " ");
							if (tmp.right != null) {
									tmp = tmp.right;
									nodeStack.Push(tmp);
									break;
							}
						}
					}
			}
		}

		/* PostOrder Traversal Using 2x Stacks */
		public void StackPostOrderTraversal(BTNode node)
		{
			Stack s1 = new Stack();
			Stack s2 = new Stack();
			BTNode tmp;
			if (node != null) {
					s1.Push(node);
			}

			while (s1.Count > 0) {
					tmp = (BTNode) s1.Pop();
					s2.Push(tmp);
					if (tmp.left != null) {
						s1.Push(tmp.left);
					}
					if (tmp.right != null) {
						s1.Push(tmp.right);
					}
			}
			foreach (BTNode item in s2) {
					System.Console.Write(" " + item.data);
			}
				
		}

		public void TestBTNode()
		{
			BTNode head = this;
			head.data = 1;
			head.left = AddNode(2);
			head.right = AddNode(3);
			head.left.left = AddNode(4);
			head.left.right = AddNode(5);
			head.right.left = AddNode(6);
			head.right.right = AddNode(7);

			System.Console.WriteLine("Tree Structure is created as:");
			PrintLevelOrder(head);
			System.Console.WriteLine("\nNow printing Inorder Traversal");
			PrintInOrderTraversal(head);
			System.Console.WriteLine("\nNow printing PreOrder Traversal");
			PrintPreOrderTraversal(head);
			System.Console.WriteLine("\nNow printing PostOrder Traversal (Recursive)");
			PrintPostOrderTraversal(head);
			System.Console.WriteLine("\nNow printing PreOrder Traversal");
			StackPreOrderTraversal(head);
			System.Console.WriteLine("\nNow printing PostOrder Traversal (Iterative)");
			StackPostOrderTraversal(head);
			System.Console.WriteLine("\nNow printing reflection");
			BTNode mirror = ReflectTree(head);
			PrintLevelOrder(mirror);
			System.Console.WriteLine("\n");
			System.Console.WriteLine("\nNow printing tree's current state");
			PrintLevelOrder(head);
			System.Console.WriteLine("\nNow printing reflection done iteratively");
			mirror = ReflectTreeIter(head);
			PrintLevelOrder(mirror);
			System.Console.WriteLine("\n");
		}

	 }
}
