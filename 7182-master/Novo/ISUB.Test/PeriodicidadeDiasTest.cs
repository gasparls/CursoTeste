using ISUB.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ISUB.Tests.Domain
{
    [TestClass]
    public class PeriodicidadeDiasTest
    {
        [TestMethod]
        public void TestExibicaoPeriodicidadeDias()
        {
            // Arrange
            var seteDias = new PeriodicidadeDias(7);
            var noventaDias = new PeriodicidadeDias(90);

            // Act & Assert
            Assert.AreEqual("7 dias", seteDias.ToString());
            Assert.AreEqual("90 dias", noventaDias.ToString());
        }

        [TestMethod]
        public void TestExibicaoPeriodicidadeNoSingular()
        {
            // Arrange
            var umDia = new PeriodicidadeDias(1);

            // Act & Assert
            Assert.AreEqual("1 dia", umDia.ToString());
        }

        [TestMethod]
        public void TestPeriodicidadeDeveSerPositiva()
        {
            // Arrange / Act / Assert
            Assert.ThrowsException<ArgumentException>(() => new PeriodicidadeDias(0),
                "Periodicidade não pode ser zero.");
            Assert.ThrowsException<ArgumentException>(() => new PeriodicidadeDias(-1),
                "Periodicidade não pode ser negativa.");
        }

        [TestMethod]
        public void TestSomaPeriodicidadeDiasComDateTime()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 04, 29);
            var seteDias = new PeriodicidadeDias(7);
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
            var seteDias = new PeriodicidadeDias(7);
            var dataEsperada = new DateTime(2020, 05, 06);

            // Act
            var dataPlanejada1 = dataInicio + seteDias;
            var dataPlanejada2 = seteDias + dataInicio;

            // Assert
            Assert.AreEqual(dataEsperada, dataPlanejada1);
            Assert.AreEqual(dataEsperada, dataPlanejada2);
        }

        [TestMethod]
        public void TestIgualdade()
        {
            // Arrange
            var periodicidade = new PeriodicidadeDias(365);
            var periodicidadeIgual = new PeriodicidadeDias(365);

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
