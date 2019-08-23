using System;
using System.Fakes;
using System.IO;
using System.IO.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Taschenrechner.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        // Methodenname_szenario_erwarteteErgebnis
        [TestMethod]
        [TestCategory("DemoTest")]
        public void Add_12_and_3_results_15()
        {
            // AAA - Prinzip

            // Arrange: Alles vorbereiten, was man für den Test benötigt
            Taschenrechner t = new Taschenrechner();

            // Act: Die zu testende Logik ausführen
            int erg = t.Add(12, 3);

            // Assert: Das Ergebnis interpretieren
            Assert.AreEqual(15, erg);
        }

        // testm + TAB + TAB

        [TestMethod]
        [DataRow(12,3,15)]
        [DataRow(15,3,18)]
        [DataRow(99,1,100)]
        public void Add_Can_add(int z1, int z2,int expectedResult)
        {
            Taschenrechner t = new Taschenrechner();
            int result = t.Add(z1, z2);
            Assert.AreEqual(expectedResult, result);
        }

        // Fälle zum Testen:
        // Normalfall (12,3)
        // NullFall (0,0) bzw null
        // Extremfall

        [TestMethod]
        public void Add_MaxInt_1_results_OverflowException()
        {
            Taschenrechner t = new Taschenrechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                t.Add(Int32.MaxValue, 1); // Test ist OK wenn die Exception kommt
            });
        }

        [TestMethod]
        public void Add_MinInt_Neg1_results_OverflowException()
        {
            Taschenrechner t = new Taschenrechner();

            Assert.ThrowsException<OverflowException>(() =>
            {
                t.Add(Int32.MinValue, -1); // Test ist OK wenn die Exception kommt
            });
        }

        [TestMethod]
        public void GibUhrzeit_returns_23082019_1058()
        {
            // FakesFramework (nur in VisualStudio Enterprise)
            using (ShimsContext.Create())
            {
                ShimDateTime.NowGet = () => new DateTime(2019, 8, 23, 10, 58, 23);

                Taschenrechner t = new Taschenrechner();

                ShimFile.ExistsString = filename => true;

                if (File.Exists("7:\\asdbasdsdl%$%//.😂🤣🤣"))
                    ; // Test erfolgreich

                var erg = t.GibUhrzeit();
            }

            var test2 = DateTime.Now;
        }
    }
}
