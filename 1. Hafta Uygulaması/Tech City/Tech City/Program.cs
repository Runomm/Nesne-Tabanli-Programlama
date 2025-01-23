namespace Tech_City
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mehmet Onur Boyraz
            //Yazılım Mühendisliği İ.Ö.
            //245541023

            //Yukarı aşağı sol sağ
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            //Düğümleri say
            int KurtarRobot(int[,] grid, bool[,] ziyaretEdilen, int startX, int startY)
            {
                int n = grid.GetLength(0);
                if (grid[startX, startY] == 0 || ziyaretEdilen[startX, startY])
                    return 0; //başlangıç düğümü zarar görmüşse

                Stack<(int, int)> yigin = new Stack<(int, int)>();
                yigin.Push((startX, startY));
                ziyaretEdilen[startX, startY] = true;
                int kurtarilanDugumSayisi = 1; //Başlangıç düğümüü kurtar

                //Yığın doluysa devam et
                while (yigin.Count > 0)
                {
                    var current = yigin.Pop();
                    int x = current.Item1;
                    int y = current.Item2;

                    //Yukarı, Aşağı, Sol, Sağ
                    for (int i = 0; i < 4; i++)
                    {
                        int yeniX = x + dx[i];
                        int yeniY = y + dy[i];

                        //sınırlar içinde ve kurtarılabilirse
                        if (yeniX >= 0 && yeniX < n && yeniY >= 0 && yeniY < n &&
                            grid[yeniX, yeniY] == 1 && !ziyaretEdilen[yeniX, yeniY])
                        {
                            yigin.Push((yeniX, yeniY));
                            ziyaretEdilen[yeniX, yeniY] = true;
                            kurtarilanDugumSayisi++;
                        }
                    }
                }

                return kurtarilanDugumSayisi;
            }

            //toplam kurtarılan düğümleri say
            int KurtarilanDugumSayisi(int[,] grid, List<(int, int)> robotlar)
            {
                int n = grid.GetLength(0); //boyut nxn
                bool[,] ziyaretEdilen = new bool[n, n]; //Ziyart edilen düğümler
                int toplamKurtarilan = 0;

                foreach (var robot in robotlar)
                {
                    toplamKurtarilan += KurtarRobot(grid, ziyaretEdilen, robot.Item1, robot.Item2);
                }

                return toplamKurtarilan;
            }

            //Örnek
            int[,] grid = {
                { 1, 1, 0, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 1, 0 },
                { 0, 0, 1, 1 }
            };

            //Robotlaın başlangıç yerleri
            List<(int, int)> robotlar = new List<(int, int)>()
            {
                (0, 0),  //Robot1
                (2, 2),  //Robot2
                (3, 3)   //Robot3
            };

            //Sonuç
            int sonuc = KurtarilanDugumSayisi(grid, robotlar);
            Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {sonuc}");
        }
    }
}
