using System;

interface IBankaHesabi
{
    DateTime HesapAcilisTarihi { get; set; }
    void HesapOzeti();
}

abstract class Hesap : IBankaHesabi
{
    public string HesapNo { get; set; }
    public decimal Bakiye { get; set; }
    public string HesapSahibi { get; set; }
    public DateTime HesapAcilisTarihi { get; set; }

    public abstract void ParaYatir(decimal miktar);
    public abstract void ParaCek(decimal miktar);

    public virtual void HesapOzeti()
    {
        Console.WriteLine($"Hesap No: {HesapNo}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}, Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
    }
}

class BirikimHesabi : Hesap
{
    public double FaizOrani { get; set; }

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar + miktar * (decimal)(FaizOrani / 100);
    }

    public override void ParaCek(decimal miktar)
    {
        if (miktar <= Bakiye)
            Bakiye -= miktar;
        else
            Console.WriteLine("Yetersiz bakiye!");
    }

    public override void HesapOzeti()
    {
        base.HesapOzeti();
        Console.WriteLine($"Faiz Oranı: {FaizOrani}%");
    }
}

class VadesizHesap : Hesap
{
    public decimal IslemUcreti { get; set; }

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
    }

    public override void ParaCek(decimal miktar)
    {
        if (miktar + IslemUcreti <= Bakiye)
            Bakiye -= (miktar + IslemUcreti);
        else
            Console.WriteLine("Yetersiz bakiye!");
    }

    public override void HesapOzeti()
    {
        base.HesapOzeti();
        Console.WriteLine($"İşlem Ücreti: {IslemUcreti} TL");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Hesap türünü seçiniz (1: Birikim Hesabı, 2: Vadesiz Hesap): ");
        int secim = int.Parse(Console.ReadLine());

        Hesap hesap;

        if (secim == 1)
        {
            hesap = new BirikimHesabi();
            Console.Write("Hesap No: ");
            hesap.HesapNo = Console.ReadLine();
            Console.Write("Hesap Sahibi: ");
            hesap.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: ");
            hesap.Bakiye = decimal.Parse(Console.ReadLine());
            Console.Write("Faiz Oranı (%): ");
            ((BirikimHesabi)hesap).FaizOrani = double.Parse(Console.ReadLine());
        }
        else if (secim == 2)
        {
            hesap = new VadesizHesap();
            Console.Write("Hesap No: ");
            hesap.HesapNo = Console.ReadLine();
            Console.Write("Hesap Sahibi: ");
            hesap.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: ");
            hesap.Bakiye = decimal.Parse(Console.ReadLine());
            Console.Write("İşlem Ücreti: ");
            ((VadesizHesap)hesap).IslemUcreti = decimal.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Geçersiz seçim!");
            return;
        }

        hesap.HesapAcilisTarihi = DateTime.Now;

        hesap.HesapOzeti();

        Console.WriteLine("Para yatırma miktarı: ");
        decimal yatirMiktar = decimal.Parse(Console.ReadLine());
        hesap.ParaYatir(yatirMiktar);
        hesap.HesapOzeti();

        Console.WriteLine("Para çekme miktarı: ");
        decimal cekMiktar = decimal.Parse(Console.ReadLine());
        hesap.ParaCek(cekMiktar);
        hesap.HesapOzeti();
    }
}
