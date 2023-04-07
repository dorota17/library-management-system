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
    public class Czytelnik : Osoba, IEquatable<int>
    {
        private static int noweId;
        private int wiek;
        private string numerTelefonu;
        private string email;
        private static ObservableCollection<Czytelnik> czytelnicy;

        public int Wiek { get => wiek; set { if (value == 0) throw new BledneDaneException(); else wiek = value; } }
        public string NumerTelefonu { 
            get => numerTelefonu;
            set
            {
                Regex regex = new Regex(@"\d\d\d\d\d\d\d\d\d");
                if (value == null || !regex.IsMatch(value)) throw new BledneDaneException(); else numerTelefonu = value;
            }
        }
        public string Email { get => email; set { if (value == null) throw new BledneDaneException(); else email = value; } }
        public static ObservableCollection<Czytelnik> Czytelnicy { get => czytelnicy; set => czytelnicy = value; }
        public static int NoweId { get => noweId; set => noweId = value; }

        public Czytelnik()
        {

        }

        static Czytelnik()
        {
            Czytelnicy = new ObservableCollection<Czytelnik>();
            noweId = 1;
        }

        public Czytelnik(string imie, string nazwisko, Plec plec, string wiek, string numerTelefonu, string email) : base(noweId, imie, nazwisko, plec)
        {
            noweId++;
            Wiek = int.Parse(wiek);
            NumerTelefonu = numerTelefonu;
            Email = email;
            Czytelnicy.Add(this);
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }

        /// <summary>
        /// Ta metoda sprawdza, czy wartość zmiennej "Id" jest równa wartości przekazanej jako argument "id".
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Jeśli wartość jest równa, zwraca true, w przeciwnym razie zwraca false.</returns>
        public bool Equals(int id)
        {
            if (Id == id)
                return true;
            else
                return false;
        }

        public static void ZapiszCzytelnikowXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Czytelnik>));
            TextWriter writer = new StreamWriter("czytelnicy.xml");
            serializer.Serialize(writer, Czytelnicy);
            writer.Close();
        }

        public static void OdczytajCzytelnikowXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Czytelnik>));
            FileStream fs = new FileStream("czytelnicy.xml", FileMode.Open);
            Czytelnicy = (ObservableCollection<Czytelnik>)serializer.Deserialize(fs);
        }
    }
}
