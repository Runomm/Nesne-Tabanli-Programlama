using System;
using System.Data;

namespace soru_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //kullanıcıdan matematiksel ifade alıyoruz
            Console.Write("Bir matematiksel ifade girin: ");
            string ifade = Console.ReadLine();

            //işlemleri çözümlemeye başla ve sırayı göstereceğiz
            Console.WriteLine("İşlemler sırayla çözülüyor...");

            //burda DataTable kullanarak ifadeyi çözümleyip adımları alıcaz
            try
            {
                //çözüm sürecini tutmak için adım adım ayrıştırıyoruz
                string adimAdim = IfadeyiCoz(ifade);
                Console.WriteLine("Çözüm Süreci:");
                Console.WriteLine(adimAdim);
            }
            catch (Exception ex)
            {
                //hata durumunda bunu göster
                Console.WriteLine("Hata oluştu ifadenin geçerli olduğundan emin olun");
            }
        }

        //verilen ifadeyi işlem önceliklerine göre çözümler ve adımları gösterir
        static string IfadeyiCoz(string ifade)
        {
            var dt = new DataTable();
            //ifadeyi işlem adımlarına göre çözüyoruz
            string sonucAdimlari = "";
            while (true)
            {
                try
                {
                    //burda işlem yapıyoruz en son sonucu bulana kadar devam et
                    object sonuc = dt.Compute(ifade, "");
                    sonucAdimlari += $"{ifade} = {sonuc}\n";
                    break;
                }
                catch
                {
                    //başarısız olursa tekrar ifade ile devam ediyoruz
                    Console.WriteLine("ifade çözülemiyor");
                    break;
                }
            }
            return sonucAdimlari;
        }
    }
}
