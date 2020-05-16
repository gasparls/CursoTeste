using ISUB.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ISUB.Tests.Domain
{
    [TestClass]
    public class PeriodicidadeTest
    {
        [TestMethod]
        public void Test_30Dias_Nem_Sempre_Igual_UmMes()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 05, 09);
            var trintaDias = new PeriodicidadeDias(30);
            var dataEsperada1 = new DateTime(2020, 06, 08);
            var umMes = new PeriodicidadeMeses(1);
            var dataEsperada2 = new DateTime(2020, 06, 09);

            // Act
            var dataPlanejada1 = dataInicio + trintaDias;
            var dataPlanejada2 = dataInicio + umMes;

            // Assert
            Assert.AreEqual(dataEsperada1, dataPlanejada1);
            Assert.AreEqual(dataEsperada2, dataPlanejada2);
        }

        [TestMethod]
        public void Test_12Meses_Nem_Sempre_Igual_365Dias()
        {
            // Arrange
            var dataInicio = new DateTime(2019, 05, 09);
            var umAno = new PeriodicidadeDias(365);
            var dataEsperada1 = new DateTime(2020, 05, 08); // 2020 é bissexto.
            var dozeMeses = new PeriodicidadeMeses(12);
            var dataEsperada2 = new DateTime(2020, 05, 09);

            // Act
            var dataPlanejada1 = dataInicio + umAno;
            var dataPlanejada2 = dataInicio + dozeMeses;

            // Assert
            Assert.AreEqual(dataEsperada1, dataPlanejada1);
            Assert.AreEqual(dataEsperada2, dataPlanejada2);
        }

        [TestMethod]
        public void TestPeriodicidadeDiasMesesComValorDuracaoIgualDevemSerDiferentes()
        {
            // Arrange
            var sessentaMeses = new PeriodicidadeMeses(60);
            var sessentaDias = new PeriodicidadeDias(60);

            // Act & Assert
            Assert.AreNotEqual(sessentaMeses, sessentaDias);
            Assert.AreNotEqual(sessentaMeses.GetHashCode(), sessentaDias.GetHashCode());
        }
    }
}
