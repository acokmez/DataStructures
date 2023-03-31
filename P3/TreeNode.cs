using System;

namespace _05180000111_Proje_3
{
    class TreeNode
    {
        public Durak data;
        public Musteri data2;
        public int data3;
        public TreeNode rightChild;
        public TreeNode leftChild;
        public Tree durakAgaci;

        public TreeNode() { }
        public TreeNode(Durak newData)
        {
            durakAgaci = new Tree();
        }

        public void displayNode()
        {
            Console.WriteLine("Müşteri ID:.."+data2.Id+" Kiralama saati:.. "+ data2.KiralamaSaati);

        }
    }
}
