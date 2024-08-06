using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//nullable disable eklendi uyarı mesajlarını kaldırmak için
#nullable disable
namespace otoGaleriApp
{
    internal class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string ArabaTipi { get; set; }

        public string Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();
        public List<int> Ciro = new List<int>();

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.ArabaTipi = aracTipi;
            this.Durum = "Galeride";
        }public Araba() { }


        public int KiralamaSayisi
        {
            get
            {
                return KiralamaSureleri.Count;


            }
        }
        public int ToplamKiralamaSuresi
        {
            get
            {
                //int toplam = 0;

                //foreach (int item in KiralamaSureleri)
                //{
                //toplam += item;
                //}

                //return toplam;

                return this.KiralamaSureleri.Sum();
                

            }
        }
    }
}
