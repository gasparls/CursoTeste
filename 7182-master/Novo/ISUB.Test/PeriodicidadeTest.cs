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
    }
}
