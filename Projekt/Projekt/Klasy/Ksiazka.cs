using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Projekt
{
    public class Ksiazka : IEquatable<string>, IComparable<Ksiazka>
    {
        private string isbn;
        private string tytul;
        private Autor autor;
        private Gatunek gatunek;
        private int rokWydania;
        private int liczbaOgolem;
        private int liczbaDostepnych;
        private Wydawnictwo wydawnictwo;
        private static ObservableCollection<Ksiazka> ksiazki;

        public string Isbn { 
            get => isbn;
            set 
            {
                Regex regex = new Regex("^(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$");
                if (value == null || !regex.IsMatch(value)) throw new BledneDaneException(); else isbn = value; 
            } 
        }
        public string Tytul { get => tytul; set { if (value == null) throw new BledneDaneException(); else tytul = value; } }
        public Autor Autor { get => autor; set { if (value == null) throw new BledneDaneException(); else autor = value; } }
        public Gatunek Gatunek { get => gatunek; set { if (value == null) throw new BledneDaneException(); else gatunek = value; } }
        public int RokWydania { get => rokWydania; set { if (value > DateTime.Today.Year) throw new BledneDaneException(); else rokWydania = value; } }
        public int LiczbaOgolem { get => liczbaOgolem; set { if (value <= 0) throw new BledneDaneException(); else liczbaOgolem = value; } }
        public int LiczbaDostepnych { get => liczbaDostepnych;  set => liczbaDostepnych = value; }
        public Wydawnictwo Wydawnictwo { get => wydawnictwo; set { if (value == null) throw new BledneDaneException(); else wydawnictwo = value; } }
        public static ObservableCollection<Ksiazka> Ksiazki { get => ksiazki; set => ksiazki = value; }

        public Ksiazka()
        {

        }

        static Ksiazka()
        {
            Ksiazki = new ObservableCollection<Ksiazka>();
        }

        public Ksiazka(string isbn, string tytul, Autor autor, Gatunek gatunek, string rokWydania, string liczbaOgolem, Wydawnictwo wydawnictwo)
        {
            Isbn = isbn;
            Tytul = tytul;
            Autor = autor;
            Gatunek = gatunek;
            RokWydania = int.Parse(rokWydania);
            LiczbaOgolem = int.Parse(liczbaOgolem);
            LiczbaDostepnych = LiczbaOgolem;
            Wydawnictwo = wydawnictwo;
            Ksiazki.Add(this);
        }

        /// <summary>
        /// Metoda porównuje ciąg znaków z tytułem lub ISBN książki.
        /// </summary>
        /// <param name="tytul_isbn">Ciąg znaków, który jest porównywany</param>
        /// <returns>Jeśli ciąg znaków jest równy tytułowi lub ISBN książki, metoda zwraca true, w przeciwnym razie zwraca false.</returns>
        public bool Equals(string tytul_isbn)
        {
            if (tytul_isbn == Tytul || tytul_isbn == Isbn)
                return true;
            return false;
        }

        public static void ZapiszKsiazkiXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Ksiazka>));
            TextWriter writer = new StreamWriter("ksiazki.xml");
            serializer.Serialize(writer, Ksiazki);
            writer.Close();
        }

        public static void OdczytajKsiazkiXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Ksiazka>));
            FileStream fs = new FileStream("ksiazki.xml", FileMode.Open);
            Ksiazki = (ObservableCollection<Ksiazka>)serializer.Deserialize(fs);
        }

        /// <summary>
        /// Metoda porównuje dwa obiekty klasy Książka po tytule. Pozwala na sortowanie kolekcji książek według tytułów.
        /// </summary>
        /// <param name="other">Porównywany obiekt</param>
        /// <returns></returns>
        public int CompareTo(Ksiazka other)
        {
            return Tytul.CompareTo(other.Tytul);
        }
    }
}
