using System.Numerics;

namespace asal_sayı_bulma
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int total = 0;//toplamların depolanacağı değişken
            Console.WriteLine("Sayı gir:");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i < number; i++)//girilen sayıya kadar her bir sayının test edilmesi
            {
                bool Flag = true;//asal bayrağı
                for (int j = 2; j < i; j++)//i sayısının 2 ye kadar kendinden küçük bütün sayılara bölünerek asal olup olmadığının belirlenmesi
                {
                    if (i % j == 0)
                    {
                        Flag = false;//kalansız bölünme durumunda asal bayrağının düşürülmesi
                    }
                    else
                    {
                        continue;
                    }

                }
                if (Flag)//eğer asal bayrak hiç düşürülmediyse o sayı asaldır ve toplamı eklenir 
                {
                    total += i;
                    Console.WriteLine($"{i} Asaldır.");
                }
            }
            Console.WriteLine($"\"1\"den \"{number}\"e/a kadar olan tüm asal sayıların toplamı: {total}");
        }
    }
}
