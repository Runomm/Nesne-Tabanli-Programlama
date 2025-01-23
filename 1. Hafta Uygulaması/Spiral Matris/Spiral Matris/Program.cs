namespace SpiralMatris
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mehmet Onur Boyraz
            //Yazılım Mühendisliği İ.Ö.
            //245541023

            Console.WriteLine("Matrisin boyutunu girin (NxN):");
            int n = int.Parse(Console.ReadLine());

            //nxn boyutunda bir matris
            int[,] matrix = new int[n, n];

            //Başlangıç değerleri
            int value = 1; //Hücrelere yazılacak değer
            int startRow = 0, endRow = n - 1; //Satır sınırları
            int startCol = 0, endCol = n - 1; //ütun sınırlar

            while (startRow <= endRow && startCol <= endCol)
            {
                //Üst sıra soldan sağa
                for (int i = startCol; i <= endCol; i++)
                {
                    matrix[startRow, i] = value++;
                }
                startRow++; //usst sıra

                //Sag sütun yukarıdn aşağıya
                for (int i = startRow; i <= endRow; i++)
                {
                    matrix[i, endCol] = value++;
                }
                endCol--; //Sağ sütun 
                //Alt sır sağdan sola
                if (startRow <= endRow)
                {
                    for (int i = endCol; i >= startCol; i--)
                    {
                        matrix[endRow, i] = value++;
                    }
                    endRow--; // Alt sıra 
                }

                //sol sütun aşağıdan yukarıya
                if (startCol <= endCol)
                {
                    for (int i = endRow; i >= startRow; i--)
                    {
                        matrix[i, startCol] = value++;
                    }
                    startCol++; //Sol sütn 
                }
            }

            //Matrisi yazdır
            Console.WriteLine("Spiral Matris:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
     
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
