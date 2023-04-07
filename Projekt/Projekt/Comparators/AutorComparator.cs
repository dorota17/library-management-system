using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Comparators
{
    public class AutorComparator : IComparer<Ksiazka>
    {
        public int Compare(Ksiazka x, Ksiazka y)
        {
            if (string.Compare(x.Autor.Nazwisko, y.Autor.Nazwisko) == 0)
                return string.Compare(x.Autor.Imie, y.Autor.Imie);
            return string.Compare(x.Autor.Nazwisko, y.Autor.Nazwisko);
        }
    }
}
