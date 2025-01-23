using System;

namespace MarketYonetimSistemi
{
    public abstract class Musteri
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public abstract string MusteriBilgisi();
    }
}
