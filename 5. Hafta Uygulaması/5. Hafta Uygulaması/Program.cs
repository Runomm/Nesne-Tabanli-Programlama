
using System;
using System.Collections.Generic;

namespace _5._Hafta_Uygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {





        }
    }


    // Yazar ve Kitap (Bi-directional Association)
    class Yazar
    {
        public string Ad { get; set; }
        public List<Kitap> Kitaplar { get; set; }

        public Yazar(string ad)
        {
            Ad = ad;
            Kitaplar = new List<Kitap>();
        }

        public void KitapEkle(Kitap kitap)
        {
            if (!Kitaplar.Contains(kitap))
            {
                Kitaplar.Add(kitap);
                kitap.Yazar = this;
            }
        }
    }

    class Kitap
    {
        public string Baslik { get; set; }
        public Yazar Yazar { get; set; }

        public Kitap(string baslik)
        {
            Baslik = baslik;
        }
    }






    // Çalışan ve Departman (Uni-directional Association)
    class Departman
    {
        public string Ad { get; set; }

        public Departman(string ad)
        {
            Ad = ad;
        }
    }

    class Calisan
    {
        public string Ad { get; set; }
        public Departman Departman { get; set; }

        public Calisan(string ad, Departman departman)
        {
            Ad = ad;
            Departman = departman;
        }
    }






    // Ürün ve Sipariş (Uni-directional Association)
    class Siparis
    {
        public int Id { get; set; }
        public List<Urun> Urunler { get; set; }

        public Siparis(int id)
        {
            Id = id;
            Urunler = new List<Urun>();
        }

        public void UrunEkle(Urun urun)
        {
            Urunler.Add(urun);
        }
    }

    class Urun
    {
        public string Ad { get; set; }

        public Urun(string ad)
        {
            Ad = ad;
        }
    }






    // Bilgisayar ve İşlemci (Composition)
    class Bilgisayar
    {
        public string Model { get; set; }
        public Islemci Islemci { get; set; }

        public Bilgisayar(string model)
        {
            Model = model;
            Islemci = new Islemci("Intel", "i7");
        }
    }

    class Islemci
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public Islemci(string marka, string model)
        {
            Marka = marka;
            Model = model;
        }
    }






    // Ev ve Oda (Aggregation)
    class Ev
    {
        public string Adres { get; set; }
        public List<Oda> Odalar { get; set; }

        public Ev(string adres)
        {
            Adres = adres;
            Odalar = new List<Oda>();
        }

        public void OdaEkle(Oda oda)
        {
            Odalar.Add(oda);
        }
    }

    class Oda
    {
        public string Tip { get; set; }

        public Oda(string tip)
        {
            Tip = tip;
        }
    }
}
