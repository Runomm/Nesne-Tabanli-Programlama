namespace AltınTapınak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mehmet Onur Boyraz
            //Yazılım Mühendisliği İ.Ö.
            //245541023

            //Yukarı Aşağı Sol Sağ
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            string EnKisaYoluBul(int[,] labirent)
            {
                int n = labirent.GetLength(0); //boyut nxn
                if (labirent[0, 0] == 0 || labirent[n - 1, n - 1] == 0)
                {
                    return "Yol Yok"; // Başlangıç ya da bitiş noktası duvarsa yol yol döndür
                }

                bool[,] ziyaretEdilen = new bool[n, n]; //Ziyaret edilenler
                Queue<(int, int, int)> kuyruk = new Queue<(int, int, int)>(); //(x, y, adım sayısı)

                kuyruk.Enqueue((0, 0, 1)); //Başlangıç noktas
                ziyaretEdilen[0, 0] = true; //ziyaret edildi

                //kuyruk boşalana kadar devam et
                while (kuyruk.Count > 0)
                {
                    var current = kuyruk.Dequeue();
                    int x = current.Item1;
                    int y = current.Item2;
                    int adim = current.Item3;

                    //hazineye ulaşıldıysa adım sayısını döndür
                    if (x == n - 1 && y == n - 1)
                    {
                        return $"En Kısa Yol: {adim} adım";
                    }

                    //4yönde ilerle
                    for (int i = 0; i < 4; i++)
                    {
                        int yeniX = x + dx[i];
                        int yeniY = y + dy[i];

                        //yürünebilir bir yol varsa
                        if (yeniX >= 0 && yeniX < n && yeniY >= 0 && yeniY < n &&
                            labirent[yeniX, yeniY] == 1 && !ziyaretEdilen[yeniX, yeniY])
                        {
                            kuyruk.Enqueue((yeniX, yeniY, adim + 1));
                            ziyaretEdilen[yeniX, yeniY] = true;
                        }
                    }
                }

                return "Yol Yok"; //ulaşılamadıysa "yol yok" döndü
            }

            //örnek
            int[,] labirent = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

            //En kısa yol
            string sonuc = EnKisaYoluBul(labirent);
            Console.WriteLine(sonuc);
        }
    }
}
