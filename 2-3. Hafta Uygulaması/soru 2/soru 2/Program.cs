using System;
using System.Collections.Generic;
using System.Linq;

namespace soru_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //sayıları listeye eklemek için bir liste yap
            var sayilar = new List<int>();

            //kullanıcıdan pozitif sayıları almaya başla
            Console.WriteLine("Pozitif tam sayılar girin (0 girerek bitirin):");
            while (true)
            {
                int sayi;
                //kullanıcının girdiği değeri kontrol et bakalım sayı mı
                while (!int.TryParse(Console.ReadLine(), out sayi) || sayi < 0)
                    Console.WriteLine("Lütfen pozitif bir tam sayı girin");

                if (sayi == 0)
                    break; //eğer sayı 0 ise çıkış yap

                sayilar.Add(sayi); //sayıyı listeye ekle
            }

            if (sayilar.Count == 0)
            {
                Console.WriteLine("Hiç sayı girmediniz");
                return;
            }

            //ortalama hesapla
            double ortalama = sayilar.Average();

            //sayılardan medyan bulmak için listeyi sırala
            sayilar.Sort();
            double medyan;
            int n = sayilar.Count;

            //tek mi çift mi ona göre medyan hesapla
            if (n % 2 == 1)
                medyan = sayilar[n / 2];
            else
                medyan = (sayilar[n / 2 - 1] + sayilar[n / 2]) / 2.0;

            //ortalama ve medyanı ekrana yazdır
            Console.WriteLine($"Ortalama: {ortalama}");
            Console.WriteLine($"Medyan: {medyan}");
        }
    }
}
