using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;

namespace Test_1
{
    [TestClass]
    public class KsiazkaIsbnTest
    {
        [TestMethod]
        public void CzyIsbnMozebycDowolnymCiagiem13Cyfri4MyslnikowTest()
        {
            //Arrange
            Autor a = new Autor();  
            Gatunek  g =  new Gatunek();
            Wydawnictwo w = new Wydawnictwo();
            Ksiazka k = new Ksiazka("123-234-345-123-4", "aaaa", a, g, "12", "2002", w);
            Ksiazka l = new Ksiazka("123-234-345-12-21", "aaaa", a, g, "12", "2002", w);
            //Act
            k.Isbn = "123-234-345-123-4";
            l.Isbn = "123-234-345-12-21";
           

        }

        [ExpectedException(typeof(BledneDaneException))]
        [TestMethod]
        public void IsbnWYkrywanieBleduTest()
        {
            //Arrange
            Autor a = new Autor();
            Gatunek g = new Gatunek();
            Wydawnictwo w = new Wydawnictwo();
            Ksiazka k = new Ksiazka("123-23", "aaaa", a, g, "12", "2002", w);

            //Act
            k.Isbn = "123-23";

            

        }
    }
}