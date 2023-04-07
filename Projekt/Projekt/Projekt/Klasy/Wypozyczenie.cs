using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Wypozyczenie
    {
        private Czytelnik czytelnik;
        private Ksiazka ksiazka;
        private DateTime dataWypozyczenia;
        private static ObservableCollection<Wypozyczenie> wypozyczenia;

        

        public Czytelnik Czytelnik { get => czytelnik; set => czytelnik = value; }
        public Ksiazka Ksiazka { get => ksiazka; set => ksiazka = value; }
        public DateTime DataWypozyczenia { get => dataWypozyczenia; set => dataWypozyczenia = value; }
        public static ObservableCollection<Wypozyczenie> Wypozyczenia { get => wypozyczenia; set => wypozyczenia = value; }
        static Wypozyczenie()
        {
            Wypozyczenia = new ObservableCollection<Wypozyczenie>();
        }
        public Wypozyczenie()
        {
            Wypozyczenia.Add(this);
        }
        public Wypozyczenie(Czytelnik czytelnik, Ksiazka ksiazka, DateTime dataWypozyczenia) : this()
        {
            Czytelnik = czytelnik;
            Ksiazka = ksiazka;
            DataWypozyczenia = dataWypozyczenia;
        }
    }
}
