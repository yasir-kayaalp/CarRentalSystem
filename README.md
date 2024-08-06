# Oto Galeri Uygulaması

Bu proje, C# ile geliştirilmiş basit bir oto galeri yönetim uygulamasıdır. Uygulama, araba kiralama, teslim alma, araba ekleme ve silme gibi temel işlevleri içerir.

## İçindekiler

- [Özellikler](#özellikler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Fonksiyonlar](#fonksiyonlar)
- [Katkıda Bulunanlar](##katkıda-bulunanlar)

## Özellikler

- Araba kiralama
- Kiralanmış arabaların teslim alınması
- Kiradaki arabaların listelenmesi
- Galerideki arabaların listelenmesi
- Tüm arabaların listelenmesi
- Kiralama iptali
- Yeni araba ekleme
- Araba silme
- Galeri bilgilerini gösterme

## Kurulum

1. Bu projeyi klonlayın veya indirin.
2. Visual Studio'yu açın ve projeyi yükleyin.
3. Projeyi başlatmak için `F5` tuşuna basın veya `Run` butonuna tıklayın.

## Kullanım

Uygulama açıldığında, kullanıcıya bir menü gösterilir. Menüyü kullanarak aşağıdaki işlemleri gerçekleştirebilirsiniz:

1. **Araba Kirala (K)**: Kiralanacak arabanın plakasını ve kiralama süresini girin.
2. **Araba Teslim Al (T)**: Teslim alınacak arabanın plakasını girin.
3. **Kiradaki Arabaları Listele (R)**: Kiradaki arabaları listeleyin.
4. **Galerideki Arabaları Listele (M)**: Galerideki arabaları listeleyin.
5. **Tüm Arabaları Listele (A)**: Tüm arabaları listeleyin.
6. **Kiralama İptali (I)**: Kiralanan bir arabanın kiralamasını iptal edin.
7. **Araba Ekle (Y)**: Yeni bir araba ekleyin.
8. **Araba Sil (S)**: Mevcut bir arabayı silin.
9. **Bilgileri Göster (G)**: Galeri bilgilerini gösterin.

## Fonksiyonlar

### Araba Ekleme



`static void ArabaEkle()`
Yeni bir araba eklemek için kullanılır. Kullanıcıdan plaka, marka, kiralama bedeli ve araba tipi bilgileri alınır.

### Araba Kiralama

`static void ArabaKirala()`
Bir arabayı kiralamak için kullanılır. Kullanıcıdan plaka ve kiralama süresi bilgileri alınır.

### Araba Teslim Alma

`static void ArabaTeslimAl()`
Kiralanan bir arabayı teslim almak için kullanılır. Kullanıcıdan plaka bilgisi alınır.

### Araba Silme

`static void ArabaSilme()`
Mevcut bir arabayı silmek için kullanılır. Kullanıcıdan plaka bilgisi alınır.

### Kiralama İptali

`static void KiralamaIptali()`
Kiralanan bir arabanın kiralamasını iptal etmek için kullanılır. Kullanıcıdan plaka bilgisi alınır.

### Galeri Bilgileri

`static void GaleriBilgileri()`
Galerinin genel bilgilerini göstermek için kullanılır. Toplam araba sayısı, kiradaki araba sayısı, bekleyen araba sayısı, toplam kiralama süresi, toplam kiralama adedi ve ciro bilgileri gösterilir.

## Katkıda Bulunanlar
#### Yasir KAYAALP
Bu proje hakkında herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen dalfesmain@gmail.com adresinden benimle iletişime geçin.