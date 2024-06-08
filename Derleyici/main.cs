using System;
using System.Collections.Generic;

public class Compiler
{
    static List<string> KullanicidanVerileriAl()
    {
        Console.WriteLine("Kodunuzu giriniz:");
        List<string> veriler = new List<string>(); // Boþ bir liste oluþturuyoruz

        while (true)
        {
            string satir = Console.ReadLine(); // Kullanýcýdan bir satýr al

            if (satir.ToLower() == "çalýþtýr") // Kullanýcý 'çalýþtýr' yazarsa döngüden çýk
                break;

            veriler.Add(satir); // Aldýðýmýz satýrý listeye ekliyoruz
        }

        return veriler; // Liste içindeki kodlarý döndürüyoruz
    }

    static List<string> NoktaliVirguleGoreSatirAyir(string veri)
    {
        List<string> satirlar = new List<string>();

        string[] satirArray = veri.Split(';'); // Noktali virgüle göre ayýrýyoruz
        foreach (string satir in satirArray)
        {
            string trimmedSatir = satir.Trim(); // Satýrýn baþýndaki ve sonundaki boþluklarý temizliyoruz
            if (!string.IsNullOrEmpty(trimmedSatir)) // Eðer satýr boþ deðilse, listeye ekliyoruz
            {
                satirlar.Add(trimmedSatir);
            }
        }

        return satirlar;
    }

    static void CiktiGoster(List<string> kodlar)
    {
        Console.WriteLine("Girdiðiniz Kodlar:");
        foreach (string kod in kodlar)
        {
            Console.WriteLine(kod); // Her kodu ekrana bas
        }
    }


    public static void Main(string[] args)
    {
        // Metodu çaðýrarak kullanýcýdan kodu alýyoruz
        List<string> veriler = KullanicidanVerileriAl();

        // Satýrlarý noktali virgüle göre ayýr
        List<string> satirlar = NoktaliVirguleGoreSatirAyir(string.Join(";", veriler));

        // Kullanýcýnýn girdiði kodlarý ekrana bas
        CiktiGoster(satirlar);

        // Konsol ekranýnýn kapanmamasý için bir giriþ bekleyebiliriz
        Console.WriteLine("Programý sonlandýrmak için bir tuþa basýn...");
        Console.ReadKey();
    }
}
