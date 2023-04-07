using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Wydawnictwo
    {
        private string nazwa;
        private string ulica;
        private string miasto;
        private string kodPocztowy;
        private static ObservableCollection<Wydawnictwo> wydawnictwa;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public string KodPocztowy { get => kodPocztowy; set => kodPocztowy = value; }
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
    }
}
