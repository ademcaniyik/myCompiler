using System;
using System.Collections.Generic;

namespace derleyici
{
    // Lexer sınıfı, bir kod parçasını tokenlere ayırmak için kullanılır.
    public class Lexer
    {
        // Token desenlerini ve türlerini içeren bir sözlük yapısı oluşturdum
        static Dictionary<string, string[]> tokenDesenleri = new Dictionary<string, string[]>()
        {
            // Anahtar kelimeler (keywords) için
            { "ANAHTARKELIME", new string[] { "int", "string", "char" } },
            // Tanımlayıcılar için (Tanımlayıcılar dinamik olarak belirlenecek.)
            { "TANIMLAYICI", null },
            // Atama işareti için
            { "ATAMA", new string[] { "=" } },
            // Sayılar için desenler. (Sayılar dinamik olarak belirlenecek.)
            { "SAYI", null },
            // Ayıraçlar için 
            { "AYRAC", new string[] { ";" } },
            // Operatörler için
            { "OPERATOR", new string[] { "+", "-", "*", "/", "%", "==", "!=", "<", ">", "&&", "||" } },
            // Açma parantezleri için
            { "ACMA", new string[] { "(" } },
            // Kapatma parantezleri için
            { "KAPAMA", new string[] { ")" } },
            // Komutlar için 
            { "KOMUT", new string[] { "bastir", "tekrarçalıştır", "çıkış" } },
            // Yazı tamamlama için 
            { "YAZI_TAMAMLAMA", new string[] { "\"" } }
        };

        // Kodu tokenlere dönüştüren metotum
        public List<Token> Tokenlestir(List<string> kod)
        {
            // Tokenker için liste oluşturdum
            List<Token> tokenler = new List<Token>();

            // Her bir satır için tokenleme işlemi yapıyorum.
            foreach (string satir in kod)
            {
                // Satır boşluklara göre bölünür ve tokenleri oluşturdum
                string[] satirTokenleri = satir.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string token in satirTokenleri)
                {
                    // Her token için çözümleme işlemi yapıp ve token listesine ekledim
                    Token tokenCozumlenmis = TokenCozumle(token);
                    tokenler.Add(tokenCozumlenmis);
                }
            }
            // Token listesi döndürğorum
            return tokenler;
        }

        // Belirli bir tokenı çözümleyen metodum
        private Token TokenCozumle(string token)
        {

            int mevcutIndex = 0;
            List<Token> tokenler = new List<Token>();

            // Eğer token bir komut ise, "KOMUT" olarak işaretledim
            if (KomutMu(token))
            {
                return new Token("KOMUT", token);
            }
            // Eğer token bir tanımlayıcı ise ve tanımlayıcılar listesinde bulunuyorsa, "TANIMLAYICI" olarak işarenen kısım
            else if (tokenDesenleri["TANIMLAYICI"] != null && Array.IndexOf(tokenDesenleri["TANIMLAYICI"], token) >= 0)
            {
                return new Token("TANIMLAYICI", token);
            }

            // Diğer token türlerini kontrol ettiğim foreach döngüsü
            foreach (var desen in tokenDesenleri)
            {
                if (desen.Value != null && Array.IndexOf(desen.Value, token) >= 0)
                {
                    return new Token(desen.Key, token);
                }
                else if (desen.Key == "TANIMLAYICI" && TanimlayiciMi(token))
                {
                    return new Token(desen.Key, token);
                }
                else if (desen.Key == "SAYI" && SayiMi(token))
                {
                    return new Token(desen.Key, token);
                }
                else if (desen.Key == "OPERATOR" && OperatorMu(token))
                {
                    return new Token(desen.Key, token);
                }
                else if (desen.Key == "ATAMA" && token == "=")
                {
                    return new Token(desen.Key, token);
                }
                else if (desen.Key == "YAZI_TAMAMLAMA" && token.StartsWith("\""))
                {
                    // Eğer token YAZI_TAMAMLAMA kategorisine ait ve çift tırnak işareti ile başlıyorsa
                    string deger = token;
                    // Token değeri ile ilgili işlem yapmak için bir değişken oluşturulur ve mevcut token atanır.
                    int index = Array.IndexOf(tokenDesenleri[desen.Key], "\"");
                    // Çift tırnak işaretinin konumu belirlenir.

                    // Çift tırnak işareti bulunana kadar ve mevcut indeks tokenlerin sayısından küçük olduğu sürece döngü devam eder.
                    while (index == -1 && mevcutIndex < tokenler.Count)
                    {
                        // Eğer çift tırnak işareti bulunamadıysa ve mevcut indeks tokenlerin sayısından küçükse
                        deger += " " + tokenler[++mevcutIndex].Deger;
                        // Değer değişkenine bir sonraki tokenin değeri eklenir ve mevcut indeks bir arttırılır.
                        index = Array.IndexOf(tokenDesenleri[desen.Key], "\"");
                        // Yeniden çift tırnak işaretinin konumu belirlenir.
                    }
                    // Döngü bittiğinde veya çift tırnak işareti bulunduğunda, tamamlanan metin tokeni oluşturulur.
                    return new Token(desen.Key, deger);
                }

            }

            // Bilinmeyen bir token türü ise "BILINMEYEN" olarak işaretliyorum
            return new Token("BILINMEYEN", token);
        }

        // Belirli bir tokenın bir komut olup olmadığını kontrol eden metodum
        private bool KomutMu(string token)
        {
            string[] komutlar = { "bastir", "tekrarçalıştır", "çıkış" };
            return Array.IndexOf(komutlar, token) >= 0;
        }

        // Belirli bir tokenın bir tanımlayıcı olup olmadığını kontrol eden metodum
        private bool TanimlayiciMi(string token)
        {
            if (char.IsLetter(token[0]) || token[0] == '_')
            {
                for (int i = 1; i < token.Length; i++)
                {
                    if (!char.IsLetterOrDigit(token[i]) && token[i] != '_')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // Belirli bir tokenın bir sayı olup olmadığını kontrol eden metot
        private bool SayiMi(string token)
        {
            double sayi;
            return double.TryParse(token, out sayi);
        }

        // Belirli bir tokenın bir operatör olup olmadığını kontrol eden metot
        private bool OperatorMu(string token)
        {
            string[] operatorler = { "+", "-", "*", "/", "%", "==", "!=", "<", ">", "&&", "||" };
            return Array.IndexOf(operatorler, token) >= 0;
        }
    }
}
