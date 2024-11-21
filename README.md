DERLEYİCİ TASARIMI PROJESİ
Kendi hazırlamış olduğum Derleyici Tasarımımda derleyicinin genel kuralları şu şekildedir.

İnteger Değer Ataması;
int sayi = 133;

String Değer Ataması;
string isimler = “ademcan”;

(Önemli: değer atamaları sırasında syntax düzeni örnekte verdiğim şekilde olmalıdır. Aksi halde hata alacaksınız. Değeri tanımlarken eşittir öncesi ve sonrası boş olmalı ve String ifadeler çift tırnak içerisinde yazılmalıdır.)

          Derleyicimi console ekranında kullanılabilir tasarladım. Form ekranı kullanmadım.
          
          RegularExpression kütüphanesinede derleyicimde yer vermeden yazdım.

Programın Çalışma Şekli
•	Kullanıcı derleyiciyi açtığında kullanıcıdan kodunu istiyor.
•	Multi-line kod yazılabilir şekilde  tasarladım.
•	Her satırın sonuna noktalı virgül atılması gerekmektedir.
•	Yazılan kodu çalıştırmak için kod satırı bittikten sonra bir alt satıra geçilip
          ‘çalıştır’ yazmalı ve enter’a tıklamalı.
•	Programı çalıştırdığında girilen kodu ilk önce Lexer sonrasında ise Parser Classlarında işleme tabi tutuyorum.
•	Çıktı olarak ise Lexer Analizinin çıktılarını ekrana basıyor.
•	Parser Çıktıları adı altında ise değer ataması yapılan değişkenlerin adlarını ve değerlerini ekrana basıyorum.
•	Kod derlendikten ve çıktılarını gördükten sonra ise kullanabileceğimiz 2 tane komutumuz var
•	Bunlardan birisi ‘tekrarbaşlat’ bunu yazıp enter’a tıkladığımızda tekrardan derlemek istediğiniz kodu yazabiliyorsunuz ve tekrardan çalıştırabiliyoruz.
•	Geri kalan komutumuz ise ‘çıkış’ bunu yazıp enter’a bastığımızda ise programdan çıkış yapılmış oluyor.

 Ademcan İyik

