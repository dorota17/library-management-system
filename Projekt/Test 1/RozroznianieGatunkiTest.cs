using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt;
using System;

namespace Test_1
{
    [TestClass]
    public class RozroznianieGatunkiTest
    {
        [TestMethod]
        public void RozroznianieGatunkuTest()
        {
            //Arrange

            Gatunek g1 = new Gatunek();
            Gatunek g2 = new Gatunek();

            g1.Nazwa = "dramat";
            g2.Nazwa = "kryminał";


            //Act
            g1.Equals(g2);
            
            //Assert
            Assert.AreEqual(false, g1.Equals(g2));
        }
    }
}
