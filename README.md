# Shopping Intelligence

Bu oyun, bir işletmenin işe alım sürecinde, başvuru yapan kişilerin işlem, hafıza ve dikkat yeteneklerini ölçmek için yapılmıştır. Bursa Uludağ Üniversitesi Yönetim Bilişim Sistemleri Final ödevidir.

Oyunun konusu, oyuncu adlığı alışveriş listesindeki ürünleri belirlenen kilogramlarda alıp istenen soruları cevaplamlarıdır. Bu sayede oyuncun hesap,dikkat ve hafıza yeneklerini puanlıyor.

[YouTube Tanıtım Videosu](https://www.youtube.com/watch?v=19a-nBJiB04)

## Menü Ekranı

[![MenuEkrani.png](https://www.resimupload.org/images/2024/05/27/MenuEkrani.png)](https://www.resimupload.org/r/7dfhVp) [![ayarlarbtn.png](https://www.resimupload.org/images/2024/05/27/ayarlarbtn.png)](https://www.resimupload.org/r/7dfIjG)

- Oyunun giriş ekranıdır, sadelik ön plandadır.
- "Oyuna Başla" butonuna basıldığında oyun sahnesine geçilir.
- Sağ üstteki çark butonu "Settings" (Ayarlar) butonudur. Basıldığında animasyonlu şekilde soldan sağa doğru üç buton gelir.
- Gelen butonlar sırasıyla "Share" (Paylaşım), "Ses Açma/Kapatma" ve "Bilgilendirme" butonlarıdır.
- "Oyuna Başla" butonu olduğu yerde zıplama hareketleri yapmaktadır.

## Oyuna Başla

[![alisverisListesi.png](https://www.resimupload.org/images/2024/05/27/alisverisListesi.png)](https://www.resimupload.org/r/7dfeaz) [![oyun-baslangic.png](https://www.resimupload.org/images/2024/05/27/oyun-baslangic.png)](https://www.resimupload.org/r/7dfAOO)

- İlk başta karşımıza alışveriş listesi ve 30 saniyelik zamanlayıcı geliyor.
- Alışveriş listesinin içerisinde alacağımız ürünler ve kaç kilogram alacağımız bilgisi yer alıyor.
- Alışveriş listesinin tekrar gösterilmeyeceği belirtiliyor.
- Zamanlayıcı bittikten sonra alışveriş listesi kayboluyor, alışveriş aşaması başlıyor.

## Alışveriş Aşaması

[![pazarci.png](https://www.resimupload.org/images/2024/05/27/pazarci.png)](https://www.resimupload.org/r/7dfZvA) [![pazarci-yakindan.png](https://www.resimupload.org/images/2024/05/27/pazarci-yakindan.png)](https://www.resimupload.org/r/7df6ml)

- İlk başta karşımıza pazarcılar ve 60 saniyelik zamanlayıcı geliyor.
- Pazarcılara tıkladığımızda pazarcıların sattığı ürünler ve ürünlerin bilgilerini görebiliyoruz.
- Pazarcının sattığı ürünlerden birisine tıklayınca satın alma paneli açılıyor.

## Satın Alma Ekranı

[![meyveclick.png](https://www.resimupload.org/images/2024/05/27/meyveclick.png)](https://www.resimupload.org/r/7df14m) [![satinalclick.png](https://www.resimupload.org/images/2024/05/27/satinalclick.png)](https://www.resimupload.org/r/7dflad)

- Satın alma ekranında seçilen ürünün bilgileri geliyor.
- Oyuncudan kilogram bilgisi isteniyor.
- Satın almak istemezse "X" butonuna basarak satın alma ekranını kapatabiliyor.
- Kilogram girildikten sonra "Satın Al" butonuna basarsak satın alma işlemi tamamlanıyor ve ekran kapanıyor.
- Satın alma ekranı kapandıktan sonra alınan ürünlerin bilgileri ve ne kadar ödendiği gösteriliyor, 2 saniye sonra kayboluyor.
- Zamanlayıcı bittikten sonra "Süren doldu" uyarısı geliyor ve oyun bitiyor.

[![suren-doldu.png](https://www.resimupload.org/images/2024/05/27/suren-doldu.png)](https://www.resimupload.org/r/7oVL1q)

## Puanlama Aşaması

### Hesap Yeteneği (100 Üzerinden)

[![bos.png](https://www.resimupload.org/images/2024/05/27/bos.png)](https://www.resimupload.org/r/7dfFMI) [![hesapyetenegi-input299cb00444c42158.png](https://www.resimupload.org/images/2024/05/27/hesapyetenegi-input299cb00444c42158.png)](https://www.resimupload.org/r/7o7ZKV)

- İlk önce oyuncunun bazı bilgileri girmesi isteniyor.
- "Onayla" butonuna basıldığında puanlama aşamasına geçiliyor.
- İlk gelen kısım hesaplama yeteneği; oyuncudan pazarda harcadığı para miktarını girmesi isteniyor.
- Hesaplama yeteneği şu şekilde ölçülüyor:
  - Doğru değer girerse 100 puan
  - Fark 25'ten küçük veya eşitse 75 puan
  - Fark 25'ten büyük ve 50'den küçük veya eşitse 50 puan
  - Fark 50'den büyük ve 100'den küçük veya eşitse 25 puan
  - Fark 100'den büyükse 0 puan
- "Onayla" butonuna basıldıktan sonra dikkat yeteneğinin hesaplanmasına geçiliyor.

### Dikkat Yeteneği (100 Üzerinden)

- Dikkat yeteneğini hesaplamak için oyuncudan oyunda kaç adet meyve ve sebze olduğu bilgisi ayrı ayrı isteniyor.
- Dikkat yeteneği hesaplanırken, oyuncu meyve veya sebze sayısını eksik ya da fazla girerse her birim için -5 puan alıyor.
- "Onayla" butonuna basıldığında puan ekranına geçiliyor.

[![hafiza.png](https://www.resimupload.org/images/2024/05/27/hafiza.png)](https://www.resimupload.org/r/7dfK0E)

### Hafıza Yeteneği (100 Üzerinden)

- Hafıza yeteneği şu şekilde hesaplanıyor:
  - Alışveriş listesindeki ürünlerden aldığımız her biri için +5 puan
  - Her doğru kilogram için +5 puan
  - Yanlış alınan ürün için -5 ceza puanı veriliyor

### Puan Ekranı

- Puan ekranında alınan puanlar ilgili alanlara yerleştiriliyor.
- Ekranın sağ üst köşesinde bulunan "Home" butonu ana menüye dönmemizi sağlıyor.
- "Tekrar Oyna" butonuna basıldığında oyun yeniden başlar ve alışveriş listesi kısmından devam eder.

[![puan-ekrani.png](https://www.resimupload.org/images/2024/05/27/puan-ekrani.png)](https://www.resimupload.org/r/7dfJCL)

[![alisverisListesi.png](https://www.resimupload.org/images/2024/05/27/alisverisListesi.png)](https://www.resimupload.org/r/7dfeaz)
