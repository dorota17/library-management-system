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
    public class Wydawnictwo : IComparable<Wydawnictwo>
    {
        private string nazwa;
        private string ulica;
        private string miasto;
        private string kodPocztowy;
        private static ObservableCollection<Wydawnictwo> wydawnictwa;

        public string Nazwa { get => nazwa; set { if (value == null) throw new BledneDaneException(); else nazwa = value; } }
        public string Ulica { get => ulica; set { if (value == null) throw new BledneDaneException(); else ulica = value; } }
        public string Miasto { get => miasto; set { if (value == null) throw new BledneDaneException(); else miasto = value; } }
        public string KodPocztowy { get => kodPocztowy; 
            set {
                Regex regex = new Regex("^[0-9]{2}-[0-9]{3}$");
                if (value == null || !regex.IsMatch(value)) throw new BledneDaneException(); 
                else kodPocztowy = value; } 
        }
        public static ObservableCollection<Wydawnictwo> Wydawnictwa { get => wydawnictwa; set => wydawnictwa = value; }

        public Wydawnictwo()
        {

        }

        static Wydawnictwo()
        {
            Wydawnictwa = new ObservableCollection<Wydawnictwo>();
        }

        public Wydawnictwo(string nazwa, string ulica, string miasto, string kodPocztowy)
        {
            Nazwa = nazwa;
            Ulica = ulica;
            Miasto = miasto;
            KodPocztowy = kodPocztowy;
            Wydawnictwa.Add(this);
        }
        public override string ToString()
        {
            return Nazwa + " " + Ulica + " " + Miasto + " " + KodPocztowy;
        }

        public static void ZapiszWydawnictwaXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Wydawnictwo>));
            TextWriter writer = new StreamWriter("wydawnictwa.xml");
            serializer.Serialize(writer, Wydawnictwa);
            writer.Close();
        }

        public static void OdczytajWydawnictwaXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Wydawnictwo>));
            FileStream fs = new FileStream("wydawnictwa.xml", FileMode.Open);
            Wydawnictwa = (ObservableCollection<Wydawnictwo>)serializer.Deserialize(fs);
        }

        /// <summary>
        /// Metoda porównuje dwa obiekty klasy Wydawnictwo po nazwie. Pozwala na sortowanie kolekcji wydawnictw według nazw.
        /// </summary>
        /// <param name="other">Porównywany obiekt</param>
        /// <returns>Zwraca wartość -1, 0 lub 1 w zależności od tego czy nazwa pierwszego obiektu jest mniejsza, równa czy większa od nazwy drugiego obiektu.</returns>
        public int CompareTo(Wydawnictwo other)
        {
            return this.Nazwa.CompareTo(other.Nazwa);
        }
    }
}
