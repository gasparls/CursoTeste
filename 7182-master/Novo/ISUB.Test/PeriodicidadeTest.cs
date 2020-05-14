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

        [TestMethod]
        public void Test_30Dias_Nem_Sempre_Igual_UmMes()
        {
            // Arrange
            var dataInicio = new DateTime(2020, 05, 09);
            var trintaDias = new Periodicidade(30, dias: true);
            var dataEsperada1 = new DateTime(2020, 06, 08);
            var umMes = new Periodicidade(1);
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
            var umAno = new Periodicidade(365, dias: true);
            var dataEsperada1 = new DateTime(2020, 05, 08); // 2020 é bissexto.
            var dozeMeses = new Periodicidade(12);
            var dataEsperada2 = new DateTime(2020, 05, 09);

            // Act
            var dataPlanejada1 = dataInicio + umAno;
            var dataPlanejada2 = dataInicio + dozeMeses;

            // Assert
            Assert.AreEqual(dataEsperada1, dataPlanejada1);
            Assert.AreEqual(dataEsperada2, dataPlanejada2);
        }

        [TestMethod]
        public void TestIgualdade()
        {
            // Arrange
            var periodicidade = new Periodicidade(365, dias: true);
            var periodicidadeIgual = new Periodicidade(365, dias: true);

            // Act & Assert
            Assert.IsTrue(periodicidade.Equals(periodicidadeIgual));
            Assert.IsTrue(periodicidade == periodicidadeIgual);
            Assert.AreEqual(periodicidade.GetHashCode(), periodicidadeIgual.GetHashCode());
        }

        [TestMethod]
        public void TestDesigualdade()
        {
            // Arrange
            var periodicidade = new Periodicidade(365, dias: true);
            var periodicidadeDiferente = new Periodicidade(12, dias: false);

            // Act & Assert
            Assert.IsFalse(periodicidade.Equals(periodicidadeDiferente));
            Assert.IsTrue(periodicidade != periodicidadeDiferente);
            Assert.AreNotEqual(periodicidade.GetHashCode(), periodicidadeDiferente.GetHashCode());
        }
    }
}
