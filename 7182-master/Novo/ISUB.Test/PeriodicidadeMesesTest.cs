using ISUB.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ISUB.Tests.Domain
{
    [TestClass]
    public class PeriodicidadeMesesTest
    {
        [TestMethod]
        public void TestExibicaoPeriodicidadeMeses()
        {
            // Arrange
            var cincoMeses = new PeriodicidadeMeses(5);
            var sessentaMeses = new PeriodicidadeMeses(60);

            // Act & Assert
            Assert.AreEqual("5 meses", cincoMeses.ToString());
            Assert.AreEqual("60 meses", sessentaMeses.ToString());
        }

        [TestMethod]
        public void TestExibicaoPeriodicidadeNoSingular()
        {
            // Arrange
            var umMes = new PeriodicidadeMeses(1);

            // Act & Assert
            Assert.AreEqual("1 mês", umMes.ToString());
        }

        [TestMethod]
        public void TestPeriodicidadeDeveSerPositiva()
        {
            // Arrange / Act / Assert
            Assert.ThrowsException<ArgumentException>(() => new PeriodicidadeMeses(0),
                "Periodicidade não pode ser zero.");
            Assert.ThrowsException<ArgumentException>(() => new PeriodicidadeMeses(-1),
                "Periodicidade não pode ser negativa.");
        }

        [TestMethod]
        public void TestSomaPeriodicidadeMesesComDateTime()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 05, 09);
            var dozeMeses = new PeriodicidadeMeses(12);
            var dataEsperada = new DateTime(2021, 05, 09);

            // Act
            var dataPlanejada = dataInicio + dozeMeses;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada);
        }

        [TestMethod]
        public void TestSomaPeriodicidadeComDateTimeDeveSerComutativa()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 04, 29);
            var seisMeses = new PeriodicidadeMeses(6);
            var dataEsperada = new DateTime(2020, 10, 29);

            // Act
            var dataPlanejada1 = dataInicio + seisMeses;
            var dataPlanejada2 = seisMeses + dataInicio;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada1);
            Assert.AreEqual(dataEsperada, dataPlanejada2);
        }

        [TestMethod]
        public void TestIgualdade()
        {
            // Arrange
            var periodicidade = new PeriodicidadeMeses(6);
            var periodicidadeIgual = new PeriodicidadeMeses(6);

            // Act & Assert
            Assert.IsTrue(periodicidade.Equals(periodicidadeIgual));
            Assert.IsTrue(periodicidade == periodicidadeIgual);
            Assert.AreEqual(periodicidade.GetHashCode(), periodicidadeIgual.GetHashCode());
        }

        [TestMethod]
        public void TestDesigualdade()
        {
            // Arrange
            var periodicidade = new PeriodicidadeDias(365);
            var periodicidadeDiferente = new PeriodicidadeMeses(12);

            // Act & Assert
            Assert.IsFalse(periodicidade.Equals(periodicidadeDiferente));
            Assert.IsTrue(periodicidade != periodicidadeDiferente);
            Assert.AreNotEqual(periodicidade.GetHashCode(), periodicidadeDiferente.GetHashCode());
        }
    }
}
