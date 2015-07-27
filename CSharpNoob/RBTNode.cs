using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
	/* This is an implementation of a Left-Leaning Red-Black Tree, which is based
	* off the concept of a 2-3 Tree to offer self-balance and guarantee O(lg n) 
	* Insert / Delete / Lookup time.
	* A Red-Black Tree must always follow these properties:
	*   1.  Every node is red or black
	*   2.  Root node is always black by default (can be changed, but always reverted back)
	*   3.  There are no consecutive red nodes; a red node must have black parent/child nodes.
	*   4.  Each path from root to null node has the same # of black links; "perfect black balance"
	*/
	class RBTNode
	{
		private static RBTNode root;
		private int data;
		private RBTNode left;
		private RBTNode right;
		private bool red;

		public RBTNode(int value, bool isRed)
		{
			data = value;
			red = isRed;
		}

		public RBTNode RotateLeft(RBTNode head)
		{
			RBTNode tmp = head;
			if (head.right.red)
			{
				tmp = head.right;
				head.right = tmp.left;
				tmp.left = head;
				tmp.red = head.red;
                if (head == root)
				{
					//rotated the root node out, update root node and remain black
					root = tmp;
					tmp.red = false;
				}
				
				head.red = true;
			}

			return tmp;
		}
		public RBTNode RotateRight(RBTNode head)
		{
			RBTNode tmp = head;
			if (head.left.red)
			{
				tmp = head.left;
				head.left = tmp.right;
				tmp.right = head;
				tmp.red = head.red;
				if (head == root)
				{
					//rotated the root node out, update root node and remain black
					root = tmp;
					tmp.red = false;
				}

				head.red = true;
			}

			return tmp;
		}
		public RBTNode FlipColors(RBTNode head)
		{
			//only flip if parent node is not red & both child nodes are red
			if (!head.red && head.left.red && head.right.red)
			{
				//if parent is the root, which always has to be black, don't flip the color
				if (head != root)
				{
					head.red = true;
				}
				head.left.red = false;
				head.right.red = false;
			}
			return head;
		}
		public RBTNode Insert(RBTNode head, int value)
		{
			RBTNode node;
			//if empty tree, create root/leaf node, which is always black
			if (head == null)
			{
				node = new RBTNode(value, false);
				//if root node hasn't been set, then assume empty tree and set it now
				if (root == null) { root = node; }

				return node;
			}
			else
			{
				//Standard Binary Search Tree Insert
				if (value < head.data)
				{
					head.left = Insert(head.left, value);
				} else if (value > head.data)
				{
					head.right = Insert(head.right, value);
				} else
				{
					head.data = value;
				}
			}
			//if we have a red node on the right, then rotate left to
			//maintain the the left-leaning red property.
			if (head.right.red && !head.left.red)
			{
				head = RotateLeft(head);
			} 
			//case where we have 2 consecutive red nodes 
			if (head.left.red && head.left.left.red)
			{
				head = RotateRight(head);
			}
			//case where we have a node with 2 red links; 
			if (head.left.red && head.right.red)
			{
				head = FlipColors(head);
			}
			return head;
		}

	}


}
