using System;
using System.Collections.Generic;
using System.Text;

namespace _05180000111_Proje_3
{
    class Musteri
    {
        public int Id { get; set; }
        public int KiralamaSaati { get; set; }

        public Musteri() { }
        public Musteri(int Id, int KiralamaSaati)
        {
            this.Id = Id;
            this.KiralamaSaati = KiralamaSaati;
        }
    }
}
