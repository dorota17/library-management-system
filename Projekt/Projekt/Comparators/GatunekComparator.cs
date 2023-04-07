using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Comparators
{
    public class GatunekComparator : IComparer<Ksiazka>
    {
        public int Compare(Ksiazka x, Ksiazka y)
        {
            return string.Compare(x.Gatunek.Nazwa, y.Gatunek.Nazwa);
        }
    }
}
