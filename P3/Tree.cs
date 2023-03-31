using System;
using System.Collections.Generic;
using System.Text;

namespace _05180000111_Proje_3
{
    class Tree
    {
        public TreeNode root;
        public void InOrder(TreeNode localRoot)//Sırayla ağacı printler.
        {
            if (localRoot != null)
            {
                InOrder(localRoot.leftChild);
                localRoot.displayNode();
                InOrder(localRoot.rightChild);
            }
        }
        public void insert(Durak newData)//En genel ağaca Tür tipinde düğüm ekleme metodu.
        {
            TreeNode newNode = new TreeNode(newData);
            newNode.data = newData;
            if (root == null)
            {
                root = newNode;
                foreach (Musteri f in newNode.data.musteriList)
                {
                    newNode.durakAgaci.insertTreeToTree(f);
                }
                Console.WriteLine(newData.DurakAdi + " bilgileri : BosPark..:" + newData.BosPark + " NormalBisiklet:.." + newData.NormalBisiklet + " TandemBisiklet..:" + newData.TandemBisiklet + " müsteri sayısı..:" + newData.musteriList.Count);
                Console.WriteLine(newData.DurakAdi + " ağacı içerisindeki musteri ağacı : ");
                newNode.durakAgaci.InOrder(newNode.durakAgaci.root);
                Console.WriteLine(newData.DurakAdi + " Düğümlerdeki derinlik ortalaması : " + newNode.durakAgaci.derinlikBul(newNode.durakAgaci.root));
                Console.WriteLine("******************************************************");
            }
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newData.DurakAdi.CompareTo(current.data.DurakAdi) == -1)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            foreach (Musteri d in newNode.data.musteriList)
                            {
                                newNode.durakAgaci.insertTreeToTree(d);
                            }                            
                            Console.WriteLine(newData.DurakAdi + " bilgileri : BosPark..:" + newData.BosPark + " NormalBisiklet:.." + newData.NormalBisiklet + " TandemBisiklet..:" + newData.TandemBisiklet + " müsteri sayısı..:" + newData.musteriList.Count);
                            Console.WriteLine(newData.DurakAdi +" ağacı içerisindeki musteri ağacı : ");
                            newNode.durakAgaci.InOrder(newNode.durakAgaci.root);
                            Console.WriteLine(newData.DurakAdi +  " düğümlerdeki derinlik ortalaması : " + newNode.durakAgaci.derinlikBul(newNode.durakAgaci.root));
                            Console.WriteLine("******************************************************");
                            return;
                        }

                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            foreach (Musteri e in newNode.data.musteriList)
                            {
                                newNode.durakAgaci.insertTreeToTree(e);

                            }
                            Console.WriteLine(newData.DurakAdi + " bilgileri : BosPark..:" + newData.BosPark + " NormalBisiklet:.." + newData.NormalBisiklet + " TandemBisiklet..:" + newData.TandemBisiklet + " müsteri sayısı..:" + newData.musteriList.Count);
                            Console.WriteLine(newData.DurakAdi + " ağacı içerisindeki musteri ağacı : ");
                            newNode.durakAgaci.InOrder(newNode.durakAgaci.root);
                            Console.WriteLine(newData.DurakAdi + " Düğümlerdeki derinlik ortalaması : " + newNode.durakAgaci.derinlikBul(newNode.durakAgaci.root));
                            Console.WriteLine("******************************************************");
                            return;
                        }
                    }
                }
            }
        }

        public void insertTreeToTree(Musteri eleman)//Düğüm içinde Müşteri için ağaç oluşturur.
        {
            TreeNode newNode = new TreeNode();
            newNode.data2 = eleman;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (eleman.Id < current.data2.Id)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }

                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        public List<Durak> MusteriInceleme (int musteriId, TreeNode localRoot)
        {
            List<Durak> musteriNodes = new List<Durak>();
            if (localRoot != null)
            {
                MusteriInceleme(musteriId, localRoot.leftChild);
                for (int i = 0; i<localRoot.data.musteriList.Count; i++) {
                    if (localRoot.data.musteriList[i].Id == musteriId) {
                        musteriNodes.Add(localRoot.data);
                        Console.WriteLine("Durak adı..: " +localRoot.data.DurakAdi + "  musteri ID..:" + localRoot.data.musteriList[i].Id + " Kiralama Saati..:" + localRoot.data.musteriList[i].KiralamaSaati);
                    }
                }
                MusteriInceleme(musteriId, localRoot.rightChild);
            }
            return musteriNodes;
        }

        public Durak bisikletKiralat(Durak durak,int musteriId, String durakAdi, TreeNode localRoot){
            Random rd = new Random();
            if (localRoot != null && durak.DurakAdi == null){
                if (localRoot.data.DurakAdi.CompareTo(durakAdi) == 0){
                    Musteri yeniMusteri = new Musteri(musteriId, rd.Next(0, 24));
                    localRoot.data.musteriList.Add(yeniMusteri);
                    localRoot.data.BosPark = localRoot.data.BosPark + 1;
                    localRoot.data.NormalBisiklet = localRoot.data.NormalBisiklet - 1;
                    durak = localRoot.data;
                    return durak;
                }else{
                    durak = bisikletKiralat(durak, musteriId, durakAdi, localRoot.leftChild);
                    durak = bisikletKiralat(durak, musteriId, durakAdi, localRoot.rightChild);
                }
            }
            return durak;
        }

        public int derinlikBul(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }
            else
            {
                int lDepth = derinlikBul(root.leftChild);
                int rDepth = derinlikBul(root.rightChild);
                if (lDepth > rDepth)
                {
                    return (lDepth + 1);
                }
                else
                {
                    return (rDepth + 1);
                }
            }
        }



        public int elemanSayisiBulma(TreeNode localRoot)
        {
            int sayi = 1;
            if (localRoot.leftChild != null)
            {
                sayi += elemanSayisiBulma(localRoot.leftChild);
            }
            if (localRoot.rightChild != null)
            {
                sayi += elemanSayisiBulma(localRoot.rightChild);
            }
            return sayi;
        }


    }
}
