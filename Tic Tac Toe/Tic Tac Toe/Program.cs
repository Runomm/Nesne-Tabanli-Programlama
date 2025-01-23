namespace Tic_Tac_Toe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            int moves = 0;
            bool isGameOver = false;

            while (!isGameOver && moves < 9)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"{currentPlayer}, konum seçiniz (1-9): ");

                if (int.TryParse(Console.ReadLine(), out int position) && position >= 1 && position <= 9 && board[position - 1] != 'X' && board[position - 1] != 'O')
                {
                    board[position - 1] = currentPlayer;
                    moves++;

                    if (CheckWin())
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine($"{currentPlayer} kazandı");
                        isGameOver = true;
                    }
                    else if (moves == 9)
                    {
                        Console.Clear();
                        DisplayBoard();
                        Console.WriteLine("berabere");
                    }

                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Geçersiz hamle");
                    Console.ReadKey();
                }
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static bool CheckWin()
        {
            int[,] winPatterns = {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Satırlar
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Sütunlar
                {0, 4, 8}, {2, 4, 6}             // Çaprazlar
            };

            for (int i = 0; i < winPatterns.GetLength(0); i++)
            {
                int a = winPatterns[i, 0], b = winPatterns[i, 1], c = winPatterns[i, 2];
                if (board[a] == board[b] && board[b] == board[c])
                    return true;
            }

            return false;
        }
    }
}
