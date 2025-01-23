using System;
using System.Collections.Generic;

namespace soru_7
{
    internal class Program
    {
        // Hareket yönlerini (sağ, sol, yukarı, aşağı) tanımlıyoruz
        static (int, int)[] directions = { (1, 0), (0, 1), (-1, 0), (0, -1) };
        static int M = 10; //labirent yüksekliği
        static int N = 10; //labirent genişliği

        static void Main(string[] args)
        {
            bool[,] visited = new bool[M, N]; //geçilen hücreleri işaretle
            List<(int, int)> path = new List<(int, int)>(); //doğru yolu sakla

            if (FindPath(0, 0, path, visited))
            {
                //şehre ulaşılabilir
                Console.WriteLine("Şehre ulaşılabilen yol:");
                foreach (var step in path)
                    Console.WriteLine($"({step.Item1},{step.Item2})");
            }
            else
            {
                Console.WriteLine("Şehir kayboldu!");
            }
        }

        static bool FindPath(int x, int y, List<(int, int)> path, bool[,] visited)
        {
            if (x == M - 1 && y == N - 1) //hedefe ulaşıldı mı
            {
                path.Add((x, y));
                return true;
            }

            if (!IsValid(x, y) || visited[x, y]) return false; //geçersiz veya zaten geçilmişse dur

            visited[x, y] = true; //şu anki hücreyi işaretle
            path.Add((x, y)); //yolu kaydet

            foreach (var dir in directions)
            {
                int newX = x + dir.Item1;
                int newY = y + dir.Item2;

                if (FindPath(newX, newY, path, visited)) return true; //hedefe ulaşıldıysa çık
            }

            path.RemoveAt(path.Count - 1); //başarısızsa yolu geri al
            return false;
        }

        static bool IsValid(int x, int y)
        {
            if (x < 0 || y < 0 || x >= M || y >= N) return false; //labirent sınırları dışında

            //x ve y'nin iki basamağı asal mı
            if (!IsPrimeDigit(x / 10) || !IsPrimeDigit(x % 10) || !IsPrimeDigit(y / 10) || !IsPrimeDigit(y % 10))
                return false;

            //x ve y toplamı x ve y çarpımına bölünebiliyor mu
            return (x + y) != 0 && ((x * y) % (x + y)) == 0;
        }

        static bool IsPrimeDigit(int digit)
        {
            return digit == 2 || digit == 3 || digit == 5 || digit == 7; //asal rakamlar
        }
    }
}
