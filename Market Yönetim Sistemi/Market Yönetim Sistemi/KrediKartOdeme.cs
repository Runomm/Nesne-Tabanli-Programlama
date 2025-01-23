using System;

namespace MarketYonetimSistemi
{
    public class KrediKartOdeme : Odeme
    {
        public string KartNumarasi { get; set; }
        public override string OdemeYap(decimal tutar)
        {
            return "Kredi kartı ile " + tutar + " tutarında ödeme alındı.";
        }
    }
}
