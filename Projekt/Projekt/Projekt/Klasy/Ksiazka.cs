using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    public class Ksiazka
    {
        private string isbn;
        private string tytul;
        private Autor autor;
        private Gatunek gatunek;
        private int rokWydania;
        private bool dostepna;
        private int liczbaOgolem;
        private int liczbaDostepnych;
        private Wydawnictwo wydawnictwo;
        private static ObservableCollection<Ksiazka> ksiazki;

        public string Isbn { 
            get => isbn; 
            set 
            {
                Regex regex = new Regex("^[0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{4}-[0-9]$");
                if (value == null || !regex.IsMatch(value)) throw new BledneDaneException(); else isbn = value; 
            } 
        }
        public string Tytul { get => tytul; set { if (value == null) throw new BledneDaneException(); else tytul = value; } }
        public Autor Autor { get => autor; set { if (value == null) throw new BledneDaneException(); else autor = value; } }
        public Gatunek Gatunek { get => gatunek; set { if (value == null) throw new BledneDaneException(); else gatunek = value; } }
        public int RokWydania { get => rokWydania; set { if (value > DateTime.Today.Year) throw new BledneDaneException(); else rokWydania = value; } }
        public bool Dostepna { get => dostepna; set => dostepna = value; }
        public int LiczbaOgolem { get => liczbaOgolem; set { if (value <= 0) throw new BledneDaneException(); else liczbaOgolem = value; } }
        public int LiczbaDostepnych { get => liczbaDostepnych; set => liczbaDostepnych = value; }
        public Wydawnictwo Wydawnictwo { get => wydawnictwo; set { if (value == null) throw new BledneDaneException(); else wydawnictwo = value; } }
        public static ObservableCollection<Ksiazka> Ksiazki { get => ksiazki; set => ksiazki = value; }

        public Ksiazka()
        {
            Ksiazki.Add(this);
        }

        static Ksiazka()
        {
            Ksiazki = new ObservableCollection<Ksiazka>();
        }

        public Ksiazka(string isbn, string tytul, Autor autor, Gatunek gatunek, string rokWydania, string liczbaOgolem, Wydawnictwo wydawnictwo) : this()
        {
            Isbn = isbn;
            Tytul = tytul;
            Autor = autor;
            Gatunek = gatunek;
            RokWydania = int.Parse(rokWydania);
            Dostepna = true;
            LiczbaOgolem = int.Parse(liczbaOgolem);
            LiczbaDostepnych = int.Parse(liczbaOgolem);
            Wydawnictwo = wydawnictwo;
        }

        public override string ToString()
        {
            //return Isbn + " " + Tytul + " " + Autor.ToString() + " " + Gatunek.ToString() + " " + RokWydania + " " + Wydawnictwo.Nazwa + " Liczba: " + liczbaOgolem + " Liczba dostępnych: " + liczbaDostepnych;
            return "";
        }

        public static void ZapiszXML(string nazwa, Ksiazka k)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Ksiazka));
            TextWriter writer = new StreamWriter($"{nazwa}.xml");
            serializer.Serialize(writer, k);
            writer.Close();
        }

        public static Ksiazka OdczytajXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Ksiazka));
            FileStream fs = new FileStream($"{nazwa}.xml", FileMode.Open);
            return (Ksiazka)serializer.Deserialize(fs);
        }
    }
}
