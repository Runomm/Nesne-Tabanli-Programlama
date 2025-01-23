using System;
using System.Collections.Generic;

namespace soru_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //burda kullanıcıdan sayıları alıyoruz listeye atıyoruz
            Console.WriteLine("Bir dizi tam sayı girin (boş bırakıp Enter'a basarak bitirin):");
            var sayilar = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                if (int.TryParse(input, out int sayi))
                    sayilar.Add(sayi);
                else
                    Console.WriteLine("Lütfen geçerli bir tam sayı girin");
            }

            //şimdi listeyi küçükten büyüğe sırala
            sayilar.Sort();

            //sıralı diziyi yazdır kullanıcıya gösteriyoruz
            Console.WriteLine("Sıralı dizi:");
            Console.WriteLine(string.Join(", ", sayilar));

            //kullanıcıya sor hangisini arıyor onu girsin
            Console.Write("Aramak istediğiniz sayıyı girin: ");
            int hedef;
            while (!int.TryParse(Console.ReadLine(), out hedef))
                Console.Write("Lütfen geçerli bir tam sayı girin");

            //ikili aramayla var mı yok mu bulmaya çalış
            bool sonuc = IkiliArama(sayilar.ToArray(), hedef);

            //sonuç varsa dizide bulundu yaz yoksa bulunmadı yaz
            if (sonuc)
                Console.WriteLine($"{hedef} dizide bulunuyor");
            else
                Console.WriteLine($"{hedef} dizide bulunmuyor");
        }

        //bu kısımda ikili arama algoritması var hedefi bulana kadar dönüyor
        static bool IkiliArama(int[] dizi, int hedef)
        {
            int sol = 0;
            int sag = dizi.Length - 1;

            while (sol <= sag)
            {
                int orta = (sol + sag) / 2;

                if (dizi[orta] == hedef)
                    return true;
                else if (dizi[orta] < hedef)
                    sol = orta + 1;
                else
                    sag = orta - 1;
            }

            return false; //bulamazsak false dön
        }
    }
}
