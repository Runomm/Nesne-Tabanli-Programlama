using System;

namespace MarketYonetimSistemi
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public Musteri Musteri { get; set; }
        public Sepet Sepet { get; set; }
        public Odeme Odeme { get; set; }
        public Indirim Indirim { get; set; }
        public SiparisDurumu Durum { get; set; }
        public string SiparisTamamla()
        {
            decimal tutar = Sepet.ToplamTutar();
            if (Indirim != null) tutar = Indirim.IndirimiHesapla(tutar);
            return Odeme.OdemeYap(tutar);
        }
    }
}
