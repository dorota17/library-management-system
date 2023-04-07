using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;

namespace Test_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(BledneDaneException))]
        public void TestMethod1()
        {
            //Arrange
            Czytelnik cz = new Czytelnik();
            string zlynumer = "1234";
            //Act
            cz.NumerTelefonu= zlynumer;
            //Assert
            
        }
    }

}
