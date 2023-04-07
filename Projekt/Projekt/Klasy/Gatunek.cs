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
    public class Gatunek : IEquatable<Gatunek>, IComparable<Gatunek>
    {
        private string nazwa;
        private static ObservableCollection<Gatunek> gatunki;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public static ObservableCollection<Gatunek> Gatunki { get => gatunki; set => gatunki = value; }
        

        public Gatunek()
        {

        }

        static Gatunek()
        {
            Gatunki = new ObservableCollection<Gatunek>();
        }

        public Gatunek(string nazwa)
        {
            Nazwa = nazwa;
            Gatunki.Add(this);
        }
        public override string ToString()
        {
            return Nazwa;
        }

        /// <summary>
        /// Metoda porównuje obiekt typu Gatunek z innym obiektem typu Gatunek
        /// </summary>
        /// <param name="other">Obiekt typu Gatunek, który jest porównywany</param>
        /// <returns>Zwraca true jeśli nazwa obiektu jest taka sama jak nazwa obiektu porównywanego, w przeciwnym razie zwraca false.</returns>
        public bool Equals(Gatunek other)
        {
            if(Nazwa == other.Nazwa)
                return true;
            return false;
        }

        public static void ZapiszGatunkiXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Gatunek>));
            TextWriter writer = new StreamWriter("gatunki.xml");
            serializer.Serialize(writer, Gatunki);
            writer.Close();
        }

        public static void OdczytajGatunkiXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Gatunek>));
            FileStream fs = new FileStream("gatunki.xml", FileMode.Open);
            Gatunki = (ObservableCollection<Gatunek>)serializer.Deserialize(fs);
        }

        public int CompareTo(Gatunek other)
        {
            return this.Nazwa.CompareTo(other.Nazwa);
        }

        public static int CompareTo(Gatunek g1, Gatunek g2)
        {
            throw new NotImplementedException();
        }
    }
}
