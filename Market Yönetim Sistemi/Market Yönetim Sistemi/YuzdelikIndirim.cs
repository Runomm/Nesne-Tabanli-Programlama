using System;

namespace MarketYonetimSistemi
{
    public class YuzdelikIndirim : Indirim
    {
        public decimal YuzdeOrani { get; set; }
        public override decimal IndirimiHesapla(decimal tutar)
        {
            return tutar - (tutar * YuzdeOrani / 100);
        }
    }
}
