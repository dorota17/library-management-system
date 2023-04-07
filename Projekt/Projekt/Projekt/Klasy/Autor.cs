using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Autor : Osoba
    {
        private static int noweId;
        private static ObservableCollection<Autor> autorzy;

        public static ObservableCollection<Autor> Autorzy { get => autorzy; set => autorzy = value; }

        public Autor()
        {

        }

        static Autor()
        {
            Autorzy = new ObservableCollection<Autor>();
            noweId = 1;
        }

        public Autor(string imie, string nazwisko, Plec plec) : base(noweId, imie, nazwisko, plec)
        {
            noweId++;
            Autorzy.Add(this);
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
