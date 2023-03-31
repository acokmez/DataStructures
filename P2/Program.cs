using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _05180000111_proje2
{
    class Musteri
    {
        public String musteriAdi;
        public int urunSayisi;

        public Musteri(String musteriAdi, int urunSayisi)
        {
            this.musteriAdi = musteriAdi;
            this.urunSayisi = urunSayisi;
        }
    }
    class Stack
    {
        public int maxSize; 
        public Musteri[] stackArray;
        public int top;

        public Stack(int s) 
        {
            maxSize = s;
            stackArray = new Musteri[maxSize]; 
            top  = -1; 
        }

        public void add(Musteri j) 
        {
            stackArray[++top] = j; 
        }

        public Musteri pop() 
        {
            return stackArray[top--]; 
        }

        public Musteri peek()
        {
            return stackArray[top];
        }

        public bool isEmpty() 
        {
            return (top == -1);
        }

        public bool isFull() 
        {
            return (top == maxSize - 1);
        }
    }

    class Queue
    {
        private int maxSize;
        private Musteri[] queArray;
        private int front;
        private int rear;
        private int nItems;
      
        public Queue(int s) 
        {
            maxSize = s;
            queArray = new Musteri[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        
        public void insert(Musteri j) 
        {
            if (rear == maxSize - 1) 
                rear = -1;
            queArray[++rear] = j;
            nItems++; 
        }
        
        public Musteri remove()
        {
            Musteri temp = queArray[front++]; 
            if (front == maxSize) 
                front = 0;
            nItems--; 
            return temp;
        }
        
        public Musteri peekFront() 
        { 
            return queArray[front];
        }
        
        public bool isEmpty() 
        {
            return (nItems == 0);
        }
        
        public bool isFull() 
        {
            return (nItems == maxSize);
        }
        
        public int size() 
        {
            return nItems;
        }
    }

    class PQ
    {
        List<Musteri> musteriList;

        public PQ() { musteriList = new List<Musteri>(); }

        public void ekle(Musteri musteri)
        { musteriList.Add(musteri); }

        public Musteri silMax()
        {
            Musteri max = musteriList[0];
            int maxUrunSayisi = musteriList[0].urunSayisi;
            int maxIndex = 0;
            for (int i = 1; i < musteriList.Count; ++i)
            {
                if (musteriList[i].urunSayisi > maxUrunSayisi)
                {
                    max = musteriList[i];
                    maxUrunSayisi = max.urunSayisi;
                    maxIndex = i;
                }
            }
            musteriList.RemoveAt(maxIndex);
            return max;
        }

        public Musteri silMin()
        {
            Musteri minMusteri = musteriList[0];
            int minUrunSayisi = musteriList[0].urunSayisi;
            int minIndex = 0;
            for (int i = 1; i < musteriList.Count; ++i)
            {
                if (musteriList[i].urunSayisi < minUrunSayisi)
                {
                    minUrunSayisi = musteriList[i].urunSayisi;
                    minMusteri = musteriList[i];
                    minIndex = i;
                }
            }
            musteriList.RemoveAt(minIndex);
            return minMusteri;
        }

        public bool bosMu() { return musteriList.Count == 0; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            string[] musteriAdi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] urunSayisi = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };

            ArrayList arrayListe = new ArrayList();
            Random rnd = new Random();
            Stack stack = new Stack(musteriAdi.Length);
            Queue queue = new Queue(musteriAdi.Length);
            Queue queueOrtalama = new Queue(musteriAdi.Length);
            PQ priorityQueue = new PQ();
            PQ priorityQueueOrtalama = new PQ();
            int sayac = 0;
            int sayac2 = 0;
            int musteriler = 0;
            Musteri musteri;

            List<Musteri> genericListe;
            while (sayac < musteriAdi.Length)
            {
                genericListe = new List<Musteri>();
                int genericListeLength = rnd.Next(1, 6);
                for (int i = 0; i < genericListeLength; i++)
                {
                    musteri = new Musteri(musteriAdi[sayac], urunSayisi[sayac]);
                    stack.add(musteri);
                    queue.insert(musteri);
                    queueOrtalama.insert(musteri);
                    genericListe.Add(musteri);
                    priorityQueue.ekle(musteri);
                    priorityQueueOrtalama.ekle(musteri);
                    musteriler++;
                    sayac++;

                    if (sayac == musteriAdi.Length)
                        break;
                }
                arrayListe.Add(genericListe);
                sayac2++;
            }

            printList(arrayListe);
            Console.ReadKey();

            Console.WriteLine("ArrayList eleman sayısı: ");
            int arrayLength = arrayListe.Count;
            Console.WriteLine(arrayLength);
            Console.WriteLine("*************************");
            Console.WriteLine("Listelerin ortalama eleman sayısı: ");
            Console.WriteLine(musteriler / arrayLength);
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Stack yazdırılıyor......");
            printStack(stack, musteriler);
            Console.WriteLine();
            Thread.Sleep(3000);
            Console.WriteLine("Queue yazdırılıyor......");
            printQueue(queue, musteriler);
            Console.WriteLine();
            Thread.Sleep(3000);
            Console.WriteLine("Priority Queue yazdırılıyor......");
            printPriorityQueue(priorityQueue, musteriler);
            Console.WriteLine();
            Console.ReadKey();

            double toplamQueueUrun = 0;
            double toplamQueueEleman = 0;
            double tempQueue = 0;
            Console.WriteLine("Queue yapısı için: ");
            for (int a = 0; a < musteriler; a++)
            {
                Musteri cikarilanMus = queueOrtalama.remove();
                Console.WriteLine(a+1 + ". Müşteri için işlem tamamlama süresi " + cikarilanMus.urunSayisi);
                toplamQueueUrun += cikarilanMus.urunSayisi ;
                toplamQueueEleman += 1;
                tempQueue += toplamQueueUrun;
            }
            Console.WriteLine("Queue yapısı için ortalama işlem tamamlama süresi: " + tempQueue / toplamQueueEleman + "\n");
            
            double PQurunSayisi = 0;
            double PQelemanSayisi = 0;
            double tempPQ = 0;
            Console.WriteLine("Öncelikli Kuyruk yapısı için: ");
            for (int g = 0; g < musteriler; g++)
            {
                Musteri cikarilanMus = priorityQueueOrtalama.silMax();
                Console.WriteLine(g + 1 + ". Müşteri için işlem tamamlama süresi " + cikarilanMus.urunSayisi);
                PQurunSayisi += cikarilanMus.urunSayisi;
                PQelemanSayisi += 1;
                tempPQ += PQurunSayisi;
            }
            Console.WriteLine("Öncelikli Kuyruk yapısı için ortalama işlem tamamlama süresi: " + tempPQ / PQelemanSayisi);
            Console.ReadKey();
        }

        static void printList(ArrayList arrayListe)
        {
            Console.WriteLine("Bileşik Veri Yapısı yazdırılıyor......" + "\n");
            foreach (List<Musteri> item in arrayListe)
            {
                foreach (Musteri item1 in item)
                {
                    Console.WriteLine("{0}, {1}", item1.musteriAdi, item1.urunSayisi);
                    
                }
                Console.WriteLine("***********");
            }
        }

        static void printStack (Stack stack, int musteriler)
        {
            for (int a = 0; a < musteriler; a++)
            {
                Musteri cikarilanMus = stack.pop();
                Console.WriteLine("Müşteri Adı : " + cikarilanMus.musteriAdi + " Ürün Sayısı : " + cikarilanMus.urunSayisi);
                Console.WriteLine("*************************************");
            }
        }

        static void printQueue(Queue queue, int musteriler)
        {
            for (int a = 0; a < musteriler; a++)
            {
                Musteri cikarilanMus = queue.remove();
                Console.WriteLine("Müşteri Adı : " + cikarilanMus.musteriAdi + " Ürün Sayısı : " + cikarilanMus.urunSayisi);
                Console.WriteLine("*************************************");
            }
        }

        static void printPriorityQueue(PQ pqueue, int musteriler)
        {
            for (int a = 0; a < musteriler; a++)
            {
                Musteri cikarilanMus = pqueue.silMax(); // max silmek için
                //Musteri cikarilanMus = pqueue.silMin(); // min silmek için

                Console.WriteLine("Müşteri Adı : " + cikarilanMus.musteriAdi + " Ürün Sayısı : " + cikarilanMus.urunSayisi);
                Console.WriteLine("*************************************");
            }
        }
    }
}
