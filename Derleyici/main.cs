using System;
using System.Collections.Generic;

public class Compiler
{
    static List<string> KullanicidanVerileriAl()
    {
        Console.WriteLine("Kodunuzu giriniz:");
        List<string> veriler = new List<string>(); // Bo� bir liste olu�turuyoruz

        while (true)
        {
            string satir = Console.ReadLine(); // Kullan�c�dan bir sat�r al

            if (satir.ToLower() == "�al��t�r") // Kullan�c� '�al��t�r' yazarsa d�ng�den ��k
                break;

            veriler.Add(satir); // Ald���m�z sat�r� listeye ekliyoruz
        }

        return veriler; // Liste i�indeki kodlar� d�nd�r�yoruz
    }

    static List<string> NoktaliVirguleGoreSatirAyir(string veri)
    {
        List<string> satirlar = new List<string>();

        string[] satirArray = veri.Split(';'); // Noktali virg�le g�re ay�r�yoruz
        foreach (string satir in satirArray)
        {
            string trimmedSatir = satir.Trim(); // Sat�r�n ba��ndaki ve sonundaki bo�luklar� temizliyoruz
            if (!string.IsNullOrEmpty(trimmedSatir)) // E�er sat�r bo� de�ilse, listeye ekliyoruz
            {
                satirlar.Add(trimmedSatir);
            }
        }

        return satirlar;
    }

    static void CiktiGoster(List<string> kodlar)
    {
        Console.WriteLine("Girdi�iniz Kodlar:");
        foreach (string kod in kodlar)
        {
            Console.WriteLine(kod); // Her kodu ekrana bas
        }
    }


    public static void Main(string[] args)
    {
        // Metodu �a��rarak kullan�c�dan kodu al�yoruz
        List<string> veriler = KullanicidanVerileriAl();

        // Sat�rlar� noktali virg�le g�re ay�r
        List<string> satirlar = NoktaliVirguleGoreSatirAyir(string.Join(";", veriler));

        // Kullan�c�n�n girdi�i kodlar� ekrana bas
        CiktiGoster(satirlar);

        // Konsol ekran�n�n kapanmamas� i�in bir giri� bekleyebiliriz
        Console.WriteLine("Program� sonland�rmak i�in bir tu�a bas�n...");
        Console.ReadKey();
    }
}
