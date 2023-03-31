using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _05180000111_Proje_3
{
    class Durak
    {
        public string DurakAdi;
        public int BosPark;
        public int TandemBisiklet;
        public int NormalBisiklet;
        public List<Musteri> musteriList = new List<Musteri>();

        public Durak()
        {
            this.DurakAdi = null;
            this.BosPark = 0;
            this.TandemBisiklet = 0;
            this.NormalBisiklet = 0;
            this.musteriList = new List<Musteri>();
        }
        public Durak(string tur, int fiyati, int gunsayi, int gecesayi, List<Musteri> musteriList)
        {
            this.DurakAdi = tur;
            this.BosPark = fiyati;
            this.TandemBisiklet = gunsayi;
            this.NormalBisiklet = gecesayi;
            this.musteriList = musteriList;
        }
        public void bisikletAdetGuncelle()
        {
            if (this.BosPark > 5){
                this.NormalBisiklet =  this.NormalBisiklet + 5;
            }

        }
        public void DurakYazdir()
        {
            Console.WriteLine("Durak Adı : " + this.DurakAdi +
                              "  Boş Park: " + this.BosPark +
                              "  Tandem Bisiklet: " + this.TandemBisiklet +
                              "  Normal Bisiklet : " + this.NormalBisiklet);

           
            if (this.musteriList!=null && this.musteriList.Count>0) {
                Console.WriteLine(" Müşteri: ");
            }
            foreach (Musteri musteri in this.musteriList)
            {
                Console.WriteLine("Müşteri ID : " + musteri.Id + " Müşteri Kiralama Saati : " + musteri.KiralamaSaati);
            }
            Console.WriteLine();
        }
    }
}
