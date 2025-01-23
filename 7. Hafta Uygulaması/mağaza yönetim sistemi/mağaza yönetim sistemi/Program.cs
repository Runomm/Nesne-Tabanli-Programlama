using System;
using System.Collections.Generic;

abstract class Urun
{
    public string Ad { get; set; }
    public decimal Fiyat { get; set; }
    public abstract decimal HesaplaOdeme();
    public virtual void BilgiYazdir()
    {
        Console.WriteLine($"Ürün Adı: {Ad}, Fiyat: {Fiyat} TL");
    }
}

class Kitap : Urun
{
    public string Yazar { get; set; }
    public override decimal HesaplaOdeme()
    {
        return Fiyat + Fiyat * 0.1m;
    }
    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Yazar: {Yazar}, Ödenecek Tutar: {HesaplaOdeme()} TL");
    }
}

class Elektronik : Urun
{
    public string Marka { get; set; }
    public override decimal HesaplaOdeme()
    {
        return Fiyat + Fiyat * 0.25m;
    }
    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Marka: {Marka}, Ödenecek Tutar: {HesaplaOdeme()} TL");
    }
}

class Program
{
    static void Main()
    {
        List<Urun> urunler = new List<Urun>();

        while (true)
        {
            Console.WriteLine("Ürün türünü seçiniz (1: Kitap, 2: Elektronik, 0: Çıkış): ");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 0)
                break;

            Urun urun;

            if (secim == 1)
            {
                urun = new Kitap();
                Console.Write("Ürün Adı: ");
                urun.Ad = Console.ReadLine();
                Console.Write("Fiyat: ");
                urun.Fiyat = decimal.Parse(Console.ReadLine());
                Console.Write("Yazar: ");
                ((Kitap)urun).Yazar = Console.ReadLine();
            }
            else if (secim == 2)
            {
                urun = new Elektronik();
                Console.Write("Ürün Adı: ");
                urun.Ad = Console.ReadLine();
                Console.Write("Fiyat: ");
                urun.Fiyat = decimal.Parse(Console.ReadLine());
                Console.Write("Marka: ");
                ((Elektronik)urun).Marka = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
                continue;
            }

            urunler.Add(urun);
        }

        Console.WriteLine("Mağazadaki Ürünler:");
        foreach (var urun in urunler)
        {
            urun.BilgiYazdir();
        }
    }
}
