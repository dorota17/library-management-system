using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;

namespace Test_1
{
    [TestClass]
    public class ZapisywanieAdresuTest
    {
        [TestMethod]
        public void ZapisywanieAdresuDobryKodPocztowyTest()
        {

            // Arrange
            Wydawnictwo w = new Wydawnictwo("Wydawnictwo", "Podwale", "Krakow", "31-123");

            // Act
            w.ToString();

            // Assert
            Assert.AreEqual(w.ToString(), "Wydawnictwo Podwale Krakow 31-123");
        }



        [ExpectedException(typeof(BledneDaneException))]
        [TestMethod]
        public void ZapisywanieAdresuZlyKodPocztowyTest()
        {
            // Arrange
            Wydawnictwo w = new Wydawnictwo("Wydawnictwo", "Podwale", "Krakow", "31-12");

            // Act
            w.ToString();

            // Assert
            Assert.AreEqual(w.ToString(), "Wydawnictwo Podwale Krakow 31-123");
        }

    }
    
}
