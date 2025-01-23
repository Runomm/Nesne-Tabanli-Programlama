
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper_WindowsForms
{
    public partial class Form1 : Form
    {
        private Button[,] buttons;
        private int[,] mines;
        private int rows = 8;
        private int cols = 8;
        private int mineCount = 10;
        private bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeComponent()
        {
            this.Text = "Mayın Tarlası";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeGame()
        {
            buttons = new Button[rows, cols];
            mines = new int[rows, cols];
            gameOver = false;

            Random random = new Random();

            this.Controls.Clear();

            for (int i = 0; i < mineCount;)
            {
                int x = random.Next(rows);
                int y = random.Next(cols);
                if (mines[x, y] == 0)
                {
                    mines[x, y] = -1; 
                    i++;
                }
            }

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (mines[x, y] == -1) continue;

                    int mineCounter = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int nx = x + i, ny = y + j;
                            if (nx >= 0 && ny >= 0 && nx < rows && ny < cols && mines[nx, ny] == -1)
                            {
                                mineCounter++;
                            }
                        }
                    }
                    mines[x, y] = mineCounter;
                }
            }

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(40, 40);
                    btn.Location = new Point(x * 40, y * 40);
                    btn.Tag = new Point(x, y);
                    btn.MouseUp += Button_MouseUp;
                    buttons[x, y] = btn;
                    this.Controls.Add(btn);
                }
            }

            Button resetButton = new Button();
            resetButton.Text = "Sıfırla";
            resetButton.Size = new Size(100, 30);
            resetButton.Location = new Point(0, rows * 40 + 10);
            resetButton.Click += (sender, e) => InitializeGame();
            this.Controls.Add(resetButton);

            this.ClientSize = new Size(cols * 40, rows * 40 + 50);
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (gameOver) return;

            Button btn = sender as Button;
            Point point = (Point)btn.Tag;
            int x = point.X, y = point.Y;

            if (e.Button == MouseButtons.Left)
            {
                if (mines[x, y] == -1)
                {
                    btn.BackColor = Color.Red;
                    btn.Text = "X";
                    GameOver(false);
                }
                else
                {
                    RevealCell(x, y);
                    if (CheckWin())
                    {
                        GameOver(true);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (btn.Text == "🚩")
                {
                    btn.Text = "";
                }
                else
                {
                    btn.Text = "🚩";
                }
            }
        }

        private void RevealCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= rows || y >= cols || buttons[x, y].Enabled == false)
                return;

            buttons[x, y].Enabled = false;
            if (mines[x, y] > 0)
            {
                buttons[x, y].Text = mines[x, y].ToString();
            }
            else
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        RevealCell(x + i, y + j);
                    }
                }
            }
        }

        private void GameOver(bool won)
        {
            gameOver = true;
            string message = won ? "Bütün MAyınları buldunuz!" : "Bütün Mayınlar Patladı!";
            MessageBox.Show(message);

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (mines[x, y] == -1)
                    {
                        buttons[x, y].Text = "X";
                        buttons[x, y].BackColor = Color.Red;
                    }
                }
            }
        }

        private bool CheckWin()
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (mines[x, y] != -1 && buttons[x, y].Enabled)
                        return false;
                }
            }
            return true;
        }
    }
}
