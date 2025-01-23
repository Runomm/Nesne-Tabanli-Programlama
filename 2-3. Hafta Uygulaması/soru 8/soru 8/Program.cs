namespace soru_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = "HE4ä_"; //şifreli mesajı buraya ekle
            string originalMessage = DecryptMessage(encryptedMessage);
            Console.WriteLine("Orijinal Mesaj: " + originalMessage);
        }

        //fibonacci pozisyonundaki sayıyı hesaplayan fonksiyon
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;

            int a = 1, b = 1, c = 0;
            for (int i = 3; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }

        //asal sayı mı değil mi diye kontrol eden fonksiyon
        static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        //şifreyi çözüp eski haline döndüren fonksiyon
        static string DecryptMessage(string encryptedMessage)
        {
            string originalMessage = "";

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                int pos = i + 1; //karakterin pozisyonu (1'den başlıyo)
                int fib = Fibonacci(pos); //pozisyona göre fibonacci sayısını alıyoruz
                int charVal = (int)encryptedMessage[i]; //şifreli karakterin ASCII değeri

                //mod işlemi ters çevirme kısmı
                int asciiVal;
                if (IsPrime(pos))
                    asciiVal = (charVal + 100) % 100; //pozisyon asal ise 100 mod alıyoruz
                else
                    asciiVal = (charVal + 256) % 256; //değilse 256 mod alıyoruz

                //orijinal karakteri geri bulmak için bölme yapıyoruz
                char originalChar = (char)(asciiVal / fib);
                originalMessage += originalChar;
            }

            return originalMessage;
        }
    }
}
