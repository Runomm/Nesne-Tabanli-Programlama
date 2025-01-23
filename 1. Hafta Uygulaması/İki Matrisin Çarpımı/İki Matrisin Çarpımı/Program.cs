namespace İki_Matrisin_Çarpımı
{
    class Program
    {
        static void Main(string[] args)
        {

            //Mehmet Onur Boyraz
            //Yazılım Mühendisliği İ.Ö.
            //245541023

            Console.WriteLine("Matrislerin boyutunu girin (NxN):");
            int n = int.Parse(Console.ReadLine());
            int[,] matris1 = new int[n, n];
            int[,] matris2 = new int[n, n];
            int[,] carpimMatris = new int[n, n];

            //Birinci matrisin elemanlarını alıyouz
            Console.WriteLine("Birinci matrisin elemanlarını girin:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"matris1[{i},{j}] = ");
                    matris1[i, j] = int.Parse(Console.ReadLine());
                }
            }

            //ikinci matrisin eemanlarını alıyoruz
            Console.WriteLine("İkinci matris elemanlarını girin:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"matris2[{i},{j}] = ");
                    matris2[i, j] = int.Parse(Console.ReadLine());
                }
            }

            //iki matrisin çarpımı
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    carpimMatris[i, j] = 0; //Başlngıç değer
                    for (int k = 0; k < n; k++)
                    {
                        carpimMatris[i, j] += matris1[i, k] * matris2[k, j];
                    }
                }
            }

            Console.WriteLine("Matrilerin çarpımı sonucu:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(carpimMatris[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
