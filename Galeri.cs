using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
//nullable disable eklendi uyarı mesajlarını kaldırmak için
#nullable disable
namespace otoGaleriApp
{
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamArabaSayısı
        {
            get
            {
                return Arabalar.Count;
            }
        }
        public int KiradakiArabaSayisi
        {
            get
            {
                int adet = 0;

                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        adet++;

                    }
                }
                return adet;
            }
        }
       

        public int ToplamArabaKiralamaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (Araba item in Arabalar)
                {
                    toplam += item.ToplamKiralamaSuresi;
                }
                return toplam;

            }
        }
        public int ToplamArabaKiralamaAdedi
        {
            get
            {

                int counter = 0;
                foreach (Araba item in Arabalar)
                {
                    counter += item.KiralamaSayisi;
                }
                return counter;
            }

        }

        public float Ciro {
            get
            {
                float toplamCiro = 0;
                foreach (Araba item in Arabalar)
                {
                    float arabaCiro;
                    arabaCiro = item.ToplamKiralamaSuresi * item.KiralamaBedeli;
                    toplamCiro+= arabaCiro;
                }

                return toplamCiro;
            }
        }

        public void ArabalarıKirala(string plaka, int sure)
        {
            Araba a = null;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {

                a.Durum = "Kirada";
                a.KiralamaSureleri.Add(sure);
                Console.WriteLine();
                Console.WriteLine(plaka + " plakalı araba " + sure + " saatliğine kiralandı.");
            }
        }
        public void ArabayiTeslimAl(string plaka)
        {
            Araba a = null;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {

                a.Durum = "Galeride";

                Console.WriteLine("Araba galeride beklemeye alındı.");
            }
        }



        public void ArabaEkleme(string plaka, string marka, int kiralamaBedeli, string arabaTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, arabaTipi);
            Arabalar.Add(a);
            Console.WriteLine();
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");
        }
         public void ArabaSilme(string plaka)
        {
            Araba a = null;
            foreach(Araba item in Arabalar)
            {
                if (item.Plaka==plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {
                Arabalar.Remove(a);
                Console.WriteLine();
                Console.WriteLine("Araba silindi.");
            }
            
        }

        //plakaVarMi metodunun ismi Baş harfi büyütüldü
        public bool PlakaVarMi(string plaka)
        {

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    return true;
                }
            }

            return false;

        }
        public bool KiraDurumu(string plaka)
        {

            foreach (Araba item in Arabalar)
            {
                if (item.Durum == "Galeride")
                {
                    return true;
                }
            }

            return false;

        }


        public void SahteVeri()
        {
            Araba a = new Araba("34ARB3434", "FIAT", 70.0f, "Sedan");
            Araba a1 = new Araba("35ARB3535", "KIA", 60.0f, "SUV");
            Araba a2 = new Araba("34US2342", "OPEL", 50.0f, "Hatchback");
            Arabalar.Add(a);
            Arabalar.Add(a1);
            Arabalar.Add(a2);
        }
        public void KiradakiArabalarListesi()
        {
            //kiralanacak araç yoksa kısmını eklemeyi unutmuşuz, araç listelemeye çalışıyordu, hata mesajı ekledim

            
            if (KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("-Kiradaki Arabalar -");
                Console.WriteLine("");
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("-Kiradaki Arabalar-");
                Console.WriteLine();
                Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K.Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K.Sayısı".PadRight(12) + "Durum");
                Console.WriteLine("".PadRight(70, '-'));
                foreach (Araba item in Arabalar)
                {
                    if (item.Durum == "Kirada")
                    {
                        Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + Convert.ToString(item.KiralamaBedeli).PadRight(12) + item.ArabaTipi.PadRight(12) + Convert.ToString(item.KiralamaSayisi).PadRight(12) + item.Durum);
                    }
                }
            }
            

        }
        public void GaleridekiArabalarListesi()
        {
            Console.WriteLine();
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine();
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K.Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K.Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("".PadRight(70,'-'));
            foreach (Araba item in Arabalar)
            {
                if (item.Durum == "Galeride")
                {
                    // yazdırırken arada(+  "") şeklinde string boşluğu vardı o yüzden sonradan listeleyip sıraya ekliyordu bunları sildim padrightlar doğru çalışsın diye
                    //kiralama bedeli ve kiralama sayısı float ve int olarak geldiği için converttostring ekledim
                    Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + Convert.ToString(item.KiralamaBedeli).PadRight(12) + item.ArabaTipi.PadRight(12) + Convert.ToString(item.KiralamaSayisi).PadRight(12) + item.Durum);
                }
            }

        }
        public void TümArabalarListesi()
        {
            Console.WriteLine();
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine();
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K.Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K.Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("".PadRight(70,'-'));
            foreach (Araba item in Arabalar)
            {

                //                                                                                                                                                                   + "" vardı sildim
                Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.ArabaTipi.PadRight(12) + item.KiralamaSayisi.ToString().PadRight(12) + item.Durum);
               
            }

        }
        public int KiradakiArabaSayisi1()
        {
            int counter = 0;
            foreach (Araba item in Arabalar)
            {
                if (item.Durum=="Kirada")
                {
                    counter++;

                }
            }
            return counter;
        }
        public int GaleridekiArabaSayisi1()
        {
            int counter = 0;
            foreach (Araba item in Arabalar)
            {
                if (item.Durum=="Galeride")
                {
                    counter++;

                }
            }
            return counter;
        }
        public void KiralamaIptal(string plaka)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = "Galeride";
                int sonKira = a.KiralamaSureleri.Count - 1;
                a.KiralamaSureleri.RemoveAt(sonKira);
            }
        }
        public bool ArabaKiradaMı(string plaka)
        {
            Araba a = null;

            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            if (a != null)
            {
                if (a.Durum == ("Kirada"))
                {
                    return true;
                }
            }

            return false;
        }


    }
}
