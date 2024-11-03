using System;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static int genislik = 50;
        static int yukseklik = 20;
        static int[,] yilan = new int[genislik * yukseklik, 2];
        static int yilanUzunluk = 3;
        static int yemX;
        static int yemY;
        static int skor = 0;
        static bool oyunBitti = false;
        static string oyuncuAdi;
        static string[,] oyuncuBilgileri = new string[100, 3];
        static int oyuncuSayisi = 0;
        static DateTime baslangicZamani;
        static int yonX = 1;
        static int yonY = 0;

        static void Main(string[] args)
        {
            OyuncuAdiniGir();
            AnaMenu();
        }

        static void OyuncuAdiniGir()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------YILAN OYUNU-------");
            Console.Write("Adınızı Giriniz : ");
            oyuncuAdi = Console.ReadLine();
        }

        static void AnaMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------YILAN OYUNU-------");
                Console.WriteLine("1. Oyuna Başla");
                Console.WriteLine("2. Skor Listesi");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminizi yapın : ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        OyunuBaslat();
                        break;
                    case "2":
                        SkorlariGoster();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }

        static void OyunuBaslat()
        {
            OyunuHazirla();
            baslangicZamani = DateTime.Now;

            while (!oyunBitti)
            {
                OyunuCiz();
                GirdiAl();
                YilaniHareketEttir(yonX, yonY);
                Thread.Sleep(100);
            }

            TimeSpan sure = DateTime.Now - baslangicZamani;
            oyuncuBilgileri[oyuncuSayisi, 0] = oyuncuAdi;
            oyuncuBilgileri[oyuncuSayisi, 1] = skor.ToString();
            oyuncuBilgileri[oyuncuSayisi, 2] = sure.ToString();
            oyuncuSayisi++;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Oyun Bitti! Skorunuz: {skor}, Süre: {sure}");
            Console.ResetColor();
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();

            OyuncuAdiniGir();
        }

        static void OyunuHazirla()
        {
            yilanUzunluk = 3;
            yilan[0, 0] = genislik / 2; yilan[0, 1] = yukseklik / 2;
            yilan[1, 0] = genislik / 2 - 1; yilan[1, 1] = yukseklik / 2;
            yilan[2, 0] = genislik / 2 - 2; yilan[2, 1] = yukseklik / 2;
            skor = 0;
            oyunBitti = false;
            yonX = 1;
            yonY = 0;
            YemKoy();
        }

        static void OyunuCiz()
        {
            Console.Clear();
            SkorVeSureCiz();
            CerceveCiz();
            YilaniCiz();
            YemCiz();
        }

        static void CerceveCiz()
        {
            Console.SetCursorPosition(0, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("╠════════════╩════════════════════════════════════╣");
            Console.WriteLine();
            for (int i = 0; i < yukseklik; i++)
            {
                Console.Write("║");
                for (int j = 0; j < genislik - 1; j++) Console.Write(" ");
                Console.WriteLine("║");
            }
            Console.Write("╚═════════════════════════════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine();
        }

        static void YilaniCiz()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < yilanUzunluk; i++)
            {
                Console.SetCursorPosition(yilan[i, 0], yilan[i, 1] + 5);
                Console.Write("█");
            }
            Console.ResetColor();
        }

        static void YemCiz()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(yemX, yemY + 5);
            Console.Write("■");
            Console.ResetColor();
        }

        static void SkorVeSureCiz()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("╔════════════╦════════════════════════════════════╗");
            Console.SetCursorPosition(0, 1);
            Console.Write("║");
            Console.SetCursorPosition(genislik / 2 - 12, 1);
            Console.Write("║");
            Console.SetCursorPosition(genislik, 1);
            Console.Write("║");
            Console.SetCursorPosition(0, 2);
            Console.Write("║");
            Console.SetCursorPosition(genislik / 2 - 12, 2);
            Console.Write("║");
            Console.SetCursorPosition(genislik, 2);
            Console.Write("║");
            Console.SetCursorPosition(0, 3);
            Console.Write("║");
            Console.SetCursorPosition(genislik / 2 - 12, 3);
            Console.Write("║");
            Console.SetCursorPosition(genislik, 3);
            Console.Write("║");
            Console.SetCursorPosition(0, 4);
            Console.Write("╠════════════╩════════════════════════════════════╣");

            Console.ResetColor();
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Skor: {skor}");
            Console.SetCursorPosition(genislik / 2, 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Süre: {DateTime.Now - baslangicZamani}");
            Console.ResetColor();
        }

        static bool YilanKonumu(int x, int y)
        {
            for (int i = 0; i < yilanUzunluk; i++)
            {
                if (yilan[i, 0] == x && yilan[i, 1] == y)
                {
                    return true;
                }
            }
            return false;
        }

        static void GirdiAl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tusBilgisi = Console.ReadKey(true);
                switch (tusBilgisi.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (yonY == 0) { yonX = 0; yonY = -1; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (yonY == 0) { yonX = 0; yonY = 1; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (yonX == 0) { yonX = -1; yonY = 0; }
                        break;
                    case ConsoleKey.RightArrow:
                        if (yonX == 0) { yonX = 1; yonY = 0; }
                        break;
                }
            }
        }

        static void YilaniHareketEttir(int x, int y)
        {
            int yeniBasX = yilan[0, 0] + x;
            int yeniBasY = yilan[0, 1] + y;

            if (yeniBasX < 0 || yeniBasX >= genislik || yeniBasY < 0 || yeniBasY >= yukseklik || YilanKonumu(yeniBasX, yeniBasY))
            {
                oyunBitti = true;
                return;
            }

            for (int i = yilanUzunluk; i > 0; i--)
            {
                yilan[i, 0] = yilan[i - 1, 0];
                yilan[i, 1] = yilan[i - 1, 1];
            }

            yilan[0, 0] = yeniBasX;
            yilan[0, 1] = yeniBasY;

            if (yeniBasX == yemX && yeniBasY == yemY)
            {
                skor += 10;
                yilanUzunluk++;
                YemKoy();
            }
        }

        static void YemKoy()
        {
            Random random = new Random();
            do
            {
                yemX = random.Next(1, genislik - 1);
                yemY = random.Next(1, yukseklik - 1);
            } while (YilanKonumu(yemX, yemY));
        }

        static void SkorlariGoster()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Skor Listesi:");
            Console.ResetColor();
            for (int i = 0; i < oyuncuSayisi; i++)
            {
                string oyuncuAdi = oyuncuBilgileri[i, 0];
                string oyuncuSkor = oyuncuBilgileri[i, 1];
                string oyuncuSure = oyuncuBilgileri[i, 2];
                Console.WriteLine($"Oyuncu: {oyuncuAdi}, Skor: {oyuncuSkor}, Süre: {oyuncuSure}");
            }
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}