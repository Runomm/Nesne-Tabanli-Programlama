namespace Ürün_Sınıfı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urun urun = new Urun("Telefon", 5000);

            urun.Indirim = 20;

            Console.WriteLine($"Ürün Adı: {urun.Ad}");
            Console.WriteLine($"Ürün Fiyatı: {urun.Fiyat} TL");
            Console.WriteLine($"İndirim: {urun.Indirim}%");
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat()} TL");
        }
    }

    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }

        private decimal indirim;

        public decimal Indirim
        {
            get { return indirim; }
            set
            {
                if (value < 0)
                    indirim = 0;
                else if (value > 50)
                    indirim = 50;
                else
                    indirim = value;
            }
        }

        // Yapıcı Metot
        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
            Indirim = 0; 
        }

        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - Indirim / 100);
        }
    }
}
