using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum Plec { K, M}
    public abstract class Osoba : IEquatable<string>, IComparable<Osoba>
    {
        private int id;
        private string imie;
        private string nazwisko;
        private Plec plec;

        public int Id { get => id; set => id = value; }
        public string Imie { get => imie; set { if (value == null) throw new BledneDaneException(); else imie = value; } }
        public string Nazwisko { get => nazwisko; set { if (value == null) throw new BledneDaneException(); else nazwisko = value; } }
        public Plec Plec { get => plec; set { if (value == null) throw new BledneDaneException(); else plec = value; } }

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

        /// <summary>
        /// Metoda służy do porównywania czytelnika z podanym imieniem i nazwiskiem.
        /// </summary>
        /// <param name="imieNazwisko"></param>
        /// <returns>Jeśli znajdzie zgodność zwraca true, w przeciwnym razie false.</returns>
        public bool Equals(string imieNazwisko)
        {
            string[] imie_Nazwisko = imieNazwisko.Split(' ');
            if (imie_Nazwisko.Length > 1)
            {
                if ((imie_Nazwisko[0] == Imie && imie_Nazwisko[1] == Nazwisko) || (imie_Nazwisko[1] == Imie && imie_Nazwisko[0] == Nazwisko))
                    return true;
                return false;
            }
            else
            {
                if (imie_Nazwisko[0] == Imie || imie_Nazwisko[0] == Nazwisko)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Metoda umożliwia sortowanie obiektów klasy Osoba. Porównuje nazwiska dwóch osób, a jeśli są one takie same, porównuje imiona. 
        /// </summary>
        /// <param name="other">Porównywany obiekt</param>
        /// <returns>Zwraca liczbę całkowitą, która jest mniejsza niż 0, jeśli obiekt, dla którego jest wywoływana metoda jest mniejszy niż other, 0 jeśli są równe, lub większa niż 0, jeśli jest większy niż other.</returns>
        public int CompareTo(Osoba other)
        {
            int wynik = Nazwisko.CompareTo(other.Nazwisko);
            if (wynik == 0)
                wynik = Imie.CompareTo(other.Imie);
            return wynik;
        }
    }
}
