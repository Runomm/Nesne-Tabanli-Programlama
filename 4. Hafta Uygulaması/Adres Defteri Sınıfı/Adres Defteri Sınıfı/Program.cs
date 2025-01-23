namespace Adres_Defteri_Sınıfı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kisi kisi = new Kisi("Hüsnü", "Çoban", "01234567889");

            Console.WriteLine(kisi.KisiBilgisi());
        }
    }

    public class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }

        // Yapıcı Metot
        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        public string KisiBilgisi()
        {
            return $"{Ad} {Soyad} - Telefon: {TelefonNumarasi}";
        }
    }
}
