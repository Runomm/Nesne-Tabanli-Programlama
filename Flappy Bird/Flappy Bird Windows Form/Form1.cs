using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 8; // boru hızının varsayılan değeri bir tamsayı ile tanımlandı
        int gravity = 15; // varsayılan yer çekimi hızı bir tamsayı ile tanımlandı
        int score = 0; // varsayılan puan 0 olarak ayarlandı
        // değişkenler burada bitiyor

        public Form1()
        {
            InitializeComponent();
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            // Bu ana form ile bağlantılı oyun tuşu basılı iken gerçekleşen olaydır
            if (e.KeyCode == Keys.Space)
            {
                // Eğer boşluk tuşuna basılırsa, yer çekimi -15 olarak ayarlanır
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            // Bu ana form ile bağlantılı oyun tuşu bırakıldığında gerçekleşen olaydır

            if (e.KeyCode == Keys.Space)
            {
                // Eğer boşluk tuşu bırakılırsa, yer çekimi tekrar 15 olarak ayarlanır
                gravity = 15;
            }
        }

        private void endGame()
        {
            // Bu oyun bitiş fonksiyonudur; kuş zemine veya borulara değdiğinde çalışır
            gameTimer.Stop(); // ana zamanlayıcıyı durdurur
            scoreText.Text += " Oyun Bitti!!!"; // skor metninin yanına oyun bitti metnini ekler, += ifadesi yeni metni mevcut skora ekler ve üzerine yazmaz
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity; // flappy bird resim kutusunu yer çekimiyle bağlar, += ifadesi yer çekimi hızını resim kutusunun üst konumuna ekler, bu yüzden aşağı hareket eder
            pipeBottom.Left -= pipeSpeed; // alt borunun sol konumunu boru hızına bağlar, boru resim kutusunun sol konumundan boru hızı değerini çıkarır, böylece her tikte sola hareket eder
            pipeTop.Left -= pipeSpeed; // aynı şey üst boru için de geçerli, -= işareti kullanılarak borunun sol konumundan boru hızının değeri çıkarılır
            scoreText.Text = "Puan: " + score; // mevcut puanı skor metni etiketinde gösterir

            // aşağıda herhangi bir borunun ekrandan çıkıp çıkmadığını kontrol ediyoruz

            if (pipeBottom.Left < -150)
            {
                // eğer alt borunun konumu -150 ise, onu 800'e geri ayarlayıp puanı 1 artırırız
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                // eğer üst borunun konumu -180 ise, boruyu 950'ye geri ayarlayıp puanı 1 artırırız
                pipeTop.Left = 950;
                score++;
            }

            // aşağıdaki if ifadesi, borunun zemine, diğer borulara çarpıp çarpmadığını veya oyuncunun ekrandan yukarıya doğru çıkıp çıkmadığını kontrol ediyor
            // iki boru sembolü if ifadesinde VEYA anlamına gelir, bu nedenle if ifadesinde birden fazla koşul olabilir çünkü hepsi aynı işlevi yapacaktır

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                // yukarıdaki koşullardan herhangi biri sağlanırsa, oyun bitiş fonksiyonu çalışır
                endGame();
            }

            // puan 5'ten büyükse, boru hızını 15 yaparız
            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }
    }
}
