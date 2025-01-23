namespace Araç_Kiralama_Sınıfı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KiralikArac arac = new KiralikArac("01A255", 150);

            Console.WriteLine($"Aracın Plakası: {arac.Plaka}");
            Console.WriteLine($"Günlük Ücret: {arac.GunlukUcret} TL");
            Console.WriteLine($"Araç Musait Mi? {arac.MusaitMi}");

            arac.AraciKirala();

            Console.WriteLine($"Araç Musait Mi? {arac.MusaitMi}");

            arac.AraciTeslimEt();

            Console.WriteLine($"Araç Musait Mi? {arac.MusaitMi}");
        }
    }

    public class KiralikArac
    {
        public string Plaka { get; set; }
        public decimal GunlukUcret { get; set; }
        public bool MusaitMi { get; private set; }

        // Yapıcı Metot
        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true;
        }

        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine("Araç kiralandı.");
            }
            else
            {
                Console.WriteLine("Araç zaten kiralanmış durumda.");
            }
        }

        public void AraciTeslimEt()
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine("Araç teslim alındı.");
            }
            else
            {
                Console.WriteLine("Araç zaten teslim edilmiş.");
            }
        }
    }
}
