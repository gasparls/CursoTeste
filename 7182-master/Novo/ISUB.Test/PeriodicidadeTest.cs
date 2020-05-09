using ISUB.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ISUB.Tests.Domain
{
    [TestClass]
    public class PeriodicidadeTest
    {
        [TestMethod]
        public void TestExibicaoPeriodicidadeMeses()
        {
            // Arrange
            var cincoMeses = new Periodicidade(5);
            var sessentaMeses = new Periodicidade(60);

            // Act & Assert
            Assert.AreEqual("5 meses", cincoMeses.ToString());
            Assert.AreEqual("60 meses", sessentaMeses.ToString());
        }

        [TestMethod]
        public void TestExibicaoPeriodicidadeDias()
        {
            // Arrange
            var seteDias = new Periodicidade(7, dias: true);
            var noventaDias = new Periodicidade(90, dias: true);

            // Act & Assert
            Assert.AreEqual("7 dias", seteDias.ToString());
            Assert.AreEqual("90 dias", noventaDias.ToString());
        }

        [TestMethod]
        public void TestExibicaoPeriodicidadeNoSingular()
        {
            // Arrange
            var umMes = new Periodicidade(1, dias: false);
            var umDia = new Periodicidade(1, dias: true);

            // Act & Assert
            Assert.AreEqual("1 mês", umMes.ToString());
            Assert.AreEqual("1 dia", umDia.ToString());
        }

        [TestMethod]
        public void TestPeriodicidadeDeveSerPositiva()
        {
            // Arrange / Act / Assert
            Assert.ThrowsException<ArgumentException>(() => new Periodicidade(0),
                "Periodicidade não pode ser zero.");
            Assert.ThrowsException<ArgumentException>(() => new Periodicidade(-1),
                "Periodicidade não pode ser negativa.");
        }

        [TestMethod]
        public void TestSomaPeriodicidadeMesesComDateTime()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 05, 09);
            var dozeMeses = new Periodicidade(12);
            var dataEsperada = new DateTime(2021, 05, 09);

            // Act
            var dataPlanejada = dataInicio + dozeMeses;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada);
        }

        [TestMethod]
        public void TestSomaPeriodicidadeDiasComDateTime()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 04, 29);
            var seteDias = new Periodicidade(7, dias: true);
            var dataEsperada = new DateTime(2020, 05, 06);

            // Act
            var dataPlanejada = dataInicio + seteDias;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada);
        }

        [TestMethod]
        public void TestSomaPeriodicidadeComDateTimeDeveSerComutativa()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 04, 29);
            var seteDias = new Periodicidade(7, dias: true);
            var dataEsperada = new DateTime(2020, 05, 06);

            // Act
            var dataPlanejada1 = dataInicio + seteDias;
            var dataPlanejada2 = seteDias + dataInicio;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada1);
            Assert.AreEqual(dataEsperada, dataPlanejada2);
        }
    }
}
