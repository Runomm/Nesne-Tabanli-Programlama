using System;
using System.Threading;

class Program
{
    static int carPosition = 10;
    static int screenWidth = 30; 
    static int screenHeight = 20;
    static int obstaclePositionX = 28; 
    static int obstaclePositionY = 0; 
    static bool gameOver = false;

    static void Main()
    {
        Console.CursorVisible = false;
        Thread inputThread = new Thread(ReadInput); 
        inputThread.Start();

        while (!gameOver)
        {
            DrawScreen();
            UpdateObstacle();
            CheckCollision();
            Thread.Sleep(100); 
        }

        Console.Clear();
        Console.WriteLine("Oyun Bitti! Skorunuzu görmek için ENTER tuşuna basın.");
        Console.ReadLine();
    }

    static void ReadInput()
    {
        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && carPosition > 0)
                    carPosition--;
                else if (key == ConsoleKey.DownArrow && carPosition < screenHeight - 1)
                    carPosition++;
            }
        }
    }

    static void DrawScreen()
    {
        Console.Clear();

        for (int i = 0; i < screenHeight; i++)
        {
            if (i == carPosition)
                Console.WriteLine(">>|"); 
            else
                Console.WriteLine();
        }

        Console.SetCursorPosition(obstaclePositionX, obstaclePositionY);
        Console.Write("X"); 
    }

    static void UpdateObstacle()
    {
        obstaclePositionX--; 
        if (obstaclePositionX < 0)
        {
            obstaclePositionX = screenWidth - 1;
            obstaclePositionY = new Random().Next(0, screenHeight);
        }
    }

    static void CheckCollision()
    {
        if (obstaclePositionX == 2 && obstaclePositionY == carPosition)
        {
            gameOver = true; 
        }
    }
}
