using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    class LinkedNode
    {
        private int data;
        private LinkedNode next;

        public LinkedNode(int value) 
        {
            data = value;
            next = null;
        }

        public LinkedNode ReverseList(LinkedNode head)
        {
            LinkedNode prev = null;
            LinkedNode current = head;
            LinkedNode next;

            while (current != null) {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;

            }
            return prev;
        }

        public LinkedNode AddNode(int value)
        {
            LinkedNode node = new LinkedNode(value);
            if (this.next == null) {
                node.next = null;
                this.next = node;
            } else {
                LinkedNode tmp = this.next;
                node.next = tmp;
                this.next = node;
            }
            return node;
        }

        public LinkedNode SortMerge(LinkedNode node1, LinkedNode node2)
        {
            LinkedNode result = new LinkedNode(0);
            LinkedNode tail = result;

            while (true) {
                if (node1 == null) {
                    tail.next = node2;
                    break;
                }
                else if (node2 == null) {
                    tail.next = node1;
                    break;
                }
                if (node1.data >= node2.data) {
                    tail.next = node2;
                    node2 = node2.next;
                }
                else {
                    tail.next = node1;
                    node1 = node1.next;
                }
                tail = tail.next;

            }
            return result.next;
        }

        public LinkedNode MergeSort(LinkedNode head)
        {
            if (head == null || head.next == null) {
                return head;
            }
            LinkedNode front = head;
            LinkedNode tmp2 = head;
            LinkedNode back = null;

            int count = 0;
            while (tmp2 != null) {
                tmp2 = tmp2.next;
                count++;
            }
            int mid = count / 2;
            int x = 0;
            tmp2 = head;
            while (tmp2 != null) {
                x++;
                LinkedNode next = tmp2.next;
                if (x == mid) {
                    tmp2.next = null;
                    back = next;
                }
                tmp2 = next;
            }

            LinkedNode h1 = MergeSort(front);
            LinkedNode h2 = MergeSort(back);

            LinkedNode result = SortMerge(h1, h2);
            return result;
        }
        
        public void PrintNodes(LinkedNode head) {
            if (head == null) {
                head = this;
            }
            while (head != null) {
                System.Console.WriteLine("Node Value: " + head.data);
                head = head.next;
            }
    
        }
    }


}
