using System;
using System.Collections.Generic;

namespace soru_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bir liste oluştur kullanıcıdan gelen sayıları atıcaz
            var sayilar = new List<int>();

            //kullanıcıdan pozitif tam sayıları almaya başla 0 girince duracak
            Console.WriteLine("Bir dizi tam sayı girin (0 girerek bitirin):");
            while (true)
            {
                int sayi;
                //sayının geçerli olup olmadığını kontrol et
                while (!int.TryParse(Console.ReadLine(), out sayi))
                    Console.WriteLine("Lütfen geçerli bir tam sayı girin");

                if (sayi == 0)
                    break; //0 girince döngüden çık

                sayilar.Add(sayi); //listeye ekle
            }

            //sayiları sırala ardışık grupları daha kolay bulalım
            sayilar.Sort();

            //ardışık grupları tespit et ve grupları tut
            var ardışıkGruplar = new List<string>();
            int baslangic = sayilar[0];
            int onceki = sayilar[0];

            for (int i = 1; i < sayilar.Count; i++)
            {
                //ardışık mı değil mi kontrol ediyoruz
                if (sayilar[i] != onceki + 1)
                {
                    //grubu tamamla ve listeye ekle
                    if (baslangic == onceki)
                        ardışıkGruplar.Add(baslangic.ToString());
                    else
                        ardışıkGruplar.Add($"{baslangic}-{onceki}");

                    //yeni grubun başlangıcı burdan itibaren
                    baslangic = sayilar[i];
                }
                //öncekiyi güncelle
                onceki = sayilar[i];
            }

            //son grubu da ekleyelim
            if (baslangic == onceki)
                ardışıkGruplar.Add(baslangic.ToString());
            else
                ardışıkGruplar.Add($"{baslangic}-{onceki}");

            //bulunan grupları yazdır
            Console.WriteLine("Ardışık gruplar:");
            Console.WriteLine(string.Join(", ", ardışıkGruplar));
        }
    }
}
