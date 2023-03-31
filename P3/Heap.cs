using System;
using System.Collections.Generic;
using System.Text;

namespace _05180000111_Proje_3
{
    class Heap
    {
        int[] enBuyukDizi;
        public List<TreeNode> heapArray;

        int currentSize;
        int maxSize;
        public Heap()
        {
            heapArray = new List<TreeNode>();
            currentSize = 0;
            maxSize = 9;
            enBuyukDizi = new int[maxSize];
        }

        public void heapPrint()
        {
            foreach (TreeNode node in heapArray)
            {
                Console.WriteLine(node.data3);
            }
        }
        public Boolean insert(int key)
        {
            if (currentSize == maxSize)
            {
                return false;
            }
            TreeNode newNode = new TreeNode();
            newNode.data3 = key;
            heapArray.Insert(currentSize, newNode);
            trickleUp(currentSize++);
            return true;
        }
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            TreeNode bottom = heapArray[index];
            while (index > 0 && heapArray[parent].data3 > bottom.data3)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public TreeNode remove()
        {
            TreeNode root = heapArray[0];
            heapArray.RemoveAt(0);
            trickleDown(0);
            return root;
        }
        public void enFazla()
        {
            selectionSort();
            Console.WriteLine(enBuyukDizi[0] + "         " + enBuyukDizi[1] + "          " + enBuyukDizi[2]);
        }
        public int[] selectionSort()
        {
            for (int y = 0; y < maxSize; y++)
            {
                enBuyukDizi[y] = heapArray[y].data3;
            }
            int temp;
            int maxIndex;
            for (int a = 0; a < enBuyukDizi.Length; a++)
            {
                maxIndex = a;
                for (int b = a; b < enBuyukDizi.Length; b++)
                {
                    if (enBuyukDizi[b] > enBuyukDizi[maxIndex])
                    {
                        maxIndex = b;
                    }
                }
                temp = enBuyukDizi[a];
                enBuyukDizi[a] = enBuyukDizi[maxIndex];
                enBuyukDizi[maxIndex] = temp;
            }
            return enBuyukDizi;
        }
        public void trickleDown(int index)
        {
            int largerChild;
            TreeNode top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && heapArray[leftChild].data3 > heapArray[rightChild].data3)
                {
                    largerChild = rightChild;
                }
                else
                {
                    largerChild = leftChild;
                }
                if (top.data3 < heapArray[largerChild].data3)
                {
                    break;
                }
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
    }
}
