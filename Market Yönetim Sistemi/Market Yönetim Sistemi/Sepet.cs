using System;
using System.Collections.Generic;

namespace MarketYonetimSistemi
{
    public class Sepet
    {
        public List<Urun> Urunler { get; set; } = new List<Urun>();
        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
        }
        public decimal ToplamTutar()
        {
            decimal toplam = 0;
            foreach (var urun in Urunler) toplam += urun.Fiyat;
            return toplam;
        }
    }
}
