using System;

namespace MarketYonetimSistemi
{
    public class NakitOdeme : Odeme
    {
        public override string OdemeYap(decimal tutar)
        {
            return "Nakit olarak " + tutar + " tutarında ödeme alındı.";
        }
    }
}
