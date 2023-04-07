using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Gatunek
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
    }
}
