using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSci
{
    class MaxHeap
    {
        private int heap_size;
        private int[] harr;

        public MaxHeap(int cap)
        {
            heap_size = cap;
            harr = new int[cap];
        }

        public void MaxHeapify(MaxHeap mheap, int idx)
        {
            int largest = idx;
            int l = left(idx);
            int r = right(idx);

            if (l < mheap.heap_size && mheap.harr[l] > mheap.harr[largest]) {
                largest = l; 
            }
            if (r < mheap.heap_size && mheap.harr[r] > mheap.harr[largest]) {
                largest = r;
            }
            //change root if needed
            if (largest != idx) {
                int tmp = mheap.harr[largest];
                mheap.harr[largest] = mheap.harr[idx];
                mheap.harr[idx] = tmp;
                MaxHeapify(mheap, largest);
            }
        }

        public int parent(int i)
        {
            return (i - 1) / 2;
        }
        //returns index of left child of node at index 'i'
        public int left(int i)
        {
            return 2 * i + 1;
        }
        //returns index of left child of node at index 'i'
        public int right(int i)
        {
            return 2 * i + 2;
        }
    }
}
