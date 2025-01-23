using System;

namespace MarketYonetimSistemi
{
    public class BireyselMusteri : Musteri
    {
        public string TCKimlikNo { get; set; }
        public override string MusteriBilgisi()
        {
            return "Bireysel Müşteri: " + Ad + " " + Soyad + " TCKN: " + TCKimlikNo;
        }
    }
}
