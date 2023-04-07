using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Czytelnik : Osoba
    {
        private static int noweId;
        private int wiek;
        private string numerTelefonu;
        private string email;
        private static ObservableCollection<Czytelnik> czytelnicy;

        public int Wiek { get => wiek; set => wiek = value; }
        public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }
        public string Email { get => email; set => email = value; }
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

        public Czytelnik(string imie, string nazwisko, Plec plec, int wiek, string numerTelefonu, string email) : base(noweId, imie, nazwisko, plec)
        {
            noweId++;
            Wiek = wiek;
            NumerTelefonu = numerTelefonu;
            Email = email;
            Czytelnicy.Add(this);
        }

        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}
