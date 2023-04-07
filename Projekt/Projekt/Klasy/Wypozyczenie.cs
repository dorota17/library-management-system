using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    public class Wypozyczenie
    {
        private Czytelnik czytelnik;
        private Ksiazka ksiazka;
        private DateTime dataWypozyczenia;
        private static ObservableCollection<Wypozyczenie> wypozyczenia;

        public Czytelnik Czytelnik { get => czytelnik; set => czytelnik = value; }
        public Ksiazka Ksiazka { get => ksiazka; set => ksiazka = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public static ObservableCollection<Wypozyczenie> Wypozyczenia { get => wypozyczenia; set => wypozyczenia = value; }
        static Wypozyczenie()
        {
            Wypozyczenia = new ObservableCollection<Wypozyczenie>();
        }
        public Wypozyczenie()
        {
            Wypozyczenia.Add(this);
        }
        public Wypozyczenie(Czytelnik czytelnik, Ksiazka ksiazka, DateTime dataWypozyczenia) : this()
        {
            Czytelnik = czytelnik;
            Ksiazka = ksiazka;
            DataWypozyczenia = dataWypozyczenia;
            ksiazka.LiczbaDostepnych--;
        }

        public static void ZapiszWypozyczeniaXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Wypozyczenie>));
            TextWriter writer = new StreamWriter("wypozyczenia.xml");
            serializer.Serialize(writer, Wypozyczenia);
            writer.Close();
        }

        public static void OdczytajWypozyczeniaXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Wypozyczenie>));
            FileStream fs = new FileStream("wypozyczenia.xml", FileMode.Open);
            Wypozyczenia = (ObservableCollection<Wypozyczenie>)serializer.Deserialize(fs);
        }
    }
}
