namespace soru_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 3, 5, 7 }; //örnek sayı dizisi
            string result = Solve(numbers, 0, "", numbers[0]);

            if (result != "")
                Console.WriteLine("Geçerli kombinasyon: " + result);
            else
                Console.WriteLine("Uygun kombinasyon bulunamadı.");
        }

        //diziyi ve operatörleri belirli kurallara göre deneyen rekürsif çözüm fonksiyonu
        static string Solve(int[] numbers, int index, string expression, int currentResult)
        {
            if (index == numbers.Length - 1)
            {
                //sonuca ulaştık ve sıfırdan büyükse ifadenin tamamını döndür
                if (currentResult > 0)
                    return expression + numbers[index];
                else
                    return "";
            }

            //art arda iki operatör eklememek için kurallar burada
            string result;

            //toplama operatörünü deniyoruz
            result = Solve(numbers, index + 1, expression + numbers[index] + " + ", currentResult + numbers[index + 1]);
            if (result != "")
                return result;

            //çıkarma operatörünü deniyoruz
            result = Solve(numbers, index + 1, expression + numbers[index] + " - ", currentResult - numbers[index + 1]);
            if (result != "")
                return result;

            //çarpma operatörünü deniyoruz
            result = Solve(numbers, index + 1, expression + numbers[index] + " * ", currentResult * numbers[index + 1]);
            if (result != "")
                return result;

            //bölme operatörünü deniyoruz (sıfıra bölme hatası almamak için kontrol ediyoruz)
            if (numbers[index + 1] != 0)
            {
                result = Solve(numbers, index + 1, expression + numbers[index] + " / ", currentResult / numbers[index + 1]);
                if (result != "")
                    return result;
            }

            return ""; //hiçbir kombinasyon geçerli değilse boş döndür
        }
    }
}
