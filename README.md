# Derleyici Tasarımı Projesi

Kendi hazırlamış olduğum Derleyici Tasarımı'nda derleyicinin genel kuralları şu şekildedir:

## Değer Atama Kuralları

- **Integer Değer Ataması**:  
  `int sayi = 133;`

- **String Değer Ataması**:  
  `string isimler = "ademcan";`

> **Önemli**: Değer atamaları sırasında syntax düzeni, yukarıdaki örneklerdeki gibi olmalıdır. Aksi halde hata alabilirsiniz.  
> - Değeri tanımlarken eşittir (`=`) işaretinin öncesi ve sonrası boşluk olmalıdır.  
> - String ifadeler çift tırnak (`"`) içerisinde yazılmalıdır.

---

## Derleyicinin Tasarımı ve Kullanımı

- Derleyicimi **konsol ekranında** kullanılabilir şekilde tasarladım. **Form ekranı** kullanmadım.
- **RegularExpression kütüphanesi** kullanmadan geliştirdim.

### Programın Çalışma Şekli

1. **Kullanıcıdan Kod Alımı**:
   - Kullanıcı derleyiciyi açtığında, yazacağı kodu girmesi istenir.
   - **Multi-line** (çok satırlı) kod yazılabilir.
   - **Her satırın sonunda noktalı virgül (`;`) olması zorunludur.**
   
2. **Kodun Çalıştırılması**:
   - Kod yazımı bittikten sonra bir alt satıra geçilip **`çalıştır`** yazılmalı ve **Enter** tuşuna basılmalıdır.

3. **Kodun İşlenmesi**:
   - Program, girilen kodu önce **Lexer**, ardından **Parser** sınıflarında işleme tabi tutar.

4. **Çıktılar**:
   - **Lexer Çıktıları**: Lexer analizinin sonuçlarını ekrana basar.
   - **Parser Çıktıları**: Değer ataması yapılan değişkenlerin adlarını ve değerlerini gösterir.

---

## Kullanılabilir Komutlar

Kod derlendikten ve çıktılar görüldükten sonra kullanılabilecek iki komut vardır:

1. **`tekrarbaşlat`**:  
   - Bu komut girilip **Enter** tuşuna basıldığında, kullanıcı yeniden kod yazabilir ve derleme işlemi tekrar başlatılabilir.

2. **`çıkış`**:  
   - Bu komut girilip **Enter** tuşuna basıldığında programdan çıkış yapılır.

---

**Hazırlayan:**  
Ademcan İyik
