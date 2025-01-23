using System;
using System.Collections.Generic;

interface IAbone
{
    void BilgiAl(string mesaj);
}

interface IYayinci
{
    void AboneEkle(IAbone abone);
    void AboneCikar(IAbone abone);
    void BildirimYap(string mesaj);
}

class Yayinci : IYayinci
{
    private List<IAbone> aboneler = new List<IAbone>();

    public void AboneEkle(IAbone abone)
    {
        aboneler.Add(abone);
    }

    public void AboneCikar(IAbone abone)
    {
        aboneler.Remove(abone);
    }

    public void BildirimYap(string mesaj)
    {
        foreach (var abone in aboneler)
        {
            abone.BilgiAl(mesaj);
        }
    }
}

class Abone : IAbone
{
    public string Ad { get; set; }

    public Abone(string ad)
    {
        Ad = ad;
    }

    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{Ad} adlı aboneye bildirim: {mesaj}");
    }
}

class Program
{
    static void Main()
    {
        Yayinci yayinci = new Yayinci();

        Console.WriteLine("Abone sayısını giriniz: ");
        int aboneSayisi = int.Parse(Console.ReadLine());

        for (int i = 0; i < aboneSayisi; i++)
        {
            Console.Write($"Abone {i + 1} adı: ");
            string ad = Console.ReadLine();
            yayinci.AboneEkle(new Abone(ad));
        }

        while (true)
        {
            Console.WriteLine("Bildirim mesajı giriniz (Çıkış için '0'): ");
            string mesaj = Console.ReadLine();
            if (mesaj == "0")
                break;

            yayinci.BildirimYap(mesaj);
        }
    }
}
