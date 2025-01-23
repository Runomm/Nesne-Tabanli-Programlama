namespace Banka_Hesabi_Sinifi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankaHesabi hesap = new BankaHesabi("12345", 1000m);
            hesap.ParaYatir(500m);
            hesap.ParaCek(200m);

            Console.WriteLine("Bakiye: " + hesap.BakiyeGoster() + " TL");
        }
    }

    public class BankaHesabi
    {
        public string HesapNumarasi { get; private set; }
        private decimal Bakiye { get; set; }

        //yapıcı metot
        public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = ilkBakiye;
        }

        //para yatırma
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar; 
            }
        }

        //para çekme
        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && miktar <= Bakiye)
            {
                Bakiye -= miktar; 
            }
        }

        //bakiye bilgisini almak için
        public decimal BakiyeGoster()
        {
            return Bakiye;
        }
    }
}
