using System;
using System.Collections.Generic;

namespace derleyici
{
    // Compiler sınıfı, kullanıcıdan kod alır, derler ve çıktıları gösterir.
    public class Compiler
    {
        // Kullanıcıdan kod satırlarını alıyorum
        static List<string> KullanicidanVerileriAl()
        {
            Console.WriteLine("Kodunuzu girdikten sonra Derlemek için 'derle' yazın):");
            //girilen kodu liste alıtorum
            List<string> veriler = new List<string>();


            string satir = "";

            // Kullanıcı 'derle' yazana kadar giriş aldım hep dönmesi için while true döngüsünde
            while (true)
            {
                string giris = Console.ReadLine();

                if (giris.ToLower() == "derle")
                    break;

                satir += giris + " ";
            }

            // Satırlar ';' karakterine göre böldüm ve temizleme işlemi yaptım
            string[] satirlar = satir.Split(';');

            foreach (string s in satirlar)
            {
                string temizlenmisSatir = s.Trim();
                if (!string.IsNullOrEmpty(temizlenmisSatir))
                {
                    veriler.Add(temizlenmisSatir);
                }
            }
            //verileri return edioyorum ki kullanabileyim
            return veriler;
        }

        // Token listesini göstermek için 
        static void TokenleriGoster(List<Token> tokenler)
        {
            Console.WriteLine("Tokenlerin Çıktısı:");
            foreach (Token token in tokenler)
            {
                Console.WriteLine(token);
            }
        }

        // Parser çıktılarını gösterneek için
        static void ParserCiktiGoster(List<string> ciktilar)
        {
            Console.WriteLine("Parser Çıktıları(atanmış değerler):");
            foreach (string cikti in ciktilar)
            {
                Console.WriteLine(cikti);
            }
        }

        public static void Main(string[] args)
        {
            //hep çalıştırmak için while true döngüsüne aldım
            while (true)
            {
                // Kullanıcıdan verileri alıyırum
                List<string> veriler = KullanicidanVerileriAl();

                // Lexer ve Parserdan nesneler oluşturdum
                Lexer lexer = new Lexer();
                List<Token> tokenler = lexer.Tokenlestir(veriler);

                Parser parser = new Parser();
                List<string> ciktilar = parser.Ayrıştır(tokenler);

                // Tokenleri ve parser çıktılarını göster.
                TokenleriGoster(tokenler);
                ParserCiktiGoster(ciktilar);

                // Programı kapat veya yeniden başlatmak için
                Console.WriteLine("Programı kapatmak için 'çıkış', tekrar başlatmak için 'tekrarbaşlat' yazın:");
                string secim = Console.ReadLine();
                //to lower kullanma sebebim büyük harfler ile yazsa dahi çalışması için

                if (secim.ToLower() == "çıkış")
                    break;
                else if (secim.ToLower() == "tekrarbaşlat")
                    continue;
                else
                    Console.WriteLine("Geçersiz seçenek! Lütfen 'çıkış' veya 'tekrarbaşlat' yazın.");
            }
        }
    }
}
