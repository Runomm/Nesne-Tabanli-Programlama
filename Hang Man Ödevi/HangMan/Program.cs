using System;

namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] strings = {"istanbul", "bavul", "buzdolabı", "fırat", "kedi", "kebap" };
            string chosenWord = "gökyüzü"; 
            bool test = true;

            Console.WriteLine("Adam Asmaca");

            Console.WriteLine("Kelimeyi kendiniz mi belirlemek istersiniz," +
                " yoksa rastgele önceden belirlenmiş kelimelerle mi oynamak istersiniz?" +
                "(Kendiniz belirlemek için\"K\"i / Rastgele kelime için \"R\"i tuşlayınız.)");


            while (test)
            {
                System.ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.K)
                {
                    test = false;
                    Console.WriteLine("\rKelime Belirleyiniz:");
                    chosenWord = Console.ReadLine();
                }
                else if (key == ConsoleKey.R)
                {
                    test = false;
                    int num = random.Next(0, 6);
                    chosenWord = strings[num];
                }
                else
                {
                    Console.WriteLine($"\"{Console.ReadKey().Key}\" Bir seçenek değil." +
                        $"Seçenekleriniz: Kendiniz belirlemek için\"K\"i / Rastgele kelime için \"R\"i tuşlayınız.");
                }    
            }

            Game(chosenWord);

            static void Game(string word)
            {
                
                bool wordFound = false;
                char[] displayChars = new char[word.Length];
                int attemptsLeft = 10;

                for (int i = 0; i < word.Length; i++)
                {
                    displayChars[i] = '_';
                }

                while (attemptsLeft > 0 && !wordFound)
                {
                    Console.WriteLine($"kelime: {new string(displayChars)}");
                    Console.WriteLine("harf alayım:");

                    char guess = Convert.ToChar(Console.ReadLine());
                    bool charFound = false;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            displayChars[i] = guess;
                            charFound = true;
                        }
                    }

                    if (charFound)
                    {
                        Console.WriteLine($"kelimenin içinde '{guess}' harfi bulunuyor!");
                    }
                    else
                    {
                        attemptsLeft--;
                        Console.WriteLine($"kelimenin içinde '{guess}' harfi bulunmuyor!");
                        Console.WriteLine($"{attemptsLeft} hakkın kaldı.");
                    }

                    wordFound = !new string(displayChars).Contains('_');
                }
                if (wordFound)
                {
                    Console.WriteLine($"Tebrikler! kelimeyi buldun!: {word}");
                }
                else
                {
                    Console.WriteLine($"KAybettin! Kelime: {word}'idi ");
                }


            }



        }
    }
}

