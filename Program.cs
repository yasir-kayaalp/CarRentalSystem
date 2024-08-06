using System.Text.RegularExpressions;
//nullable disable eklendi uyarı mesajlarını kaldırmak için
#nullable disable
namespace otoGaleriApp
{
    internal class Program
    {
        static Galeri OtoGaleri = new Galeri();
        static Araba ArabaClass = new Araba();
        static void Main(string[] args)
        {


            OtoGaleri.SahteVeri();
            Uygulama();
        }
        static void Uygulama()
        {

            Menu();
            while (true)
            {
                SecimAl();
            }
            

        }
        static void Menu()
        {//menude parantez içindeki tuşların boşluğu yoktu, numaralardan sonra eksilere fazladan boşluk koymuşuz
            Console.WriteLine("Galeri Otomasyon                           ");
            Console.WriteLine("1- Araba Kirala (K)                        ");
            Console.WriteLine("2- Araba Teslim Al (T)                     ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)          ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)        ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)               ");
            Console.WriteLine("6- Kiralama İptali (I)                     ");
            Console.WriteLine("7- Araba Ekle (Y)                          ");
            Console.WriteLine("8- Araba Sil (S)                           ");
            Console.WriteLine("9- Bilgileri Göster (G)                    ");
        }
        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();

        Plaka:
            Console.Write("Plaka: ");

            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X") { return; }
            if (PlakaKontrol(plaka))
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                    goto Plaka;
                }
                else
                {


                Marka:
                    Console.Write("Marka: ");
                    string marka = Console.ReadLine().ToUpper();
                    if (marka == "X") { return; }
                    int test;
                    string marka1 = "0";
                    bool sonuc = int.TryParse(marka, out test);
                    if (sonuc == false)
                    {

                        marka1 = marka;
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        goto Marka;
                    }
                KiralamaBedeli:
                    Console.Write("KiralamaBedeli: ");
                    string kiralamaBedeli = Console.ReadLine();
                    if (kiralamaBedeli == "X") { return; }
                    int kiralamaBedeli1;
                    int testKiralamaBedeli;
                    bool sonucKiralamaBedeli = int.TryParse(kiralamaBedeli, out testKiralamaBedeli);
                    if (sonucKiralamaBedeli)
                    {
                        kiralamaBedeli1 = testKiralamaBedeli;
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        goto KiralamaBedeli;
                    }

                    Console.WriteLine("Araba Tipi: ");
                    Console.WriteLine("SUV için 1");
                    Console.WriteLine("Hatchback için 2");
                    Console.WriteLine("Sedan için 3");
                ArabaTipi:
                    Console.Write("Seçiminiz: ");

                    string arabaTipi = Console.ReadLine(); //1
                    if (arabaTipi == "X") { return; }
                    string a = "123";
                    string arabaTipi0 = "0";
                    int index = a.IndexOf(arabaTipi);


                    if (index >= 0 && arabaTipi.Length == 1)
                    {
                        arabaTipi0 = arabaTipi;
                    }
                    else
                    {
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        goto ArabaTipi;
                    }



                    if (arabaTipi0=="3")
                    {
                        arabaTipi0 = "Sedan";
                    }
                    else if (arabaTipi0=="1")
                    {
                        arabaTipi0 = "SUV";
                    }
                    else if (arabaTipi0=="2")
                    {
                        arabaTipi0 = "Hatchback";
                    }



                    OtoGaleri.ArabaEkleme(plaka, marka1, kiralamaBedeli1, arabaTipi0);
                    //Console.WriteLine("Araba başarılı bir şekilde eklendi.");

                }
            }
            else
            {
                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                goto Plaka;
            }

        }
        static void ArabaKirala()
        {
            
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();
        Plaka1:
            Console.Write("Kiralanacak arabanın plakası: "); //34AGE418 AA414AA
        
            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X") { return; }

            if (PlakaKontrol(plaka)&&OtoGaleri.PlakaVarMi(plaka))
            {
                Console.Write("Kiralama Süresi: ");
                string sure = Console.ReadLine();
                if (sure == "X") { return; }
                int sure1;
                bool result = int.TryParse(sure, out sure1);

                OtoGaleri.ArabalarıKirala(plaka, sure1);
            }
            else if (PlakaKontrol(plaka) == false)
            {
                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                goto Plaka1;
            }
            else if (OtoGaleri.PlakaVarMi(plaka)==false)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                goto Plaka1;
            }
            
        }
        static void SecimAl()
        {

            int sayac = 0;
        Seciminiz:
            Console.WriteLine();
            Console.Write("Seçiminiz: ");
            
            string giris = Console.ReadLine().ToUpper();
            Console.WriteLine();
            switch (giris)
            {
                case "1":
                case "K":
                    ArabaKirala();
                    break;

                case "2":
                case "T":
                    ArabaTeslimAl();
                    break;

                case "3":
                case "R":
                    KiradakiArabalar();
                    break;

                case "4":
                case "M":
                    GaleridekiArabalar();
                    break;

                case "5":
                case "A":
                    TümArabalar();
                    break;

                case "6":
                case "I":
                    KiralamaIptali();
                    break;

                case "7":
                case "Y":
                    ArabaEkle();
                    break;

                case "8":
                case "S":
                    ArabaSilme();
                    break;

                case "9":
                case "G":
                    GaleriBilgileri();
                    break;

                default:

                    sayac++;
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm Sizi Anlayamıyorum, Program Sonlandırılıyor..");
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                    
                    Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                    goto Seciminiz;
                    //break; gotodan sonra break eklemeye gerek yok
            }

        }
        static bool PlakaKontrol(string plaka)
        {

            string pattern = @"^[0-9][0-9][A-Z]{1,3}[0-9]{2,4}$"; // 48A417 
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(plaka);
        }
        static void ArabaTeslimAl()
        {

            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
        Plaka1:
            Console.Write("Plaka: "); //34AGE418 AA414AA

            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X") { return; }

            if (PlakaKontrol(plaka) && OtoGaleri.KiraDurumu(plaka))
            {
                
                OtoGaleri.ArabayiTeslimAl(plaka);
            }
            else if (PlakaKontrol(plaka) == false)
            {
                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                goto Plaka1;
            }
            else if (OtoGaleri.KiraDurumu(plaka) == false)
            {
                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                goto Plaka1;
            }
            
            


        }
        static void KiradakiArabalar()
        {
            OtoGaleri.KiradakiArabalarListesi();
        }
        static void GaleridekiArabalar()
        {
            OtoGaleri.GaleridekiArabalarListesi();
        }
        static void TümArabalar()
        {
            OtoGaleri.TümArabalarListesi();
        }
        static void ArabaSilme()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();

        Plaka:
            Console.Write("Silmek istediğiniz arabanın plakasını giriniz: ");

            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X") { return; }
            if (PlakaKontrol(plaka))
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    if (OtoGaleri.KiraDurumu(plaka))
                    {
                        OtoGaleri.ArabaSilme(plaka);
                    }
                    else
                    {
                        Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                        goto Plaka;
                    }
                   
                }
                else
                {


                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");

                }
            }
            else
            {
                Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                goto Plaka;
            }

        }
        static void KiralamaIptali()
        {
            string plaka = "";
            bool plakaDogruMu;
            bool buPlakadaAracVarMı;
            bool arabaKiradaMı;

            
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();

            if (OtoGaleri.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
            }
            else
            {
                do
                {
                    Console.Write("Kiralaması iptal edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    if (plaka == "X") { return; }
                    plakaDogruMu = PlakaKontrol(plaka);
                    buPlakadaAracVarMı = OtoGaleri.PlakaVarMi(plaka);
                    arabaKiradaMı = OtoGaleri.ArabaKiradaMı(plaka);



                    if (plakaDogruMu == true && buPlakadaAracVarMı == true && arabaKiradaMı == false)
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                    }

                    else if (plakaDogruMu == true && buPlakadaAracVarMı == true && arabaKiradaMı == true)
                    {
                        OtoGaleri.KiralamaIptal(plaka);
                        Console.WriteLine("İptal gerçekleştirildi.");
                        break;
                    }

                    else if (plakaDogruMu == true && buPlakadaAracVarMı == false)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }

                    else if (plakaDogruMu == false)
                    {

                        Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    }

                    else
                    {

                    }

                } while (true);

            }
        }

        static void GaleriBilgileri()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine();
            Console.WriteLine("Toplam araba sayısı: "+OtoGaleri.Arabalar.Count);
            Console.WriteLine("Kiradaki araba sayısı: "+OtoGaleri.KiradakiArabaSayisi1());
            Console.WriteLine("Bekleyen araba sayısı: "+OtoGaleri.GaleridekiArabaSayisi1());
            Console.WriteLine("Toplam araba kiralama süresi: "+OtoGaleri.ToplamArabaKiralamaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamArabaKiralamaAdedi);
            Console.WriteLine("Ciro: "+OtoGaleri.Ciro);

        }




    }

}