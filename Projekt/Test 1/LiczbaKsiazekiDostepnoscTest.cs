using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;
using System.IO;

namespace Test_1
{
    [TestClass]
    public class LiczbaKsiazekiDostepnoscTest
    {
        [TestMethod]
        public void CzydodanaksiazkapojawiasiejakodostepnaTest()
        {
            // Arrange
            Autor a = new Autor();
            Gatunek g = new Gatunek();
            Wydawnictwo w = new Wydawnictwo();
            Wypozyczenie wy = new Wypozyczenie();
            Ksiazka k = new Ksiazka("123-234-345-123-4", "aaaa", a, g, "2001", "1", w);

            // Act

            // k.LiczbaOgolem = 1;

            // Assert
            Assert.AreEqual(k.LiczbaOgolem, k.LiczbaDostepnych);
        }
    }
}
