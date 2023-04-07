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
    public class Autor : Osoba
    {
        private static int noweId;
        private static ObservableCollection<Autor> autorzy;

        public static int NoweId { get => noweId; set => noweId = value; }
        public static ObservableCollection<Autor> Autorzy { get => autorzy; set => autorzy = value; }

        public Autor()
        {

        }

        static Autor()
        {
            Autorzy = new ObservableCollection<Autor>();
            NoweId = 1;
        }

        public Autor(string imie, string nazwisko, Plec plec) : base(NoweId, imie, nazwisko, plec)
        {
            NoweId++;
            Autorzy.Add(this);
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }

        public static void ZapiszAutorowXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Autor>));
            TextWriter writer = new StreamWriter("autorzy.xml");
            serializer.Serialize(writer, Autorzy);
            writer.Close();
        }

        public static void OdczytajAutorowXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Autor>));
            FileStream fs = new FileStream("autorzy.xml", FileMode.Open);
            Autorzy = (ObservableCollection<Autor>)serializer.Deserialize(fs);
        }

        
    }
}
