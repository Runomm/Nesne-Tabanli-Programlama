namespace soru_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = {
                { 1, 3, 5 },
                { 2, 1, 2 },
                { 4, 3, 1 }
            }; //örnek enerji matrisi

            int minEnergy = MinEnergyPath(grid);
            Console.WriteLine("En az enerjiyle hedefe ulaşmak için gereken toplam enerji: " + minEnergy);
        }

        //enerji matrisinde en az maliyetli yolu bulan fonksiyon
        static int MinEnergyPath(int[,] grid)
        {
            int n = grid.GetLength(0);
            int[,] dp = new int[n, n];

            //ilk hücreye ulaşmanın maliyeti kendisi
            dp[0, 0] = grid[0, 0];

            //ilk satırı dolduruyoruz (sadece sağa gidilebileceğinden)
            for (int i = 1; i < n; i++)
                dp[0, i] = dp[0, i - 1] + grid[0, i];

            //ilk sütunu dolduruyoruz (sadece aşağı gidilebileceğinden)
            for (int i = 1; i < n; i++)
                dp[i, 0] = dp[i - 1, 0] + grid[i, 0];

            //geri kalan hücreleri dolduruyoruz
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    //sol, üst ve diyagonel değerlerden en küçüğünü buluyoruz
                    int minPrevious = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                    dp[i, j] = minPrevious + grid[i, j]; //minimum maliyetle hücreye ulaşma
                }
            }

            //hedef hücreye ulaşmak için gereken minimum maliyeti döndürüyoruz
            return dp[n - 1, n - 1];
        }
    }
}
