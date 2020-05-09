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
            var periodicidade = new Periodicidade(5);

            // Act & Assert
            Assert.AreEqual("5 meses", periodicidade.ToString());
        }
    }
}
