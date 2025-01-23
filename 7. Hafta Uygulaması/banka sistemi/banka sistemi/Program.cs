using System;

abstract class Hesap
{
    public string HesapNo { get; set; }
    public decimal Bakiye { get; set; }
    public string HesapSahibi { get; set; }

    public abstract void ParaYatir(decimal miktar);
    public abstract void ParaCek(decimal miktar);
    public virtual void BilgiYazdir()
    {
        Console.WriteLine($"Hesap No: {HesapNo}, Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye}");
    }
}

class VadesizHesap : Hesap
{
    public decimal EkHesapLimiti { get; set; }

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
    }

    public override void ParaCek(decimal miktar)
    {
        if (miktar <= Bakiye + EkHesapLimiti)
            Bakiye -= miktar;
        else
            Console.WriteLine("Yetersiz bakiye!");
    }

    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti}");
    }
}

class VadeliHesap : Hesap
{
    public int VadeSuresi { get; set; }
    public double FaizOrani { get; set; }

    public override void ParaYatir(decimal miktar)
    {
        Bakiye += miktar + miktar * (decimal)(FaizOrani / 100);
    }

    public override void ParaCek(decimal miktar)
    {
        Console.WriteLine("Vade dolmadan para çekilemez.");
    }

    public override void BilgiYazdir()
    {
        base.BilgiYazdir();
        Console.WriteLine($"Vade Süresi: {VadeSuresi} gün, Faiz Oranı: {FaizOrani}%");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Hesap türünü seçiniz (1: Vadesiz, 2: Vadeli): ");
        int secim = int.Parse(Console.ReadLine());

        Hesap hesap;

        if (secim == 1)
        {
            hesap = new VadesizHesap();
            Console.Write("Hesap No: ");
            hesap.HesapNo = Console.ReadLine();
            Console.Write("Hesap Sahibi: ");
            hesap.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: ");
            hesap.Bakiye = decimal.Parse(Console.ReadLine());
            Console.Write("Ek Hesap Limiti: ");
            ((VadesizHesap)hesap).EkHesapLimiti = decimal.Parse(Console.ReadLine());
        }
        else if (secim == 2)
        {
            hesap = new VadeliHesap();
            Console.Write("Hesap No: ");
            hesap.HesapNo = Console.ReadLine();
            Console.Write("Hesap Sahibi: ");
            hesap.HesapSahibi = Console.ReadLine();
            Console.Write("Bakiye: ");
            hesap.Bakiye = decimal.Parse(Console.ReadLine());
            Console.Write("Vade Süresi (gün): ");
            ((VadeliHesap)hesap).VadeSuresi = int.Parse(Console.ReadLine());
            Console.Write("Faiz Oranı (%): ");
            ((VadeliHesap)hesap).FaizOrani = double.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Geçersiz seçim!");
            return;
        }

        hesap.BilgiYazdir();

        Console.WriteLine("Para yatırma miktarı: ");
        decimal yatirMiktar = decimal.Parse(Console.ReadLine());
        hesap.ParaYatir(yatirMiktar);
        hesap.BilgiYazdir();

        Console.WriteLine("Para çekme miktarı: ");
        decimal cekMiktar = decimal.Parse(Console.ReadLine());
        hesap.ParaCek(cekMiktar);
        hesap.BilgiYazdir();
    }
}
