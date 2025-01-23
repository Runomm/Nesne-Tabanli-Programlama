using System;

namespace MarketYonetimSistemi
{
    public class KurumsalMusteri : Musteri
    {
        public string VergiNo { get; set; }
        public string SirketAdi { get; set; }
        public override string MusteriBilgisi()
        {
            return "Kurumsal Müşteri: " + SirketAdi + " Vergi No: " + VergiNo;
        }
    }
}
