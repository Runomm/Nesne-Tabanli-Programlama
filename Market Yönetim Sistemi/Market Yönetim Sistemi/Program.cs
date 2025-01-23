using System;
using System.Collections.Generic;

namespace MarketYonetimSistemi
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Müşteri tipi seçiniz (Bireysel/Kurumsal):");
                string musteriTipi = Console.ReadLine().ToLower();
                Musteri musteri = null;

                if (musteriTipi == "bireysel")
                {
                    BireyselMusteri bMusteri = new BireyselMusteri();
                    Console.Write("Müşteri Ad: ");
                    bMusteri.Ad = Console.ReadLine();
                    Console.Write("Müşteri Soyad: ");
                    bMusteri.Soyad = Console.ReadLine();
                    Console.Write("TC Kimlik No: ");
                    bMusteri.TCKimlikNo = Console.ReadLine();
                    bMusteri.Id = 1;
                    musteri = bMusteri;
                }
                else if (musteriTipi == "kurumsal")
                {
                    KurumsalMusteri kMusteri = new KurumsalMusteri();
                    Console.Write("Şirket Adı: ");
                    kMusteri.SirketAdi = Console.ReadLine();
                    Console.Write("Vergi No: ");
                    kMusteri.VergiNo = Console.ReadLine();
                    kMusteri.Id = 2;
                    musteri = kMusteri;
                }
                else
                {
                    Console.WriteLine("Geçersiz tip girildi. Varsayılan olarak bireysel müşteri tanımlanacak.");
                    BireyselMusteri bMusteri = new BireyselMusteri
                    {
                        Id = 1,
                        Ad = "Bilinmeyen",
                        Soyad = "Bilinmeyen",
                        TCKimlikNo = "00000000000"
                    };
                    musteri = bMusteri;
                }

                Sepet sepet = new Sepet();
                bool devam = true;
                while (devam)
                {
                    Console.WriteLine("\nYeni ürün eklemek için ürün adını girin (bırakmak için boş ENTER'a basın):");
                    string urunAdi = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(urunAdi))
                    {
                        devam = false;
                        break;
                    }
                    Console.Write("Ürünün fiyatını girin: ");
                    decimal fiyat = 0;
                    decimal.TryParse(Console.ReadLine(), out fiyat);

                    Urun urun = new Urun
                    {
                        Id = 0, 
                        Ad = urunAdi,
                        Fiyat = fiyat
                    };
                    sepet.UrunEkle(urun);

                    Console.WriteLine("Başka ürün eklemek ister misiniz? (Evet/Hayır)");
                    string yanit = Console.ReadLine().ToLower();
                    if (yanit != "evet")
                    {
                        devam = false;
                    }
                }

                Console.WriteLine("\nÖdeme tipi seçiniz (KrediKart/Nakit/Havale):");
                string odemeTipi = Console.ReadLine().ToLower();
                Odeme odeme = null;

                switch (odemeTipi)
                {
                    case "kredikart":
                        KrediKartOdeme kkOdeme = new KrediKartOdeme();
                        Console.Write("Kart Numarası: ");
                        kkOdeme.KartNumarasi = Console.ReadLine();
                        odeme = kkOdeme;
                        break;
                    case "nakit":
                        odeme = new NakitOdeme();
                        break;
                    case "havale":
                        HavaleOdeme havaleOdeme = new HavaleOdeme();
                        Console.Write("IBAN: ");
                        havaleOdeme.IBAN = Console.ReadLine();
                        odeme = havaleOdeme;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim yapıldı, varsayılan olarak nakit ödeme belirlendi.");
                        odeme = new NakitOdeme();
                        break;
                }

                Console.WriteLine("\nİndirim tipi seçiniz (Yuzdelik/Sabit/Yok):");
                string indirimTipi = Console.ReadLine().ToLower();
                Indirim indirim = null;

                switch (indirimTipi)
                {
                    case "yuzdelik":
                        Console.Write("İndirim yüzdesi (örnek 10): ");
                        decimal oran = 0;
                        decimal.TryParse(Console.ReadLine(), out oran);
                        indirim = new YuzdelikIndirim { YuzdeOrani = oran };
                        break;
                    case "sabit":
                        Console.Write("Sabit indirim tutarı (örnek 15): ");
                        decimal tutar = 0;
                        decimal.TryParse(Console.ReadLine(), out tutar);
                        indirim = new SabitIndirim { SabitTutar = tutar };
                        break;
                    default:
                        Console.WriteLine("İndirim uygulanmadı.");
                        break;
                }

                Siparis siparis = new Siparis
                {
                    SiparisId = 100,  
                    Musteri = musteri,
                    Sepet = sepet,
                    Odeme = odeme,
                    Indirim = indirim,
                    Durum = SiparisDurumu.Onaylandi
                };

                Console.WriteLine("\n--- Sipariş Özeti ---");
                Console.WriteLine(musteri.MusteriBilgisi());
                Console.WriteLine("Sepet Toplam Tutarı: " + sepet.ToplamTutar());
                Console.WriteLine(siparis.SiparisTamamla());
                Console.WriteLine("Sipariş Durumu: " + siparis.Durum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }

            Console.WriteLine("\nProgram sonlandırmak için bir tuşa basınız...");
            Console.ReadLine();
        }
    }
}
