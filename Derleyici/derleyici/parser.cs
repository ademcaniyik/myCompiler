using System;
using System.Collections.Generic;

namespace derleyici
{
    // Parser sınıfı, token listesini işleyerek kod parçalarını ayrıştırma
    public class Parser
    {
        // Mevcut token indeksi ve token listesi
        private int mevcutIndex;
        private List<Token> tokenler;

        // Verilen token listesini ayrıştırır ve çıktı listesini döndürür.
        public List<string> Ayrıştır(List<Token> tokenler)
        {
            // Mevcut token listesi ve indeksi ayarlandığu kısım
            this.tokenler = tokenler;
            mevcutIndex = 0;
            List<string> çıktı = new List<string>();

            // Token listesi sonuna kadar dönülür.
            while (mevcutIndex < tokenler.Count)
            {
                // Tanımlama denemesi yapılır.
                if (TanimlamaDenemesi(out string tanım))
                {
                    çıktı.Add(tanım);
                }
                // Eğer tanımlama yapılamıyorsa hata mesajı oluşturdum
                else
                {
                    çıktı.Add($"Hata: Geçersiz ifade. Tanımlama bekleniyor. ({tokenler[mevcutIndex].Deger})");
                    break;
                }
            }

            // Çıktı listesi döndürüyorum
            return çıktı;
        }

        // Tanımlama denemesi yapan metodum.
        private bool TanimlamaDenemesi(out string tanım)
        {
            tanım = "";

            // Eğer tip ve tanımlayıcı varsa
            if (TipDenemesi(out string tip) && TanimlayiciDenemesi(out string tanımlayıcı))
            {
                // Eğer mevcut indeksin tokeni "=" ise
                if (mevcutIndex < tokenler.Count && tokenler[mevcutIndex].Deger == "=")
                {
                    mevcutIndex++;
                    // Değer denemesi yaptırdım
                    if (DegerDenemesi(out string değer))
                    {
                        // Eğer tip "yazı" ise ve değer çift tırnakla başlıyorsa ve bitiyorsa
                        if (tip == "yazı" && değer.StartsWith("\"") && değer.EndsWith("\""))
                        {
                            değer = değer.Trim('"');
                            tanım = $"{tanımlayıcı} = {değer}";
                        }
                        else
                        {
                            tanım = $"{tanımlayıcı} = {değer}";
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Eğer atama işareti yoksa
                else
                {
                    // Eğer tip "yazı" ise
                    if (tip == "yazı")
                    {
                        tanım = $"{tanımlayıcı}";
                    }
                    else
                    {
                        tanım = $"{tip} {tanımlayıcı}";
                    }
                    return true;
                }
            }

            // Eğer token bir komut ise
            if (tokenler[mevcutIndex].Tip == "KOMUT")
            {
                return true;
            }

            return false;
        }

        // Tip denemesi yapan ksıım
        private bool TipDenemesi(out string tip)
        {
            tip = null;

            // Eğer mevcut indeksteki token türü "ANAHTARKELIME" ise
            if (mevcutIndex < tokenler.Count && tokenler[mevcutIndex].Tip == "ANAHTARKELIME")
            {
                string anahtarKelime = tokenler[mevcutIndex].Deger;
                // Eğer anahtar kelime "int" veya "string" ise
                if (anahtarKelime == "int" || anahtarKelime == "string")
                {
                    tip = anahtarKelime;
                    mevcutIndex++;
                    return true;
                }
            }

            return false;
        }

        // Tanımlayıcı denemesi yapan yer
        private bool TanimlayiciDenemesi(out string tanimlayici)
        {
            tanimlayici = null;

            // Eğer mevcut indeksteki token türü "TANIMLAYICI" ise
            if (mevcutIndex < tokenler.Count && tokenler[mevcutIndex].Tip == "TANIMLAYICI")
            {
                tanimlayici = tokenler[mevcutIndex].Deger;
                mevcutIndex++;
                return true;
            }

            return false;
        }

        // Değer denemesi yapan yer
        private bool DegerDenemesi(out string deger)
        {
            deger = null;

            // Eğer mevcut indeksteki token türü "SAYI" veya "YAZI_TAMAMLAMA" ise
            if (mevcutIndex < tokenler.Count && (tokenler[mevcutIndex].Tip == "SAYI" || tokenler[mevcutIndex].Tip == "YAZI_TAMAMLAMA"))
            {
                deger = tokenler[mevcutIndex].Deger;
                mevcutIndex++;
                return true;
            }

            mevcutIndex++;

            return false;
        }
    }
}
