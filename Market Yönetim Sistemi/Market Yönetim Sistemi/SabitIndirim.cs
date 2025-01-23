using System;

namespace MarketYonetimSistemi
{
    public class SabitIndirim : Indirim
    {
        public decimal SabitTutar { get; set; }
        public override decimal IndirimiHesapla(decimal tutar)
        {
            if (tutar > SabitTutar) return tutar - SabitTutar;
            else return 0;
        }
    }
}
