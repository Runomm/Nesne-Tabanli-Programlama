using System;
using System.Collections.Generic;

namespace Kutuphane_Sınıfı
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();

            kutuphane.KitapEkle(new Kitap("Karamazov Kardeşler", "Fyodor Dostoyevski", "123456789"));
            kutuphane.KitapEkle(new Kitap("Suç ve Ceza", "Fyodor Dostoyevski", "987654321"));
            kutuphane.KitapEkle(new Kitap("1984", "George Orwell", "135792468"));

            kutuphane.KitaplariListele();
        }
    }

    public class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }

        // Yapıcı Metot
        public Kitap(string ad, string yazar, string isbn)
        {
            Ad = ad;
            Yazar = yazar;
            ISBN = isbn;
        }

        // Kitap bilgilerini döndüren metot
        public override string ToString()
        {
            return $"{Ad} - {Yazar} (ISBN: {ISBN})";
        }
    }

    public class Kutuphane
    {
        // Kitapları tutacak liste
        public List<Kitap> Kitaplar { get; set; }

        // Yapıcı Metot
        public Kutuphane()
        {
            Kitaplar = new List<Kitap>(); 
        }

        // Kitap ekleme metodu
        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"Kitap '{yeniKitap.Ad}' kütüphaneye eklendi.");
        }

        public void KitaplariListele()
        {
            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine(kitap); 
            }
        }
    }
}
