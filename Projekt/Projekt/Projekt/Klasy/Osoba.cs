using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum Plec { K, M}
    public abstract class Osoba
    {
        private int id;
        private string imie;
        private string nazwisko;
        private Plec plec;

        public int Id { get => id; set => id = value; }
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public Plec Plec { get => plec; set => plec = value; }

        public Osoba()
        {

        }

        public Osoba(int id, string imie, string nazwisko, Plec plec)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Plec = plec;
        }
    }
}
