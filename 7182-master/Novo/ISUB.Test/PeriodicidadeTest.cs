using ISUB.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
