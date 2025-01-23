using System;

namespace MarketYonetimSistemi
{
    public class HavaleOdeme : Odeme
    {
        public string IBAN { get; set; }
        public override string OdemeYap(decimal tutar)
        {
            return "IBAN " + IBAN + " ile " + tutar + " tutarında havale alındı.";
        }
    }
}
