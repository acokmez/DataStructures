using System;
using System.Collections;
using System.Collections.Generic;

namespace _05180000111_Proje_3
{
    class Program
    {
        public static int sirala(int[] dizi, int sol, int sag)
        {
            int pivot = dizi[sag];
            int j = sol - 1;
            int temp = 0;
            for (int i = sol; i < sag; i++)
            {
                if (pivot >= dizi[i])
                {
                    j++;
                    temp = dizi[i];
                    dizi[i] = dizi[j];
                    dizi[j] = temp;
                }
            }
            temp = dizi[j + 1];
            dizi[j + 1] = dizi[sag];
            dizi[sag] = temp;
            return j + 1;
        }
        public static int[] quickSort(int[] dizi, int sol, int sag)
        {
            int sira = 0;
            if (sol < sag)
            {
                sira = sirala(dizi, sol, sag);
                quickSort(dizi, sol, sira - 1);
                quickSort(dizi, sira + 1, sag);
            }
            return dizi;
        }
        public static void selectionSort(int[] dizi)
        {
            int temp;
            int min_index;
            for (int a = 0; a < dizi.Length; a++)
            {
                min_index = a;
                for (int b = a; b < dizi.Length; b++)
                {
                    if (dizi[b] < dizi[min_index])
                    {
                        min_index = b;
                    }
                }
                temp = dizi[a];
                dizi[a] = dizi[min_index];
                dizi[min_index] = temp;
            }
        }


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Heap heap = new Heap();
            Tree tree = new Tree();
            Hashtable hashTable = new Hashtable();

            int[] dizi = { 23, 12, 35, 44, 42, 67, 72, 99, 14 };
            int[] dizi2 = { 45, 8, 23, 54, 51, 67, 78, 32, 11 };
            string[] duraklar = { "İnciraltı, 28, 2, 10", "Sahilevleri, 8, 1, 11", "Doğal Yaşam Parkı, 17, 1, 16",
                                "Bostanlı İskele, 7, 0, 15", "Mavi Bahçe, 6, 1, 16", "Karşıyaka İskele, 4, 2, 13",
                                "Alsancak Garı, 8, 1, 17", "Susuzdede, 11, 0, 14", "Bornova Metro, 7, 0, 15"
                               };
            
            string inputDurakAdi;
            int inputMusteriId;
            int inputIncelemeMusteriId;
            Random rd = new Random();

            for (int a = 0; a < duraklar.Length; a++){
                // 1- A VE B
                string[] durakListe = duraklar[a].Split(',');
                
                // musteri eklemesi ile guncellenecek olan dveri, heap ve treede kullanılacak
                Durak yeniDurak = new Durak();
                yeniDurak.DurakAdi = durakListe[0].Trim();
                yeniDurak.BosPark = Convert.ToInt32(durakListe[1].Trim());
                yeniDurak.TandemBisiklet = Convert.ToInt32(durakListe[2].Trim());
                yeniDurak.NormalBisiklet = Convert.ToInt32(durakListe[3].Trim());

                // musteri eklemesi ile guncellenmeyecek diziden okunacak olan ham veri hashtable a yazılacak
                Durak hamVeriDurak = new Durak();
                hamVeriDurak.DurakAdi = durakListe[0].Trim();
                hamVeriDurak.BosPark = Convert.ToInt32(durakListe[1].Trim());
                hamVeriDurak.TandemBisiklet = Convert.ToInt32(durakListe[2].Trim());
                hamVeriDurak.NormalBisiklet = Convert.ToInt32(durakListe[3].Trim());

                int length = rd.Next(1, 10);
                for (int b = 0; b < length; b++){
                    Musteri musteri = new Musteri();
                    musteri.Id = b+1;
                    musteri.KiralamaSaati = rd.Next(0, 24);
                    yeniDurak.musteriList.Add(musteri);
                    yeniDurak.NormalBisiklet = yeniDurak.NormalBisiklet - 1;
                    yeniDurak.BosPark = yeniDurak.BosPark + 1;
                }

                // agac verisi ekleniyor
                tree.insert(yeniDurak);
                
                // 3 heap ekleniyor
                heap.insert(hamVeriDurak.NormalBisiklet);

                // 2 hashtable verisi yazılıyor
                string key1 = hamVeriDurak.DurakAdi;
                int key2 = hamVeriDurak.NormalBisiklet;
                hashTable.Add(key1, hamVeriDurak);

            } // tree olusturma for u kapandı

            // 2 hashtable
            ICollection Koleksiyon = hashTable.Keys;
            List<string> keys = new List<string>();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("HashTable'ın güncellemeden önceki hali : ");
            foreach (object Anahtar in Koleksiyon)
            {
                Console.WriteLine(Anahtar + "-");
                Durak hashValueDurak = (Durak)hashTable[Anahtar];
                hashValueDurak.DurakYazdir();
                keys.Add(Anahtar.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("HashTable'ın güncellemeden sonraki hali : ");

            foreach (string key in keys){
                Durak hashValueDurak = (Durak)hashTable[key];
                hashTable.Remove(key);
                hashValueDurak.bisikletAdetGuncelle();
                hashTable.Add(hashValueDurak.DurakAdi, hashValueDurak);

                Console.WriteLine(key + "-");
                hashValueDurak.DurakYazdir();
            }


            // 1-C 
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("İnceleme için Müşteri ID  giriniz : ");
            inputIncelemeMusteriId = int.Parse(Console.ReadLine());
            List<Durak> musterininDuraklariList = tree.MusteriInceleme(inputIncelemeMusteriId, tree.root);

            // 1-D
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine();
            Console.Write("Kiralama yapmak istediğiniz durak adını giriniz : ");
            inputDurakAdi = Console.ReadLine();
            Console.Write("Müşteri ID (0-20 aralığında) giriniz : ");
            inputMusteriId = int.Parse(Console.ReadLine());

            Durak kiralama = tree.bisikletKiralat(new Durak(), inputMusteriId, inputDurakAdi, tree.root);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("KİRALAMA İŞLEMİ SONRASI = ");
            Console.WriteLine("Durak: DurakAdi..:" + kiralama.DurakAdi + " BosPark..:" + kiralama.BosPark + " NormalBisiklet..: " + kiralama.NormalBisiklet + " TandemBisiklet..:" + kiralama.TandemBisiklet+ " müsteri sayısı..:"+ kiralama.musteriList.Count);
            foreach (Musteri mm in kiralama.musteriList)
            {
                Console.WriteLine("Musteri: " + mm.Id +" "+mm.KiralamaSaati);
            }

            Console.WriteLine("*************************************************");
            Console.WriteLine("Ağacın Derinliği: " + tree.derinlikBul(tree.root));

            Console.WriteLine("*************************************************");
            Console.WriteLine("Genel Ağaçtaki Eleman Sayısı:" + tree.elemanSayisiBulma(tree.root));

            // 3
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("*************************************************");
            Console.WriteLine("Heap Arrayi: ");
            heap.heapPrint();
            Console.WriteLine("Normal bisiklet adedi en fazla olan 3 adet durak:");
            heap.enFazla();

            // 4
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("*************************************************");
            Console.WriteLine("Dizinin Sıralanmadan Önceki Hali : ");
            for (int z = 0; z < dizi.Length; z++)
            {
                Console.WriteLine(dizi[z]);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Dizinin Selection Sort İle Sıralandıktan Sonraki Hali:");
            selectionSort(dizi);
            for (int w = 0; w < dizi.Length; w++)
            {
                Console.WriteLine(dizi[w]);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("*************************************************");
            Console.WriteLine("Dizinin Sıralanmadan Önceki Hali : ");
            for (int p = 0; p < dizi2.Length; p++)
            {
                Console.WriteLine(dizi2[p]);
            }
            Console.WriteLine("Dizinin Quick Sort İle Sıralandıktan Sonraki Hali : ");
            quickSort(dizi2, 0, dizi2.Length - 1);
            for (int m = 0; m < dizi2.Length; m++)
            {
                Console.WriteLine(dizi2[m]);
            }

            
            Console.ReadKey();
        }
    }
}

